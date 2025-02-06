using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class upload : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnUpload_Click(object sender, EventArgs e)
	{
		string strFileName;
		string strFilePath;
		string strFolder;
		strFolder = Server.MapPath("./UPLOAD/");
		// Retrieve the name of the file that is posted.
		strFileName = oFile.PostedFile.FileName;
		strFileName = Path.GetFileName(strFileName);
		string strNewFileName = String.Format("CargaPrimera_{0}{1}", DateTime.Now.ToString("yyyyMMddTHHmmss"), Path.GetExtension(strFileName)).ToString();
		if (oFile.Value != "")
		{
			// Create the folder if it does not exist.
			if (!Directory.Exists(strFolder))
			{
				Directory.CreateDirectory(strFolder);
			}
			// Save the uploaded file to the server.
			strFilePath = strFolder + strNewFileName;
			if (File.Exists(strFilePath))
			{
				File.Delete(strFilePath);
				lblUploadResult.Text = strFileName + " already exists on the server!";
			}
			else
			{
				oFile.PostedFile.SaveAs(strFilePath);
				lblUploadResult.Text = strFileName + " has been successfully uploaded.";
			}
		}
		else
		{
			lblUploadResult.Text = "Click 'Browse' to select the file to upload.";
		}
		// Display the result of the upload.
		frmConfirmation.Visible = true;
	}
}