<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="carga-banco-primera.aspx.cs" Inherits="cargaPrimera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

	<div class="page-inner">
		<!-- .page-title-bar -->
		<header class="page-title-bar">
			<nav aria-label="breadcrumb">
				<ol class="breadcrumb">
					<li class="breadcrumb-item active">
						<a href="default.aspx">
							<i class="breadcrumb-icon fa fa-angle-left mr-2"></i>Cargas</a>
					</li>
				</ol>
			</nav>
			<h1 class="page-title">Primera Inscripción</h1>
		</header>
		<!-- /.page-title-bar -->

		<div class="page-section">
			<!-- .section-deck -->
			<div class="section-deck">

				<section id="sectionCargaArchivo" class="card card-fluid" runat="server">

					<div class="card-body">
						<div class="page-section">
							<section id="base-style" class="card">
								<fieldset>
									<legend>Carga Archivo</legend>
									<div class="section-deck">
										<div class="custom-file">
											<asp:FileUpload ID="oFile" runat="server" AllowMultiple="false" CssClass="custom-file-input" />
											<label class="custom-file-label" for="tf3">Busque el archivo</label>
										</div>
									</div>
								</fieldset>
							</section>
						</div>
					</div>
					<div class="card-body">
						<asp:Panel ID="frmConfirmation" Visible="False" runat="server">
							<asp:Label ID="lblUploadResult" runat="server"></asp:Label>
						</asp:Panel>
					</div>
					<div class="card-body">
						<asp:Button ID="btnUpload" CssClass="btn btn-primary" type="submit" Text="Cargar Archivo" OnClick="btnUpload_Click" runat="server"></asp:Button>
					</div>
				</section>
				<section id="sectionResultadoValidacion" class="card card-fluid" runat="server" visible="false">


					<fieldset id="flsResultadoValidacion" visible="false" runat="server">
						<legend>Resultado Validacion</legend>
						<div class="card-body">
							<asp:GridView ID="grvResultadoCarga" runat="server" ShowHeader="true" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" EmptyDataText="sin registros" CssClass="table table-hover" BorderWidth="0">
								<HeaderStyle CssClass="thead-blue" />
								<Columns>
									<asp:BoundField HeaderText="PPU" DataField="PPU" />
									<asp:BoundField HeaderText="NroOperacion" DataField="NumeroOperacion" />
									<asp:BoundField HeaderText="RUT Emisor" DataField="RUTEmisor"/>
									<asp:BoundField HeaderText="Fecha Recepcion" DataField="FechaRecepcion"/>
									<asp:TemplateField>
										<HeaderTemplate>
											Resultado
										</HeaderTemplate>
										<ItemTemplate>
											<span class="oi oi-magnifying-glass mr-1"></span>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
								<EmptyDataTemplate>
								</EmptyDataTemplate>
							</asp:GridView>
						</div>
						<div class="card-body">
							<asp:Button ID="btnCargar" CssClass="btn btn-primary" Visible="true" type="submit" Text="Cargar" OnClick="btnCargar_Click" runat="server"></asp:Button>
							<asp:Button ID="btnCargaOtroArchivo" CssClass="btn btn-warning" Visible="true" type="submit" Text="Cargar Otro Archivo" OnClick="btnCargaOtroArchivo_Click" runat="server"></asp:Button>
						</div>
					</fieldset>
				</section>
			</div>
		</div>
	</div>

</asp:Content>

