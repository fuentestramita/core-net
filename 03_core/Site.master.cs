using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using BusinessLayer;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using _02_BusinessLayer;
using System.Runtime.Remoting.Messaging;
using System.Activities.Statements;

public partial class site : System.Web.UI.MasterPage
{
	HttpCookie userInfo = new HttpCookie("CoreInfo");
	protected void Page_Load(object sender, EventArgs e)
	{
			userInfo = Request.Cookies["CoreInfo"];
			if (userInfo != null)
			{
				lblNombreUsuario.Text = userInfo["Name"];
				CargaMenu(int.Parse(Utilities.cipher.DecryptString(userInfo["model"].ToString())));

			}
		if (!Page.IsPostBack)
		{
			CargaBancos();
		}

	}

	private void CargaBancos()
	{
		DataTable dtDatos = new DataTable();
		dtDatos = Empresas.SEL_EMPRESAS();
		if (dtDatos.Rows.Count > 0)
		{
			cmbEmpresas.DataSource = dtDatos;
			cmbEmpresas.DataValueField = "EmpresaID";
			cmbEmpresas.DataTextField = "RazonSocialEmpresa";
			cmbEmpresas.DataBind();
			cmbEmpresas.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));
			string strSalidaJScript = "var arrColorEmp = [\n";
			for (int i = 0; i < dtDatos.Rows.Count; i++)
			{
				strSalidaJScript += String.Format("[{0}, \"{1}\", \"{2}\"],\n", dtDatos.Rows[i]["empresaID"], dtDatos.Rows[i]["backGroundColor"], dtDatos.Rows[i]["foreColor"]);
			}
			strSalidaJScript += "];";
			ScriptManager.RegisterStartupScript(Page, GetType(), "alert", strSalidaJScript, true);

		}


	}

	public void CargaMenu(int UsuarioID)
	{

		//Active treeview
		bool TienePadre = false;

		string mnuPadre = "";


		DataTable dtMenu = usuarios.SEL_MenuUsuario(UsuarioID.ToString());

		for (int x = 0; x < dtMenu.Rows.Count; x++)
		{
			if (dtMenu.Rows[x]["PadreID"].ToString() == "0" &&  dtMenu.Rows[x]["route"] == DBNull.Value) // HEADER
			{
				this.ulMenu.Controls.Add(new LiteralControl("<li class=\"menu-header\">" + dtMenu.Rows[x]["Name"].ToString() + "</li>"));
				 
}
				if (mnuPadre != dtMenu.Rows[x]["PadreID"].ToString() && TienePadre == true) // Cierro SubMenu
			{
				this.ulMenu.Controls.Add(new LiteralControl("</ul></li>"));
				TienePadre = false;
			}
			if (dtMenu.Rows[x]["PadreID"] == DBNull.Value && dtMenu.Rows[x]["route"] == DBNull.Value) //  Cabecera menu
			{
				TienePadre = true;
				mnuPadre = dtMenu.Rows[x]["ID"].ToString();
				this.ulMenu.Controls.Add(new LiteralControl("<li class= \"menu-item has-child\">\n<a href = \"#\" class=\"menu-link\">\n<span class=\"menu-icon oi oi-people\"></span>\n<span class=\"menu-text\">" + dtMenu.Rows[x]["Name"].ToString() + "</span></a>\n<ul class=\"menu\">"));
			}

			if (mnuPadre == dtMenu.Rows[x]["PadreID"].ToString() && TienePadre == true) //  Opciones menu Hijo
			{
				this.ulMenu.Controls.Add(new LiteralControl("<li class=\"menu-item\"><a href = \"" + dtMenu.Rows[x]["route"].ToString() + "\" class=\"menu-link\">" + dtMenu.Rows[x]["Name"].ToString() + "</a></li>"));
			}


			if (dtMenu.Rows[x]["PadreID"] == DBNull.Value && dtMenu.Rows[x]["route"]!= DBNull.Value) //  Opciones menu Hijo
			{
				this.ulMenu.Controls.Add(new LiteralControl("<li class=\"menu-item\"><a href = \"" + dtMenu.Rows[x]["route"].ToString() + "\" class=\"menu-link\">" + dtMenu.Rows[x]["Name"].ToString() + "</a></li>"));
			}


		}
		if (TienePadre == true)
		{
			this.ulMenu.Controls.Add(new LiteralControl("</ul></li>"));
		}

	}


}
