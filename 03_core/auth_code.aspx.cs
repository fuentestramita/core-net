using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_code : System.Web.UI.Page
{
	int UserID = 0;
	string RUTUsuario = "";
	HttpCookie userInfo = new HttpCookie("CoreInfo");

	protected void Page_Load(object sender, EventArgs e)
	{

			userInfo = Request.Cookies["CoreInfo"];
		if (userInfo != null)
		{

			UserID = int.Parse(Utilities.cipher.DecryptString(userInfo["model"].ToString()));
			RUTUsuario = userInfo["RUT"].ToString();

			lblNombreUsuario.Text = userInfo["Name"];
			lblCorreo.Text = userInfo["Email"];

		}
		else
			Response.Redirect("sign-in.aspx", false);
	}

	protected void btnLogin_Click(object sender, ImageClickEventArgs e)
	{
		DataTable dtDatos = BusinessLayer.login.SEL_ValidaCodigoUsuario(RUTUsuario, txtCodigo.Text);

		if (dtDatos.Rows.Count == 0)
		{
			Response.Cookies["CoreInfo"].Expires = DateTime.Now.AddDays(-1);
			Session.Abandon();
			Response.Redirect("sign-in.aspx", false);
		}
		else
			Response.Redirect("default.aspx", false);

	}
}