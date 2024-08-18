using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
	HttpCookie userInfo = new HttpCookie("CoreInfo");


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			userInfo = Request.Cookies["CoreInfo"];
			if (userInfo != null)
			{

				int UserID = int.Parse(Utilities.cipher.DecryptString(userInfo["model"].ToString()));
				string RUTUsuario = userInfo["RUT"].ToString();

			}
		}
	}
}