<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="primera-inscripcion.aspx.cs" Inherits="primera_inscripcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


	<asp:ScriptManager ID="scriptmanager1" runat="Server" EnablePageMethods="true"></asp:ScriptManager>
	<style>
		.modal {
			display: none; /* Hidden by default */
			position: fixed; /* Stay in place */
			z-index: 1; /* Sit on top */
			left: 0;
			top: 0;
			width: 100%; /* Full width */
			height: 100%; /* Full height */
			overflow: hidden; /* Enable scroll if needed */
			background-color: rgb(0,0,0); /* Fallback color */
			background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
		}

		/* Modal Content/Box */
		.modal-content {
			background-color: #fefefe;
			margin: 5% auto; /* 15% from the top and centered */
			padding: 20px;
			border: 1px solid #888;
			width: 80%; /* Could be more or less, depending on screen size */
		}

		/* The Close Button */
		.close {
			color: #aaa;
			float: right;
			font-size: 28px;
			font-weight: bold;
		}

			.close:hover,
			.close:focus {
				color: black;
				text-decoration: none;
				cursor: pointer;
			}
	</style>
	<script language="javascript">

		function NuevoDespacho() {
			$("#txtDespachoID").val('');
			$("#txtOrigenDespacho").val('');
			$("#txtCodigoDespachoCHPX").val('');
			$("#txtPDFEntrega").val('');
			$("#txtFechaRecepcionDespacho").val('');
			$("#txtFechaEntregaDespacho").val('');
			$("#txtObservacionesEntrega").val('');
			$("#txtFechaRecepcionCHXP").val('');
			$("#txtFechaEntregaCHXP").val('');
			$("#txtCodigoDespachoCHXP").val('');

			$("#ddlCourier").val('-1');
			$("#ddlItem").val('-1');
			$("#chkSolicitaDespacho").prop("checked", false);
			$("#chkImprimirParaEntrega").prop("checked", false);

			$("#chkEntregaEfectuada").prop("checked", false);
			toggleDespachoModal();
			return false;
		}

		function NuevoDocumentoRecibido() {
			$("#txtDocumentoRecibidoID").val('');
			$("#ddlTipoDocumento").val('-1');
			$("#txtNaturalezaAdquisición").val('');
			$("#txtNroDocumentoCausa").val('');
			$("#txtEmisorDocumentoID").val('');
			$("#txtRutDocumento").val('');
			$("#txtRazonSocialEmisorDocumento").val('');
			$("#txtValorNetoFactura").val('');
			$("#txtValorTotalFactura").val('');
			$("#txtValorIvaFactura").val('');
			$("#txtLugarDocumento").val('');
			$("#txtFechaDocumento").val('');
			$("#txtNombreAutorizante").val('');
			$("#txtAcreedorBeneficiarioDemandante").val('');
			$("#txtPDFDocumento").val('');
			
			return toggleDoctosRecibidosModal();
		}


		function BuscaPersona(Origen, IDDestino, Destino) {
			PageMethods.getPersonaEmpresa(Origen.val(), onSuccess, onFailure);
			function onSuccess(result) {
				if (JSON.parse(result).PersonaEmpresaID == -1) {
					alert("Cliente no existe");
					IDDestino.val('-1');
					Destino.val('');
					Destino.focus();
					return false;
				}
				if (JSON.parse(result).PersonaEmpresaID > 0) {
					IDDestino.val(JSON.parse(result).PersonaEmpresaID);
					Destino.val(JSON.parse(result).NombreRazonSocial);
				}
			}
			function onFailure(error) {
				alert("Error " + error);
			}
			return false;
		}


		function editaDespachos(IDOrigen) {
			PageMethods.getDespacho($("#txtPrimeraInscripcionID").val(), IDOrigen, onSuccess, onFailure);
			function onSuccess(result) {
				if (JSON.parse(result).DespachoID == -1) {
					alert("Error: no se pudo recuperar el despacho")
					return false;
				}

				if (JSON.parse(result).DespachoID > 0) {
					$("#txtDespachoID").val(JSON.parse(result).DespachoID);
					$("#txtOrigenDespacho").val(JSON.parse(result).Origen);
					$("#txtCodigoDespachoCHPX").val(JSON.parse(result).CodigoDespachoCourier);
					$("#txtPDFEntrega").val(JSON.parse(result).PDFEntrega);
					$("#txtFechaRecepcionDespacho").val(JSON.parse(result).fechaRecepcion);
					$("#txtFechaEntregaDespacho").val(JSON.parse(result).FechaEntrega);
					$("#txtObservacionesEntrega").val(JSON.parse(result).Observacion);
					$("#txtFechaRecepcionCHXP").val(JSON.parse(result).FechaRecepcionCourier);
					$("#txtFechaEntregaCHXP").val(JSON.parse(result).FechaEntregaCourier);
					$("#txtCodigoDespachoCHXP").val(JSON.parse(result).CodigoDespachoCourier);

					$("#ddlCourier").val(JSON.parse(result).ServicioCourierID);
					$("#ddlItem").val(JSON.parse(result).ItemID);
					if (JSON.parse(result).SolicitaDespacho == "True")
						$("#chkSolicitaDespacho").prop("checked", true);

					if (JSON.parse(result).ImprimirParaEntrega == "True")
						$("#chkImprimirParaEntrega").prop("checked", true);

					if (JSON.parse(result).EntregaEfectuada == "True")
						$("#chkEntregaEfectuada").prop("checked", true);

				}
				//return false;
			}
			function onFailure(error) {
				alert("Error " + error.Message);
			}
			return toggleDespachoModal();
			//return false;
		}

		function editaDoctosRecibidos(IDOrigen) {
			PageMethods.getDocumentoRecibido($("#txtPrimeraInscripcionID").val(), IDOrigen, onSuccess, onFailure);
			function onSuccess(result) {
				if (JSON.parse(result).DespachoID == -1) {
					alert("Error: no se pudo recuperar el Documento Recibido")
					return false;
				}
				if (JSON.parse(result).DocumentoRecibidoID > 0) {
					$("#txtDocumentoRecibidoID").val(JSON.parse(result).DocumentoRecibidoID);
					$("#ddlTipoDocumento").val(JSON.parse(result).TipoDocumentoID);
					$("#txtNaturalezaAdquisición").val(JSON.parse(result).NaturalezaAdquisicion);
					$("#txtNroDocumentoCausa").val(JSON.parse(result).NumeroDocumentoCausa);
					$("#txtEmisorDocumentoID").val(JSON.parse(result).EmisorDocumentoID);
					$("#txtRutDocumento").val(JSON.parse(result).RutEmisorDocumento);
					$("#txtRazonSocialEmisorDocumento").val(JSON.parse(result).NombreRazonSocialEmisorDocumento);
					$("#txtValorNetoFactura").val(JSON.parse(result).ValorNeto);
					$("#txtValorTotalFactura").val(JSON.parse(result).ValorTotalFactura);
					$("#txtValorIvaFactura").val(JSON.parse(result).ValorIVAFactura);
					$("#txtLugarDocumento").val(JSON.parse(result).LugarDocumento);
					$("#txtFechaDocumento").val(JSON.parse(result).FechaDocumento);
					$("#txtNombreAutorizante").val(JSON.parse(result).NombreAutorizanteEmisor);
					$("#txtAcreedorBeneficiarioDemandante").val(JSON.parse(result).AcreedorBeneficiarioDemandante);
					$("#txtPDFDocumento").val(JSON.parse(result).PDF);

				}
				//return false;
			}
			function onFailure(error) {
				alert("Error " + error);
			}
			return toggleDoctosRecibidosModal();
			//return false;
		}

	</script>
	<asp:TextBox ID="txtPrimeraInscripcionID" Style="display: none;" runat="server" BorderColor="Red"></asp:TextBox>

	<div class="page-inner">
		<!-- .page-title-bar -->
		<header class="page-title-bar">
			<nav aria-label="breadcrumb">
				<ol class="breadcrumb">
					<li class="breadcrumb-item active">
						<a href="default.aspx">
							<i class="breadcrumb-icon fa fa-angle-left mr-2"></i>Interfaces</a>
					</li>
				</ol>
			</nav>
			<h1 class="page-title">Primera Inscripción</h1>
		</header>
		<!-- /.page-title-bar -->

		<div class="page-section">
			<!-- .section-deck -->
			<div class="section-deck">

				<section class="card card-fluid">

					<div class="card-body">
						<!-- .card-body -->
						<h4 class="card-title">BUSCAR</h4>
						<h6 class="card-subtitle mb-4"></h6>

						<div class="form-row">
							<div class="col">
								<label class="form-label-lg" for="select2-basic-single">PPU</label>
							</div>
							<div class="col">
								<label class="form-label-lg" for="select2-basic-single">Nro.Factura</label>
							</div>
							<div class="col">
								<label class="form-label-lg" for="select2-basic-single">RUT Factura</label>
							</div>
							<div class="col">
								&nbsp;
							</div>
							<div class="col">
								&nbsp;
							</div>
						</div>
						<div class="form-row">
							<div class="col">
								<asp:TextBox ID="txtPPUBuscar" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
							</div>
							<div class="col">
								<asp:TextBox ID="txtNroFacturaBuscar" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
							</div>
							<div class="col">
								<asp:TextBox ID="txtRUTFacturaBuscar" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
							</div>
							<div class="col">
								<asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server"></asp:Button>
							</div>
							<div class="col">
								&nbsp;
							</div>
						</div>
					</div>
					<!-- /.card-body -->

				</section>
			</div>
		</div>


		<!-- .page-section -->

		<div class="page-section">

			<div class="section-deck">
				<section class="card card-fluid">
					<div class="card-body text-right">
						<asp:Button ID="btnGrabarTop" Text="Grabar" CssClass="btn btn-primary" OnClick="btnGrabarPrimera_Click" runat="server" />
						<asp:Button ID="btnNuevoTop" Text="Nuevo" CssClass="btn btn btn-primary" OnClick="btnNuevoPrimera_Click" runat="server" />
						<asp:Button ID="btnEliminarTop" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminarPrimera_Click" runat="server" />
						<asp:Button ID="btnSalirTop" Text="Salir" CssClass="btn btn btn-primary" OnClick="btnSalirPrimera_Click" runat="server" />
					</div>
				</section>
			</div>

			<!-- .section-deck -->
			<div class="section-deck">
				<!-- .card -->
				<section class="card card-fluid">

					<div class="card-body">
						<!-- .card-body -->
						<h4 class="card-title">Datos Tramita </h4>
						<h6 class="card-subtitle mb-4"></h6>
						<div class="form-group">
							<label class="form-label-lg" for="select2-basic-single">PPU</label>
							<asp:TextBox ID="txtPPU" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
							<asp:TextBox ID="txtDVPPU" CssClass="form-input-xs" placeholder="" runat="server"></asp:TextBox>
							<div style="text-align: center; display: inline; margin-top: 15px;">
								<label class="form-label-xs" for="select2-data-remote">PDF TAG</label>

								<div class="btn-group">
									<asp:TextBox ID="txtPDFTag" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
									<button class="btn-xs btn-secondary">
										<span class="oi oi-data-transfer-download mr-1"></span>
									</button>
								</div>
							</div>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-array">Estado</label>
							<asp:DropDownList ID="ddlEstado" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Nro de Operacion</label>
							<asp:TextBox ID="txtNroOperacion" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Origen</label>
							<asp:TextBox ID="txtOrigen" CssClass="form-input-lg" placeholder="" runat="server"></asp:TextBox>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Nro de Operacion M.T.</label>
							<asp:TextBox ID="txtNroOperacionMT" CssClass="form-input-md" placeholder="" runat="server"></asp:TextBox>
						</div>


						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Código C.I.T.</label>
							<asp:TextBox ID="txtCodigoCIT" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Nro.Factura</label>
							<asp:TextBox ID="txtNroFactura" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Vencimiento Contrato Leasing</label>
							<asp:TextBox ID="txtVencimientoContratoLeasing" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">RUT Cliente</label>
							<asp:TextBox ID="txtClienteID" Style="display: none;" runat="server" BorderColor="Red"></asp:TextBox>
							<asp:TextBox ID="txtRUTCliente" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
							<button class="btn-xs btn-primary" onclick="return(BuscaPersona($('#txtRUTCliente'), $('#txtClienteID'), $('#txtNombreRazonSocialCliente')));">
								<span class="oi oi-magnifying-glass mr-1"></span>
							</button>

						</div>


						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Razón Social/Nombre Cliente</label>
							<asp:TextBox ID="txtNombreRazonSocialCliente" CssClass="form-input-xl flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Dirección Cliente</label>
							<label class="form-label-sm" for="select2-data-remote" style="margin-left: 25px">Número</label>
							<label class="form-label-md" for="select2-data-remote" style="margin-left: 47px">Complemento</label>
						</div>
						<div class="form-group">
							<asp:TextBox ID="txtDireccionClienteID" Visible="false" runat="server" BorderColor="Red"></asp:TextBox>
							<asp:TextBox ID="txtDireccionCliente" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<asp:TextBox ID="txtNumeroDireccionCliente" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<asp:TextBox ID="txtComplementoDireccionCliente" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Comuna</label>
							<label class="form-label-sm" for="select2-data-remote" style="margin-left: 30px">Ciudad</label>
						</div>
						<div class="form-group">
							<asp:DropDownList ID="ddlComunaCliente" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
							<asp:DropDownList ID="ddlCiudadCliente" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Rut Representante Legal</label>
							<asp:TextBox ID="txtRepresentanteLegalID" Style="display: none;" runat="server" BorderColor="Red"></asp:TextBox>
							<asp:TextBox ID="txtRUTRepresentanteLegal" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<button class="btn-xs btn-primary" onclick="return(BuscaPersona($('#txtRUTRepresentanteLegal'), $('#txtRepresentanteLegalID'), $('#txtNombreRepresentanteLegal')));">
								<span class="oi oi-magnifying-glass mr-1"></span>
							</button>

						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Nombre Representante Legal</label>
							<asp:TextBox ID="txtNombreRepresentanteLegal" CssClass="form-input-xl flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>

						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Contacto</label>
							<asp:TextBox ID="txtContacto" CssClass="form-input-xl flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Teléfono Contacto</label>
							<asp:TextBox ID="txtTelefonoContacto" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">E-mail Contacto</label>
							<asp:TextBox ID="txtEmailContacto" CssClass="form-input-xl flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Número Solicitud</label>
							<asp:TextBox ID="txtNroSolicitud" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<asp:CheckBox ID="chkTieneListadoPrimeraInscripcion" CssClass="control-input" runat="server" />
							<label class="form-label-lg" for="select2-data-remote">Entrega Listado</label>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Oficina</label>
							<asp:DropDownList ID="ddlOficinas" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Fecha Solicitud R.N.V.M</label>
							<asp:TextBox ID="txtFechaSolicitudRNVM" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkRUT" CssClass="control-input" runat="server" />
								<label class="form-label-xs" for="select2-data-remote">RUT</label>
								<asp:CheckBox ID="chkEC" CssClass="control-input" runat="server" />
								<label class="form-label-xs" for="select2-data-remote">E.C.</label>
								<asp:CheckBox ID="chkCI" CssClass="control-input" runat="server" />
								<label class="form-label-xs" for="select2-data-remote">C.I.</label>
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Número Valija</label>
							<asp:TextBox ID="txtNroValija" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Ejecutivo</label>
							<asp:TextBox ID="txtEjecutivo" CssClass="form-input-xl flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Sucursal</label>
							<asp:TextBox ID="txtSucursal" CssClass="form-input-md flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>


					</div>
					<!-- /.card-body -->

				</section>

				<!-- /.card -->
				<!-- .Datos Tramita -->
				<section class="card card-fluid">
					<!-- .card-body -->
					<div class="card-body">
						<h4 class="card-title">Datos Tramita </h4>
						<h6 class="card-subtitle mb-4"></h6>
						<!-- form -->
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Año Proceso</label>
							<asp:DropDownList ID="ddlAnoProceso" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Fecha Recepción Banco</label>
							<asp:TextBox ID="txtFechaRecepcionBanco" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Fecha Padrón</label>
							<asp:TextBox ID="txtFechaPadron" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Código Despacho Correo</label>
							<asp:TextBox ID="txtCodigoDespachoCorreo" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Observcación Entrega</label>
							<asp:DropDownList ID="ddlObservacionEntrega" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Número de Placas</label>
							<asp:DropDownList ID="ddlNroPlacas" CssClass="form-input-lg" runat="server">
								<asp:ListItem Value="-1" Text="--- SELECCCIONE ---"></asp:ListItem>
								<asp:ListItem Value="1" Text="1"></asp:ListItem>
								<asp:ListItem Value="2" Text="2"></asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">&nbsp;</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkTAG" CssClass="control-input" runat="server" />
								<label class="form-label-xs" for="select2-data-remote">TAG</label>
								<asp:CheckBox ID="chkPlacas" CssClass="control-input" runat="server" />
								<label class="form-label-xs" for="select2-data-remote">Placas</label>
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Fecha Ingreso RNVM</label>
							<asp:TextBox ID="txtFechaIngresoRNVM" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg " for="select2-data-remote">Observaciones</label>
							<asp:TextBox ID="txtObservaciones" CssClass="form-input-lg flatpickr-input" placeholder="" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Correlativo Entrega</label>
							<asp:TextBox ID="txtCorrelativoEntrega" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Folio</label>
							<asp:TextBox ID="txtFolio" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Estado Mera Tenencia</label>
							<asp:TextBox ID="txtEstadoMeraTenencia" CssClass="form-input-lg flatpickr-input" placeholder="" ReadOnly="true" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Valor Primera Inscripción</label>
							<asp:DropDownList ID="ddlValorPrimeraInscripcion" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Valor Tramita</label>
							<asp:DropDownList ID="ddlValorTramita" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Valor Servicio TAG</label>
							<asp:DropDownList ID="ddlValorServicioTAG" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Valor Notaria</label>
							<asp:DropDownList ID="ddlValorNotaria" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Valor Despacho Correo</label>
							<asp:DropDownList ID="ddlValorDespachoCorreo" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Fecha Ingreso TAG</label>
							<asp:TextBox ID="txtFechaIngresoTAG" CssClass="form-input-lg flatpickr-input" placeholder="" ReadOnly="true" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Formulario 88 (F88)</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkF88" CssClass="control-input" runat="server" />
								<asp:TextBox ID="txtValorF88" CssClass="form-input-md flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Fotocopia legalizada de cert. de cumplimiento ds 55/94</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkFotocopiaLegalizadaCert5594" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Fotocopia RUT Banco</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkFotocopiaRUTBanco" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Certificado DS 55/94 /Homologación	</label>
							<asp:CheckBox ID="chk1U" CssClass="control-input form-label-xs" Text="1 U." runat="server" />
							<asp:CheckBox ID="chk2U" CssClass="control-input form-label-xs" Text="2 U." runat="server" />
							<asp:CheckBox ID="chk3U" CssClass="control-input form-label-xs" Text="3 U." runat="server" />
							<asp:CheckBox ID="chk4U" CssClass="control-input form-label-xs" Text="4 U." runat="server" />
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Solicitud de 1a.Inscripción	</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkSolicitudPrimeraInscripcion" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Certificado de Leasing</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkCertificadoLeasing" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Certificado Combustibles</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkCertificadoCombustibles" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Contrato Televia</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkContratoTelevia" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Convenio PAC</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkConvenioPAC" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Dispositivo Televia</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkDispositivoTelevia" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Contrato leasing</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkContratoLeasing" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Padron</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkPadron" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Pendiente Contrato</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkPendienteContrato" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Pendiente Anotación Mera Tenencia</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkPendienteAnotacionMeraTenencia" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Despacho Externo</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkDespachoExterno" CssClass="control-input" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Informativo Seguro</label>
							<div style="text-align: center; display: inline; margin-top: 15px; vertical-align: middle;">
								<asp:CheckBox ID="chkInformativoSeguro" CssClass="control-input" runat="server" />
							</div>
						</div>
						<!-- /form -->
					</div>
					<!-- /.card-body -->
				</section>
				<!-- /.Datos Tramita -->
			</div>
			<!-- /.section-deck -->
			<!-- .section-deck -->
			<div class="section-deck">
				<!-- .Datos Vehiculo -->
				<section class="card card-fluid">
					<!-- .card-body -->
					<div class="card-body">
						<h4 class="card-title">Datos Vehiculo</h4>
						<h6 class="card-subtitle mb-4"></h6>
						<!-- form -->
						<div class="form-group">
							<asp:TextBox ID="txtVehiculoID" Visible="false" runat="server" BorderColor="Red"></asp:TextBox>
							<label class="form-label-lg" for="select2-data-remote">Tipo Vehículo</label>
							<asp:DropDownList ID="ddlTipoVehiculo" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Marca</label>
							<asp:DropDownList ID="ddlMarca" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Modelo</label>
							<asp:DropDownList ID="ddlModelo" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Año Fabricación</label>
							<asp:TextBox ID="txtAnoFabricacion" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Color</label>
							<asp:DropDownList ID="ddlColor" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Puertas</label>
							<asp:DropDownList ID="ddlPuertas" CssClass="form-input-lg" runat="server">
								<asp:ListItem Value="-1" Text="--- SELECCIONE ---"></asp:ListItem>
								<asp:ListItem Value="1" Text="1"></asp:ListItem>
								<asp:ListItem Value="2" Text="2"></asp:ListItem>
								<asp:ListItem Value="3" Text="3"></asp:ListItem>
								<asp:ListItem Value="4" Text="4"></asp:ListItem>
								<asp:ListItem Value="5" Text="5"></asp:ListItem>
								<asp:ListItem Value="6" Text="6"></asp:ListItem>
								<asp:ListItem Value="7" Text="7"></asp:ListItem>
								<asp:ListItem Value="8" Text="8"></asp:ListItem>
								<asp:ListItem Value="9" Text="9"></asp:ListItem>
								<asp:ListItem Value="10" Text="10"></asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Asientos</label>
							<asp:DropDownList ID="ddlAsientos" CssClass="form-input-lg" runat="server">
								<asp:ListItem Value="-1" Text="--- SELECCIONE ---"></asp:ListItem>
								<asp:ListItem Value="1" Text="1"></asp:ListItem>
								<asp:ListItem Value="2" Text="2"></asp:ListItem>
								<asp:ListItem Value="3" Text="3"></asp:ListItem>
								<asp:ListItem Value="4" Text="4"></asp:ListItem>
								<asp:ListItem Value="5" Text="5"></asp:ListItem>
								<asp:ListItem Value="6" Text="6"></asp:ListItem>
								<asp:ListItem Value="7" Text="7"></asp:ListItem>
								<asp:ListItem Value="8" Text="8"></asp:ListItem>
								<asp:ListItem Value="9" Text="9"></asp:ListItem>
								<asp:ListItem Value="10" Text="10"></asp:ListItem>
								<asp:ListItem Value="11" Text="11"></asp:ListItem>
								<asp:ListItem Value="12" Text="12"></asp:ListItem>
								<asp:ListItem Value="13" Text="13"></asp:ListItem>
								<asp:ListItem Value="14" Text="14"></asp:ListItem>
								<asp:ListItem Value="15" Text="15"></asp:ListItem>
								<asp:ListItem Value="16" Text="16"></asp:ListItem>
								<asp:ListItem Value="17" Text="17"></asp:ListItem>
								<asp:ListItem Value="18" Text="18"></asp:ListItem>
								<asp:ListItem Value="19" Text="19"></asp:ListItem>
								<asp:ListItem Value="20" Text="20"></asp:ListItem>
								<asp:ListItem Value="21" Text="21"></asp:ListItem>
								<asp:ListItem Value="22" Text="22"></asp:ListItem>
								<asp:ListItem Value="23" Text="23"></asp:ListItem>
								<asp:ListItem Value="24" Text="24"></asp:ListItem>
								<asp:ListItem Value="25" Text="25"></asp:ListItem>
								<asp:ListItem Value="26" Text="26"></asp:ListItem>
								<asp:ListItem Value="27" Text="27"></asp:ListItem>
								<asp:ListItem Value="28" Text="28"></asp:ListItem>
								<asp:ListItem Value="29" Text="29"></asp:ListItem>
								<asp:ListItem Value="30" Text="30"></asp:ListItem>
								<asp:ListItem Value="31" Text="31"></asp:ListItem>
								<asp:ListItem Value="32" Text="32"></asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Número Motor</label>
							<asp:TextBox ID="txtNroMotor" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Número Chasis</label>
							<asp:TextBox ID="txtNroChasis" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>

						<!-- /form -->
					</div>
					<!-- /.card-body -->
				</section>
				<!-- /.Datos Vehiculo -->
				<!-- .Datos del Vehículo -->
				<section class="card card-fluid">
					<!-- .card-body -->
					<div class="card-body">
						<h4 class="card-title">Datos del Vehículo</h4>
						<h6 class="card-subtitle mb-4"></h6>
						<!-- form -->
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Número VIN </label>
							<asp:TextBox ID="txtNroVin" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<div class="form-group">
							</div>
							<label class="form-label-lg" for="select2-data-remote">Combustible</label>
							<asp:DropDownList ID="ddlCombustible" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Carga</label>
							<asp:TextBox ID="txtCarga" CssClass="form-input-xs flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<asp:DropDownList ID="ddlUnidadCarga" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Peso Bruto</label>
							<asp:TextBox ID="txtPesoBruto" CssClass="form-input-xs flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<asp:DropDownList ID="ddlUnidadPeso" CssClass="form-input-lg" runat="server">
								<asp:ListItem Value="-1" Text="-- UNIDAD PESO --"></asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Tracción</label>
							<asp:DropDownList ID="ddlTraccion" CssClass="form-input-lg" runat="server">
								<asp:ListItem Value="-1" Text="-- UNIDAD TRACCCION --"></asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Potencia Motor</label>
							<asp:TextBox ID="txtPotenciaMotor" CssClass="form-input-xs flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<asp:DropDownList ID="ddlUnidadPotencia" CssClass="form-input-lg" runat="server">
								<asp:ListItem Value="-1" Text="-- UNIDAD POTENCIA--"></asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Carrocería</label>
							<asp:DropDownList ID="ddlCarroceria" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Otra Carrocería</label>
							<asp:TextBox ID="txtOtraCarrocería" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Número y Disposición Ejes</label>
							<asp:TextBox ID="txtNroDisposicionEjes" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Código C.I.T.</label>
							<asp:TextBox ID="txtCodigoCITVehiculo" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<!-- /form -->
					</div>
					<!-- /.card-body -->
				</section>
				<!-- /.Datos del Vehículo -->
			</div>
			<!-- /.section-deck -->
			<div class="section-deck">
				<section class="card card-fluid">
					<!-- .card-body -->
					<div class="card-body">
						<h4 class="card-title">Datos del Adquirente o Nuevo Propietario</h4>
						<h6 class="card-subtitle mb-4"></h6>
						<!-- form -->
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">RUT</label>
							<asp:TextBox ID="txtAdquirenteID" Style="display: none;" runat="server" BorderColor="Red"></asp:TextBox>
							<asp:TextBox ID="txtRutAdquirente" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<button class="btn-xs btn-primary" onclick="return(BuscaPersona($('#txtRutAdquirente'), $('#txtAdquirenteID'), $('#txtNombreRazonSocialAdquirente')));">
								<span class="oi oi-magnifying-glass mr-1"></span>
							</button>

						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Razón Social/Nombre	</label>
							<asp:TextBox ID="txtNombreRazonSocialAdquirente" CssClass="form-input-xxl" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Dirección Adquirente</label>
							<label class="form-label-sm" for="select2-data-remote" style="margin-left: 25px">Número</label>
							<label class="form-label-md" for="select2-data-remote" style="margin-left: 47px">Complemento</label>
						</div>
						<div class="form-group">
							<asp:TextBox ID="txtDireccionAdquirenteID" Visible="false" runat="server" BorderColor="Red"></asp:TextBox>
							<asp:TextBox ID="txtDireccionAdquirente" CssClass="form-input-lg flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<asp:TextBox ID="txtNumeroDireccionAdquirente" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
							<asp:TextBox ID="txtComplementoDireccionAdquirente" CssClass="form-input-sm flatpickr-input" placeholder="" runat="server"></asp:TextBox>
						</div>
						<div class="form-group">
							<label class="form-label-lg" for="select2-data-remote">Comuna</label>
							<label class="form-label-sm" for="select2-data-remote" style="margin-left: 30px">Ciudad</label>
						</div>
						<div class="form-group">
							<asp:DropDownList ID="ddlComunaAdquirente" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
							<asp:DropDownList ID="ddlCiudadAdquirente" CssClass="form-input-lg" runat="server">
							</asp:DropDownList>
						</div>
						<!-- /form -->
					</div>
				</section>
				<!-- /.card -->
			</div>
			<!-- /.section-deck -->
			<!-- /.section-deck -->
			<div class="section-deck">
				<section class="card card-fluid">
					<!-- .card-body -->
					<div class="card-body">
						<h4 class="card-title">Documentos Recibidos</h4>
						<h6 class="card-subtitle mb-4"></h6>
						<!-- form -->
						<div>
							<div>
								<div class="btn-group">
									<button class="btn bg-warning" onclick="return( NuevoDocumentoRecibido());">
										<span class="oi oi-plus"></span>
									</button>
								</div>
							</div>
							<asp:GridView ID="grvDocuemntosRecibidos" CssClass="table-responsive table table-hover table-striped" HeaderStyle-CssClass="thead-dark" UseAccessibleHeader="true" GridLines="None" AutoGenerateColumns="False" runat="server">

								<Columns>
									<asp:TemplateField HeaderText="Edit">
										<ItemTemplate>
											<button class="btn-xs  btn-primary" onclick="return( editaDoctosRecibidos('<%# Eval("id")%>'));">
												<span class="oi oi-pencil"></span>
											</button>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="documentoRecibidoID" HeaderText="documentoRecibidoID" Visible="false" />
									<asp:BoundField DataField="tipoDocumento" HeaderText="Tipo Documento" />
									<asp:BoundField DataField="nroDocumentoCausa" HeaderText="Nro.Documento" />
									<asp:BoundField DataField="rutEmisorDocumento" HeaderText="RUT Emisor" />
									<asp:BoundField DataField="NombreRazonSocialEmisorDocumento" HeaderText="Nombre/Razón Social Emisor" />
									<asp:BoundField DataField="fechaDocumento" HeaderText="Fecha Documento" />
									<asp:TemplateField>
										<ItemTemplate>
											<div class="btn-group">
												<button class="btn-xs btn-primary">
													<span class="oi oi-data-transfer-download mr-1"></span>
												</button>
											</div>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
						</div>

						<div id="modalDoctosRecibidos" class="modal">
							<div class="modal-content">
								<span id="closeModalDoctosRecibidos" class="close" style="text-align: right"><i class="fa fa-times text-red"></i></span>


								<div id="DoctosRecibidosHeader">

									<h1 class="page-title">DOCUMENTOS RECIBIDOS</h1>
									<asp:TextBox ID="txtDocumentoRecibidoID" Text="" Style="display: none; border-color: red;" placeholder="" runat="server"></asp:TextBox>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Tipo Documento</label>
										<asp:DropDownList ID="ddlTipoDocumento" DataValueField="ID" DataTextField="tipoDocumento" CssClass="form-input-lg" runat="server">
										</asp:DropDownList>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Naturaleza Adquisición</label>
										<asp:TextBox ID="txtNaturalezaAdquisición" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Número Documento/Causa</label>
										<asp:TextBox ID="txtNroDocumentoCausa" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">RUT Documento</label>
										<asp:TextBox ID="txtEmisorDocumentoID" Style="display: none;" runat="server" BorderColor="Red"></asp:TextBox>
										<asp:TextBox ID="txtRutDocumento" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
										<button class="btn-xs btn-primary" onclick="return(BuscaPersona($('#txtRutDocumento'), $('#txtEmisorDocumentoID'), $('#txtRazonSocialEmisorDocumento')));">
											<span class="oi oi-magnifying-glass mr-1"></span>
										</button>

									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Razón Social Proveedor</label>
										<asp:TextBox ID="txtRazonSocialEmisorDocumento" CssClass="form-input-xl" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Valor Neto Factura</label>
										<asp:TextBox ID="txtValorNetoFactura" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Valor IVA Factura</label>
										<asp:TextBox ID="txtValorIvaFactura" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Valor Total Factura</label>
										<asp:TextBox ID="txtValorTotalFactura" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Lugar Documento</label>
										<asp:TextBox ID="txtLugarDocumento" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Fecha Documento</label>
										<asp:TextBox ID="txtFechaDocumento" CssClass="form-input-sm" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Nombre Autorizante</label>
										<asp:TextBox ID="txtNombreAutorizante" CssClass="form-input-xl" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Acreedor/Beneficiario/Demandante</label>
										<asp:TextBox ID="txtAcreedorBeneficiarioDemandante" CssClass="form-input-xl" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">PDF</label>
										<asp:TextBox ID="txtPDFDocumento" CssClass="form-input-lg" placeholder="" runat="server"></asp:TextBox>
										<button class="btn-xs btn-primary">
											<span class="oi oi-data-transfer-download mr-1"></span>
										</button>
									</div>
									<div class="form-group">
										<asp:Button ID="btnGrabarDoctosRecibidos" Text="Grabar" CssClass="btn btn-primary" OnClick="btnGrabarDoctosRecibidos_OnClick" runat="server" />
									</div>
								</div>
							</div>
						</div>

					</div>
				</section>
			</div>
			<!-- /.section-deck -->
			<div class="section-deck">
				<section class="card card-fluid">
					<!-- .card-body -->
					<div class="card-body">
						<h4 class="card-title">Despachos</h4>
						<h6 class="card-subtitle mb-4"></h6>
						<!-- form -->

						<div>
							<div class="btn-group">
								<button id="OpenModalCreaDespacho" class="btn bg-warning" onclick="return( NuevoDespacho());">
									<span class="oi oi-plus"></span>
								</button>
							</div>
						</div>
						<div>
							<asp:GridView ID="grvDespachos" CssClass="table-responsive table table-hover table-striped" HeaderStyle-CssClass="thead-dark" UseAccessibleHeader="true" GridLines="None" AutoGenerateColumns="False" runat="server">

								<Columns>
									<asp:TemplateField HeaderText="Edit">
										<ItemTemplate>

											<button class="btn-xs  btn-primary" onclick="return( editaDespachos('<%# Eval("despachoID")%>'));">
												<span class="oi oi-pencil"></span>
											</button>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="depsachoID" HeaderText="DespachoID" Visible="false" />
									<asp:BoundField DataField="Item" HeaderText="Item" />
									<asp:BoundField DataField="ServicioCourier" HeaderText="Courier" />
									<asp:BoundField DataField="Origen" HeaderText="Origen" />
									<asp:BoundField DataField="codigoDespachoCourier" HeaderText="Código Despacho" />
									<asp:BoundField DataField="fechaRecepcion" HeaderText="Fecha Recepcion" />
									<asp:BoundField DataField="fechaEntrega" HeaderText="Fecha Entrega" />
									<asp:TemplateField>
										<ItemTemplate>
											<div class="btn-group">
												<button class="btn-xs btn-primary">
													<span class="oi oi-data-transfer-download mr-1"></span>
												</button>
											</div>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
						</div>

						<div id="modalDespacho" class="modal">
							<div class="modal-content">
								<span id="closeModalDespacho" class="close" style="text-align: right"><i class="fa fa-times text-red"></i></span>


								<div id="DespachosHeader">
									<h1 class="page-title">DESPACHOS</h1>
									<asp:TextBox ID="txtDespachoID" Text="" style="display:none;border-color:red" placeholder="" runat="server"></asp:TextBox>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Item</label>
										<asp:DropDownList ID="ddlItem" CssClass="form-input-lg" runat="server">
										</asp:DropDownList>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Courier</label>
										<asp:DropDownList ID="ddlCourier" CssClass="form-input-lg" runat="server">
										</asp:DropDownList>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Origen</label>
										<asp:TextBox ID="txtOrigenDespacho" CssClass="form-input-lg" placeholder="" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Solicita Despacho</label>
										<asp:CheckBox ID="chkSolicitaDespacho" CssClass="control-input" runat="server" />
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Imprimir para entrega</label>
										<asp:CheckBox ID="chkImprimirParaEntrega" CssClass="control-input" runat="server" />
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Entrega efectuada</label>
										<asp:CheckBox ID="chkEntregaEfectuada" CssClass="control-input" runat="server" />
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Observaciones</label>
										<asp:TextBox ID="txtObservacionesEntrega" CssClass="form-input-lg flatpickr-input" placeholder="" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Fecha Recepcion</label>
										<asp:TextBox ID="txtFechaRecepcionDespacho" CssClass="form-input-lg flatpickr-input" placeholder="" ReadOnly="true" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Fecha Entrega</label>
										<asp:TextBox ID="txtFechaEntregaDespacho" CssClass="form-input-lg flatpickr-input" placeholder="" ReadOnly="true" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Fecha Recepcion Chilexpress</label>
										<asp:TextBox ID="txtFechaRecepcionCHXP" CssClass="form-input-lg flatpickr-input" placeholder="" ReadOnly="true" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Fecha Entrega Chilexpress</label>
										<asp:TextBox ID="txtFechaEntregaCHXP" CssClass="form-input-lg flatpickr-input" placeholder="" ReadOnly="true" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">Código Despacho Chilexpress</label>
										<asp:TextBox ID="txtCodigoDespachoCHPX" CssClass="form-input-lg flatpickr-input" placeholder="" ReadOnly="true" runat="server"></asp:TextBox>
									</div>
									<div class="form-group">
										<label class="form-label-lg" for="select2-data-remote">PDF Entrega</label>
										<asp:TextBox ID="txtPDFEntrega" CssClass="form-input-lg" placeholder="" runat="server"></asp:TextBox>
										<button class="btn-xs btn-primary">
											<span class="oi oi-data-transfer-download mr-1"></span>
										</button>
									</div>
									<div class="form-group d-flex justify-content-center">
										<asp:Button ID="btnGrabarDespacho" Text="Grabar" CssClass="btn btn-primary" OnClick="btnGrabarDespacho_OnClick" runat="server" />
									</div>
								</div>
							</div>
						</div>
					</div>

				</section>
			</div>
			<div class="section-deck">
				<section class="card card-fluid">
					<div class="card-body text-right">
						<asp:Button ID="btnGrabarPrimera" Text="Grabar" CssClass="btn btn-primary" OnClick="btnGrabarPrimera_Click" runat="server" />
						<asp:Button ID="btnNuevo" Text="Nuevo" CssClass="btn btn btn-primary" OnClick="btnNuevoPrimera_Click" runat="server" />
						<asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminarPrimera_Click" runat="server" />
						<asp:Button ID="btnSalir" Text="Salir" CssClass="btn btn btn-primary" OnClick="btnSalirPrimera_Click" runat="server" />
					</div>
				</section>
			</div>
			<!-- /.section-deck -->
		</div>

		<!-- /.page-section -->
	</div>
	<script type="text/javascript">
		function toggleDoctosRecibidosModal() {
			var modal = document.getElementById("modalDoctosRecibidos");
			modal.style.display = "block";

			var span = document.getElementById("closeModalDoctosRecibidos");

			span.onclick = function () {
				modal.style.display = "none";
			}

			return false;
		}

		function toggleDespachoModal() {
			var modal = document.getElementById("modalDespacho");
			modal.style.display = "block";

			var span = document.getElementById("closeModalDespacho");

			span.onclick = function () {
				modal.style.display = "none";
			}


			return false;
		}


		window.onclick = function (event) {
			if (event.target == modal) {
				modal.style.display = "none";
			}
		}

	</script>

</asp:Content>

