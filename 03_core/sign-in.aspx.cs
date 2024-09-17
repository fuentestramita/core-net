using Models;
using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sign_in : System.Web.UI.Page
{
	LoginModel DatosLogin = new LoginModel();
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnIngresar_Click(object sender, EventArgs e)
	{
		try
		{
			DataTable dtDatos = BusinessLayer.login.SEL_Login(txtUser.Text, txtPassword.Text);

			if (dtDatos.Rows.Count > 0)
			{
				DatosLogin.UsuarioID = dtDatos.Rows[0]["UsuarioID"].ToString();
				DatosLogin.NombreUsuario = dtDatos.Rows[0]["NombreUsuario"].ToString();
				DatosLogin.EmailUsuario = dtDatos.Rows[0]["EMailUsuario"].ToString();
				dtDatos.Dispose();

				if (DatosLogin.EmailUsuario != "")
				{

					string encUserID = Utilities.cipher.EncryptString(DatosLogin.UsuarioID);


					// Generamos Cookie con datos del usuario
					HttpCookie userInfo = new HttpCookie("CoreInfo");
					userInfo["model"] = encUserID;
					userInfo["Name"] = DatosLogin.NombreUsuario;
					userInfo["Email"] = DatosLogin.EmailUsuario;
					userInfo["RUT"] = txtUser.Text;
					userInfo.Expires.Add(new TimeSpan(0, 1, 0));
					Response.Cookies.Add(userInfo);



					// Generamos aleatorio de ingreso
					int LoginCode = new Random().Next();

					DataTable dtIns = BusinessLayer.login.INS_CodigoLogin(DatosLogin.UsuarioID, LoginCode.ToString());

					if (dtIns.Rows[0]["ErrorNumber"].ToString() == "0")
					{ 

							// Envío de Correo
							string EMailUsuario = DatosLogin.EmailUsuario;
							string MAIL_SENDER = System.Configuration.ConfigurationManager.AppSettings["MAIL_SENDER"].ToString(); //System.Configuration.ConfigurationManager.ConnectionStrings[StringDB].ToString();
							string MAIL_PASS = System.Configuration.ConfigurationManager.AppSettings["MAIL_PASS"].ToString(); //System.Configuration.ConfigurationManager.ConnectionStrings[StringDB].ToString();
							string MAIL_HOST = System.Configuration.ConfigurationManager.AppSettings["MAIL_HOST"].ToString();
							string MAIL_PORT = System.Configuration.ConfigurationManager.AppSettings["MAIL_PORT"].ToString();
							string MAIL_TARGETNAME = System.Configuration.ConfigurationManager.AppSettings["MAIL_TARGETNAME"].ToString();


							SmtpClient client = new SmtpClient(MAIL_HOST, int.Parse(MAIL_PORT));
							client.EnableSsl = true;
							client.TargetName = MAIL_TARGETNAME;
							client.UseDefaultCredentials = false;
							client.Credentials = new System.Net.NetworkCredential(MAIL_SENDER, MAIL_PASS);
							client.Port = 587;
							MailAddress from = new MailAddress(MAIL_SENDER, "Servicio Tramita", System.Text.Encoding.Default);
							MailAddress to = new MailAddress(EMailUsuario);
							MailMessage message = new MailMessage(MAIL_SENDER, EMailUsuario);
							message.Body = "Este es su código para ingresar a tramita <br><br><font color='red'><b>" + LoginCode.ToString() + "</b></font><br><br><br>Atte.<br><br>Tramita S.P.A.";
							message.BodyEncoding = System.Text.Encoding.Default;
							message.IsBodyHtml = true;
							message.Subject = "Código Autorización " + LoginCode.ToString();
							message.SubjectEncoding = System.Text.Encoding.Default;
							System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
							client.Send(message);

							Response.Redirect("auth_code.aspx");
					}

				}
			}
		}
		catch (Exception ex)
		{

			Utilities.utils.Send_Error(ex);
			Server.Transfer("Error.aspx");

		}

	}


}