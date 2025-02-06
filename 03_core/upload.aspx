<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="Form1" method="post" runat="server" enctype="multipart/form-data" action="upload.aspx">
		<div>
			<input id="oFile" type="file" runat="server" name="oFile">
			<asp:Button ID="btnUpload" type="submit" Text="Upload" OnClick="btnUpload_Click" runat="server"></asp:Button>
		</div>
	</form>
	<asp:Panel ID="frmConfirmation" Visible="False" runat="server">
		<asp:Label ID="lblUploadResult" runat="server"></asp:Label>
	</asp:Panel>

	<div class="page-section">
		<div class="section-deck">
			<section class="card card-fluid">

			</section>
		</div>
	</div>
</body>
</html>
