using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using DataLayer;
using Models;
using System.Diagnostics.Contracts;

public partial class primera_inscripcion : System.Web.UI.Page
{
	string EmpresaID = "";
	HttpCookie userInfo = new HttpCookie("CoreInfo");
	int UserID = 0;

	protected void Page_Load(object sender, EventArgs e)
	{
		MasterPage master = new MasterPage();
		master = this.Master;
		DropDownList cmbEmpresas = master.FindControl("cmbEmpresas") as DropDownList;
		EmpresaID = cmbEmpresas.SelectedValue;

		userInfo = Request.Cookies["CoreInfo"];
		if (userInfo != null)
		{
			UserID = int.Parse(Utilities.cipher.DecryptString(userInfo["model"].ToString()));

		}



		if (!Page.IsPostBack)
		{
			LlenaDDLsGenerales();
			//preLlenaDocumentosDespachos();
		}
	}

	protected void btnBuscar_Click(object sender, EventArgs e)
	{
		string PrimeraInscripcionID = "";
		if (!(txtPPUBuscar.Text == "" && txtNroFactura.Text == "" && txtRUTFacturaBuscar.Text == ""))
		{
			DataTable dtDatos = PrimeraInscripcion.SEL_PrimeraInscripcion(EmpresaID, (txtPrimeraInscripcionID.Text == "" ? "0" : txtPrimeraInscripcionID.Text), txtPPUBuscar.Text, txtNroFacturaBuscar.Text, txtRUTFacturaBuscar.Text);

			if (dtDatos.Rows.Count > 0)
			{
				#region -- DATOSTRAMITA 1 --

				string VehiculoID = "0";


				PrimeraInscripcionID = dtDatos.Rows[0]["PrimeraInscripcionID"].ToString();
				txtPPU.Text = dtDatos.Rows[0]["PPU"].ToString();
				//				txtDVPPU.Text = dtDatos.Rows[0]["DVPPU"].ToString();
				ddlEstado.SelectedValue = dtDatos.Rows[0]["EstadoID"].ToString();
				txtNroOperacion.Text = dtDatos.Rows[0]["NumeroOperacion"].ToString();
				txtOrigen.Text = dtDatos.Rows[0]["Origen"].ToString();
				//txtCodigoCIT.Text= dtDatos.Rows[0]["CodigoCIT"].ToString();
				txtNroFactura.Text = dtDatos.Rows[0]["NumeroFactura"].ToString();
				txtVencimientoContratoLeasing.Text = dtDatos.Rows[0]["vencimientoContratoLeasing"].ToString();

				txtRUTCliente.Text = dtDatos.Rows[0]["RutCliente"].ToString();
				txtNombreRazonSocialCliente.Text = dtDatos.Rows[0]["nombreRazonSocialCliente"].ToString();
				txtDireccionCliente.Text = dtDatos.Rows[0]["DireccionCliente"].ToString();
				txtNumeroDireccionCliente.Text = dtDatos.Rows[0]["NroDireccionCliente"].ToString();
				txtComplementoDireccionCliente.Text = dtDatos.Rows[0]["ComplementoDireccionCliente"].ToString();
				ddlComunaCliente.SelectedValue = dtDatos.Rows[0]["ComunaIDRepresentanteLegal"].ToString();
				ddlCiudadCliente.SelectedValue = dtDatos.Rows[0]["CiudadIDRepresentanteLegal"].ToString();



				// Datos representante legal
				txtRUTRepresentanteLegal.Text = dtDatos.Rows[0]["rutRepresentanteLegal"].ToString();
				txtNombreRepresentanteLegal.Text = dtDatos.Rows[0]["nombreRazonSocialRepresentanteLegal"].ToString();


				txtContacto.Text = dtDatos.Rows[0]["Contacto"].ToString();
				txtTelefonoContacto.Text = dtDatos.Rows[0]["TelefonoContacto"].ToString();
				txtEmailContacto.Text = dtDatos.Rows[0]["EmailContacto"].ToString();
				txtNroSolicitud.Text = dtDatos.Rows[0]["numeroSolicitud"].ToString();
				ddlOficinas.SelectedValue = dtDatos.Rows[0]["OficinaID"].ToString();
				txtFechaSolicitudRNVM.Text = dtDatos.Rows[0]["fechaSolicitudRnvm"].ToString();
				chkRUT.Checked = bool.Parse(dtDatos.Rows[0]["chkRUT"].ToString());
				chkEC.Checked = bool.Parse(dtDatos.Rows[0]["chkEC"].ToString());
				chkCI.Checked = bool.Parse(dtDatos.Rows[0]["chkCI"].ToString());
				txtNroValija.Text = dtDatos.Rows[0]["NumeroValija"].ToString();
				txtEjecutivo.Text = dtDatos.Rows[0]["Ejecutivo"].ToString();
				txtSucursal.Text = dtDatos.Rows[0]["sucursal"].ToString();

				#endregion -- DATOSTRAMITA 1 --

				#region -- DATOSTRAMITA 2 --
				ddlAnoProceso.SelectedValue = dtDatos.Rows[0]["AnoProceso"].ToString();
				txtFechaRecepcionBanco.Text = dtDatos.Rows[0]["FechaRecepcionBanco"].ToString();
				txtFechaPadron.Text = dtDatos.Rows[0]["FechaPadron"].ToString();
				txtCodigoDespachoCorreo.Text = dtDatos.Rows[0]["CodigoDespachoCorreo"].ToString();
				ddlObservacionEntrega.SelectedValue = dtDatos.Rows[0]["observacionId"].ToString();
				ddlNroPlacas.SelectedValue = dtDatos.Rows[0]["NumeroPlacas"].ToString();
				chkTAG.Checked = bool.Parse(dtDatos.Rows[0]["chkTAG"].ToString());
				chkPlacas.Checked = bool.Parse(dtDatos.Rows[0]["chkPlacas"].ToString());
				txtFechaIngresoRNVM.Text = dtDatos.Rows[0]["FechaIngresoRNVM"].ToString();
				txtObservaciones.Text = dtDatos.Rows[0]["Observaciones"].ToString();
				txtCorrelativoEntrega.Text = dtDatos.Rows[0]["CorrelativoEntrega"].ToString();
				txtFolio.Text = dtDatos.Rows[0]["Folio"].ToString();
				txtEstadoMeraTenencia.Text = "PENDIENTE**";
				ddlValorPrimeraInscripcion.SelectedValue = dtDatos.Rows[0]["ValorPrimeraInscripcionID"].ToString();
				ddlValorTramita.SelectedValue = dtDatos.Rows[0]["valorTramitaId"].ToString();
				ddlValorServicioTAG.SelectedValue = dtDatos.Rows[0]["ValorServicioTAGID"].ToString();
				ddlValorNotaria.SelectedValue = dtDatos.Rows[0]["ValorNotariaID"].ToString();
				ddlValorDespachoCorreo.SelectedValue = dtDatos.Rows[0]["ValorDespachoCorreoID"].ToString();
				txtFechaIngresoTAG.Text = dtDatos.Rows[0]["FechaIngresoTAG"].ToString();
				chkF88.Checked = bool.Parse(dtDatos.Rows[0]["F88"].ToString());
				txtValorF88.Text = dtDatos.Rows[0]["ValorF88"].ToString();
				chkFotocopiaLegalizadaCert5594.Checked = bool.Parse(dtDatos.Rows[0]["flCertCum5594"].ToString());
				chkFotocopiaRUTBanco.Checked = bool.Parse(dtDatos.Rows[0]["fotocopiaRutBanco"].ToString());
				chk1U.Checked = bool.Parse(dtDatos.Rows[0]["chk1U"].ToString());
				chk2U.Checked = bool.Parse(dtDatos.Rows[0]["chk2U"].ToString());
				chk3U.Checked = bool.Parse(dtDatos.Rows[0]["chk3U"].ToString());
				chk4U.Checked = bool.Parse(dtDatos.Rows[0]["chk4U"].ToString());
				chkSolicitudPrimeraInscripcion.Checked = bool.Parse(dtDatos.Rows[0]["solicitudPrimeraInscripcion"].ToString());
				chkCertificadoLeasing.Checked = bool.Parse(dtDatos.Rows[0]["certificadoLeasing"].ToString());
				chkCertificadoCombustibles.Checked = bool.Parse(dtDatos.Rows[0]["certificadoCombustibles"].ToString());
				chkContratoTelevia.Checked = bool.Parse(dtDatos.Rows[0]["contratoTelevia"].ToString());
				chkConvenioPAC.Checked = bool.Parse(dtDatos.Rows[0]["convenioPac"].ToString());
				chkDispositivoTelevia.Checked = bool.Parse(dtDatos.Rows[0]["dispositivoTelevia"].ToString());
				chkContratoLeasing.Checked = bool.Parse(dtDatos.Rows[0]["contratoLeasing"].ToString());
				chkPadron.Checked = bool.Parse(dtDatos.Rows[0]["padron"].ToString());
				chkPendienteContrato.Checked = bool.Parse(dtDatos.Rows[0]["pendienteContrato"].ToString());
				chkPendienteAnotacionMeraTenencia.Checked = bool.Parse(dtDatos.Rows[0]["pendienteAnotacionMeraTenencia"].ToString());
				chkDespachoExterno.Checked = bool.Parse(dtDatos.Rows[0]["despachoExterno"].ToString());
				chkInformativoSeguro.Checked = bool.Parse(dtDatos.Rows[0]["informativoSeguro"].ToString());


				VehiculoID = dtDatos.Rows[0]["vehiculoID"].ToString();


				#endregion -- DATOSTRAMITA 2 --

				#region -- DATOS ADQUIRENTE --
				// Datos Adquiernte
				txtRutAdquirente.Text = dtDatos.Rows[0]["RutAdquirente"].ToString();
				txtNombreRazonSocialAdquirente.Text = dtDatos.Rows[0]["nombreRazonSocialAdquirente"].ToString();
				txtDireccionAdquirente.Text = dtDatos.Rows[0]["DireccionAdquirente"].ToString();
				txtNumeroDireccionAdquirente.Text = dtDatos.Rows[0]["NroDireccionAdquirente"].ToString();
				txtComplementoDireccionAdquirente.Text = dtDatos.Rows[0]["ComplementoDireccionAdquirente"].ToString();
				ddlComunaAdquirente.SelectedValue = dtDatos.Rows[0]["ComunaIDAdquirente"].ToString();
				ddlCiudadAdquirente.SelectedValue = dtDatos.Rows[0]["CiudadIDAdquirente"].ToString();
				#endregion -- DATOS ADQUIRENTE --


				#region -- DATOS VEHICULO --
				if (VehiculoID != "0")
				{
					DataTable dtDatosVehiculo = Vehiculos.SEL_VEHICULOS(VehiculoID);
					if (dtDatosVehiculo.Rows.Count > 0)
					{
						ddlTipoVehiculo.SelectedValue = dtDatosVehiculo.Rows[0]["tipoVehiculoId"].ToString();
						ddlMarca.SelectedValue = dtDatosVehiculo.Rows[0]["MarcaId"].ToString();
						ddlModelo.SelectedValue = dtDatosVehiculo.Rows[0]["ModeloId"].ToString();
						txtAnoFabricacion.Text = dtDatosVehiculo.Rows[0]["AnoFabricacion"].ToString();
						ddlColor.SelectedValue = dtDatosVehiculo.Rows[0]["ColorId"].ToString();
						ddlPuertas.SelectedValue = dtDatosVehiculo.Rows[0]["Puertas"].ToString();
						ddlAsientos.SelectedValue = dtDatosVehiculo.Rows[0]["Asientos"].ToString();
						txtCarga.Text = dtDatosVehiculo.Rows[0]["carga"].ToString();
						ddlUnidadCarga.SelectedValue = dtDatosVehiculo.Rows[0]["unidadCargaId"].ToString();
						txtPesoBruto.Text = dtDatosVehiculo.Rows[0]["pesoBruto"].ToString();
						ddlUnidadPeso.SelectedValue = dtDatosVehiculo.Rows[0]["unidadPesoId"].ToString();
						txtPotenciaMotor.Text = dtDatosVehiculo.Rows[0]["PotenciaMotor"].ToString();
						ddlUnidadPotencia.SelectedValue = dtDatosVehiculo.Rows[0]["unidadPotenciaId"].ToString();
						ddlTraccion.SelectedValue = dtDatosVehiculo.Rows[0]["TraccionID"].ToString();
						txtNroMotor.Text = dtDatosVehiculo.Rows[0]["NroMotor"].ToString();
						txtNroChasis.Text = dtDatosVehiculo.Rows[0]["NroChasis"].ToString();
						txtNroVin.Text = dtDatosVehiculo.Rows[0]["NroVin"].ToString();
						txtOtraCarrocería.Text = dtDatosVehiculo.Rows[0]["OtraCarroceria"].ToString();
						txtNroDisposicionEjes.Text = dtDatosVehiculo.Rows[0]["nroEjesDisponibles"].ToString();
						ddlCarroceria.SelectedValue = dtDatosVehiculo.Rows[0]["carroceriaId"].ToString();
						txtCodigoCIT.Text = dtDatosVehiculo.Rows[0]["CodigoCIT"].ToString();
						txtCodigoCITVehiculo.Text = dtDatosVehiculo.Rows[0]["CodigoCIT"].ToString();
					}
				}

				#endregion -- DATOS VEHICULO --
				#region -- DATOS DOCUMENTOS_RECIBIDOS --
				LlenaDocumentosDespachos(PrimeraInscripcionID);
				LlenaDespachos(PrimeraInscripcionID);
				#endregion -- DATOS DOCUMENTOS_RECIBIDOS --

			}

		}
	}

	protected void LlenaDDLsGenerales()
	{

		DataSet dsAll = Comun.SEL_ALL_ds();

		ddlEstado.DataValueField = "id";
		ddlEstado.DataTextField = "estado";
		ddlEstado.DataSource = dsAll.Tables[Comun.Tablas.ESTADOSREGISTRO];
		ddlEstado.DataBind();
		ddlEstado.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));


		ddlComunaCliente.DataValueField = "id";
		ddlComunaCliente.DataTextField = "comuna";
		ddlComunaCliente.DataSource = dsAll.Tables[Comun.Tablas.COMUNAS];
		ddlComunaCliente.DataBind();
		ddlComunaCliente.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));

		ddlCiudadCliente.DataValueField = "id";
		ddlCiudadCliente.DataTextField = "ciudad";
		ddlCiudadCliente.DataSource = dsAll.Tables[Comun.Tablas.CIUDADES];
		ddlCiudadCliente.DataBind();
		ddlCiudadCliente.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));


		ddlOficinas.DataValueField = "id";
		ddlOficinas.DataTextField = "Oficina";
		ddlOficinas.DataSource = dsAll.Tables[Comun.Tablas.OFICINAS];
		ddlOficinas.DataBind();
		ddlOficinas.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));




		ddlComunaAdquirente.DataValueField = "id";
		ddlComunaAdquirente.DataTextField = "comuna";
		ddlComunaAdquirente.DataSource = dsAll.Tables[Comun.Tablas.COMUNAS];
		ddlComunaAdquirente.DataBind();
		ddlComunaAdquirente.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));

		ddlCiudadAdquirente.DataValueField = "id";
		ddlCiudadAdquirente.DataTextField = "ciudad";
		ddlCiudadAdquirente.DataSource = dsAll.Tables[Comun.Tablas.CIUDADES];
		ddlCiudadAdquirente.DataBind();
		ddlCiudadAdquirente.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));



		ddlObservacionEntrega.DataValueField = "id";
		ddlObservacionEntrega.DataTextField = "observaciones";
		ddlObservacionEntrega.DataSource = dsAll.Tables[Comun.Tablas.OBSERVACIONES];
		ddlObservacionEntrega.DataBind();
		ddlObservacionEntrega.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));



		ddlTipoVehiculo.DataValueField = "id";
		ddlTipoVehiculo.DataTextField = "TipoVehiculo";
		ddlTipoVehiculo.DataSource = dsAll.Tables[Comun.Tablas.TIPOSVEHICULOS];
		ddlTipoVehiculo.DataBind();
		ddlTipoVehiculo.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));


		ddlMarca.DataValueField = "id";
		ddlMarca.DataTextField = "Marca";
		ddlMarca.DataSource = dsAll.Tables[Comun.Tablas.MARCAS];
		ddlMarca.DataBind();
		ddlMarca.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));


		ddlModelo.DataValueField = "id";
		ddlModelo.DataTextField = "Modelo";
		ddlModelo.DataSource = dsAll.Tables[Comun.Tablas.MODELOS];
		ddlModelo.DataBind();
		ddlModelo.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));


		ddlCarroceria.DataValueField = "id";
		ddlCarroceria.DataTextField = "carroceria";
		ddlCarroceria.DataSource = dsAll.Tables[Comun.Tablas.CARROCERIAS];
		ddlCarroceria.DataBind();
		ddlCarroceria.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));

		ddlColor.DataValueField = "id";
		ddlColor.DataTextField = "color";
		ddlColor.DataSource = dsAll.Tables[Comun.Tablas.COLORES];
		ddlColor.DataBind();
		ddlColor.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));

		ddlAnoProceso.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));
		int rlinea = 1;
		for (int i = DateTime.Now.Year + 1; i >= DateTime.Now.Year; i--)
		{
			ddlAnoProceso.Items.Insert(rlinea, new ListItem(i.ToString(), i.ToString()));
			rlinea++;
		}


		DataView dvFiltrado = new DataView(dsAll.Tables[Comun.Tablas.VALORESCOBRO]);
		dvFiltrado.RowFilter = "tipoCobro='PRIMERA INSCRIPCION'";

		ddlValorPrimeraInscripcion.DataValueField = "id";
		ddlValorPrimeraInscripcion.DataTextField = "valorCobro";
		ddlValorPrimeraInscripcion.DataTextFormatString = "{0:C}";
		ddlValorPrimeraInscripcion.DataSource = dvFiltrado;
		ddlValorPrimeraInscripcion.DataBind();
		ddlValorPrimeraInscripcion.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));

		dvFiltrado = new DataView(dsAll.Tables[Comun.Tablas.VALORESCOBRO]);
		dvFiltrado.RowFilter = "tipoCobro='TRAMITA'";

		ddlValorTramita.DataValueField = "id";
		ddlValorTramita.DataTextField = "valorCobro";
		ddlValorTramita.DataTextFormatString = "{0:C}";
		ddlValorTramita.DataSource = dvFiltrado;
		ddlValorTramita.DataBind();
		ddlValorTramita.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));


		dvFiltrado = new DataView(dsAll.Tables[Comun.Tablas.VALORESCOBRO]);
		dvFiltrado.RowFilter = "tipoCobro='VALOR TAG'";

		ddlValorServicioTAG.DataValueField = "id";
		ddlValorServicioTAG.DataTextField = "valorCobro";
		ddlValorServicioTAG.DataTextFormatString = "{0:C}";
		ddlValorServicioTAG.DataSource = dvFiltrado;
		ddlValorServicioTAG.DataBind();
		ddlValorServicioTAG.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));

		dvFiltrado = new DataView(dsAll.Tables[Comun.Tablas.VALORESCOBRO]);
		dvFiltrado.RowFilter = "tipoCobro='NOTARIA'";

		ddlValorNotaria.DataValueField = "id";
		ddlValorNotaria.DataTextField = "valorCobro";
		ddlValorNotaria.DataTextFormatString = "{0:C}";
		ddlValorNotaria.DataSource = dvFiltrado;
		ddlValorNotaria.DataBind();
		ddlValorNotaria.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));

		dvFiltrado = new DataView(dsAll.Tables[Comun.Tablas.VALORESCOBRO]);
		dvFiltrado.RowFilter = "tipoCobro='DESPACHO'";

		ddlValorDespachoCorreo.DataValueField = "id";
		ddlValorDespachoCorreo.DataTextField = "valorCobro";
		ddlValorDespachoCorreo.DataTextFormatString = "{0:N2}";
		ddlValorDespachoCorreo.DataSource = dvFiltrado;
		ddlValorDespachoCorreo.DataBind();
		ddlValorDespachoCorreo.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));


		ddlCombustible.DataValueField = "id";
		ddlCombustible.DataTextField = "Combustible";
		ddlCombustible.DataSource = dsAll.Tables[Comun.Tablas.COMBUSTIBLES];
		ddlCombustible.DataBind();
		ddlCombustible.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));


		ddlTraccion.DataValueField = "id";
		ddlTraccion.DataTextField = "Traccion";
		ddlTraccion.DataSource = dsAll.Tables[Comun.Tablas.TRACCION];
		ddlTraccion.DataBind();
		ddlTraccion.Items.Insert(0, new ListItem("--- SELECCIONE ---", "-1"));

		ddlUnidadCarga.DataValueField = "id";
		ddlUnidadCarga.DataTextField = "unidadMedida";
		ddlUnidadCarga.DataSource = dsAll.Tables[Comun.Tablas.UNIDADMEDIDA];
		ddlUnidadCarga.DataBind();
		ddlUnidadCarga.Items.Insert(0, new ListItem("--- UNIDAD CARGA ---", "-1"));

		ddlUnidadPeso.DataValueField = "id";
		ddlUnidadPeso.DataTextField = "unidadMedida";
		ddlUnidadPeso.DataSource = dsAll.Tables[Comun.Tablas.UNIDADMEDIDA];
		ddlUnidadPeso.DataBind();
		ddlUnidadPeso.Items.Insert(0, new ListItem("--- UNIDAD PESO---", "-1"));

		ddlUnidadPotencia.DataValueField = "id";
		ddlUnidadPotencia.DataTextField = "unidadMedida";
		ddlUnidadPotencia.DataSource = dsAll.Tables[Comun.Tablas.UNIDADMEDIDA];
		ddlUnidadPotencia.DataBind();
		ddlUnidadPotencia.Items.Insert(0, new ListItem("--- UNIDAD POTENCIA ---", "-1"));


		ddlTipoDocumento.DataSource = dsAll.Tables[Comun.Tablas.TIPOSDOCUMENTOS];
		ddlTipoDocumento.DataBind();



		return;
	}

	//public void preLlenaDocumentosDespachos()
	//{

	//	DataTable dtDatos = new DataTable();
	//	dtDatos.Clear();
	//	dtDatos.Columns.Add("Tipo");
	//	dtDatos.Columns.Add("Marks");
	//	DataRow _ravi = dtDatos.NewRow();
	//	_ravi["Tipo"] = "";
	//	_ravi["Marks"] = "";
	//	dtDatos.Rows.Add(_ravi);
	//	rptrDocumentosRecibidos.DataSource = dtDatos;
	//	rptrDocumentosRecibidos.DataBind();
	//	return;
	//}

	public void LlenaDocumentosDespachos(string PrimeraInscripcionID)
	{
		DataTable dtDatos = new DataTable();
		dtDatos = DocumentosRecibidos.SEL_DocumentosRecibidos("1");
		if (dtDatos.Rows.Count > 0)
		{
			grvDocuemntosRecibidos.DataSource = dtDatos;
			grvDocuemntosRecibidos.DataBind();
		}

		return;
	}

	public void LlenaDespachos(string PrimeraInscripcionID)
	{
		DataTable dtDatos = new DataTable();
		dtDatos = Despachos.SEL_Despachos("1");
		if (dtDatos.Rows.Count > 0)
		{
			grvDespachos.DataSource = dtDatos;
			grvDespachos.DataBind();
		}

		return;
	}

	protected void btnGrabarDoctosRecibidos_OnClick(object sender, EventArgs e)
	{

	}


	protected void btnGrabarDespacho_OnClick(object sender, EventArgs e)
	{

	}




	protected void btnGrabarPrimera_Click(object sender, EventArgs e)
	{


		#region CLIENTE
		PersonasEmpresasModel objPersona = new PersonasEmpresasModel();
		objPersona.PersonaEmpresaID = ClienteID.Text;
		objPersona.RUT = txtRUTCliente.Text;
		objPersona.NombreRazonSocial = txtNombreRazonSocialCliente.Text;
		objPersona.FonoContacto1 = txtTelefonoContacto.Text;
		objPersona.EMail = txtEmailContacto.Text;
		objPersona.Direccion = txtDireccionCliente.Text;
		objPersona.NroDireccion = txtNumeroDireccionCliente.Text;
		objPersona.ComplementoDireccion = txtComplementoDireccionCliente.Text;
		objPersona.ComunaID = ddlComunaCliente.SelectedValue;
		#endregion CLIENTE


		#region REPRESENTANTE LEGAL
		objPersona.PersonaEmpresaID = RepresentanteLegalID.Text;
		objPersona.RUT = txtRUTRepresentanteLegal.Text;
		objPersona.NombreRazonSocial = txtNombreRepresentanteLegal.Text;

		#endregion REPRESENTANTE LEGAL

		#region ADQUIRENTE
		objPersona.PersonaEmpresaID = AdquirenteID.Text;
		objPersona.RUT = txtRutAdquirente.Text;
		objPersona.NombreRazonSocial = txtNombreRazonSocialAdquirente.Text;
		objPersona.Direccion = txtDireccionAdquirente.Text;
		objPersona.NroDireccion = txtNumeroDireccionAdquirente.Text;
		objPersona.ComplementoDireccion = txtComplementoDireccionAdquirente.Text;
		objPersona.ComunaID = ddlComunaAdquirente.SelectedValue;
		#endregion ADQUIRENTE



		#region PRIMERA INSCRIPCION
		PrimeraInscripcionModel objprimeraInscripcion = new PrimeraInscripcionModel();

		objprimeraInscripcion.PrimeraInscripcionID = txtPrimeraInscripcionID.Text;
		objprimeraInscripcion.EmpresaID = EmpresaID;
		objprimeraInscripcion.PPU = txtPPU.Text;
		objprimeraInscripcion.NumeroOperacion = txtNroOperacion.Text;
		objprimeraInscripcion.Origen = txtOrigen.Text;
		objprimeraInscripcion.NumeroFactura = txtNroFactura.Text;
		objprimeraInscripcion.RutCliente = txtRUTCliente.Text;
		objprimeraInscripcion.VencimientoContratoLeasing = txtVencimientoContratoLeasing.Text;
		objprimeraInscripcion.NumeroSolicitud = txtNroSolicitud.Text;
		objprimeraInscripcion.TieneListadoPrimeraInscripcion = chkTieneListadoPrimeraInscripcion.Checked;
		objprimeraInscripcion.FechaSolicitudRNVM = txtFechaSolicitudRNVM.Text;
		objprimeraInscripcion.NumeroValija = txtNroValija.Text;
		objprimeraInscripcion.Ejecutivo = txtEjecutivo.Text;
		objprimeraInscripcion.Sucursal = txtSucursal.Text;
		objprimeraInscripcion.FechaRecepcionBanco = txtFechaRecepcionBanco.Text;
		objprimeraInscripcion.FechaPadron = txtFechaPadron.Text;
		objprimeraInscripcion.CodigoDespachoCorreo = txtCodigoDespachoCorreo.Text;
		objprimeraInscripcion.NumeroPlacas = ddlNroPlacas.SelectedValue;
		objprimeraInscripcion.FechaIngresoRNVM = txtFechaIngresoRNVM.Text;
		objprimeraInscripcion.Observaciones = txtObservaciones.Text;
		objprimeraInscripcion.CorrelativoEntrega = txtCorrelativoEntrega.Text;
		objprimeraInscripcion.Folio = txtFolio.Text;
		objprimeraInscripcion.FechaIngresoTAG = txtFechaIngresoTAG.Text;
		objprimeraInscripcion.F88 = chkF88.Checked;
		objprimeraInscripcion.ValorF88 = txtValorF88.Text;
		objprimeraInscripcion.FLCertCum5594 = chkFotocopiaLegalizadaCert5594.Checked;
		objprimeraInscripcion.FotocopiaRutBanco = chkFotocopiaRUTBanco.Checked;
		objprimeraInscripcion.chk1U = chk1U.Checked;
		objprimeraInscripcion.chk2U = chk2U.Checked;
		objprimeraInscripcion.chk3U = chk3U.Checked;
		objprimeraInscripcion.chk4U = chk4U.Checked;
		objprimeraInscripcion.SolicitudPrimeraInscripcion = chkSolicitudPrimeraInscripcion.Checked;
		objprimeraInscripcion.CertificadoLeasing = chkCertificadoLeasing.Checked;
		objprimeraInscripcion.CertificadoCombustibles = chkCertificadoCombustibles.Checked;
		objprimeraInscripcion.ContratoTelevia = chkContratoTelevia.Checked;
		objprimeraInscripcion.ConvenioPAC = chkConvenioPAC.Checked;
		objprimeraInscripcion.DispositivoTelevia = chkDispositivoTelevia.Checked;
		objprimeraInscripcion.ContratoLeasing = chkContratoLeasing.Checked;
		objprimeraInscripcion.Padron = chkPadron.Checked;
		objprimeraInscripcion.PendienteContrato = chkPendienteContrato.Checked;
		objprimeraInscripcion.PendienteAnotacionMeraTenencia = chkPendienteAnotacionMeraTenencia.Checked;
		objprimeraInscripcion.DespachoExterno = chkDespachoExterno.Checked;
		objprimeraInscripcion.InformativoSeguro = chkInformativoSeguro.Checked;
		objprimeraInscripcion.VehiculoID =
		objprimeraInscripcion.ComunaClienteID = ddlComunaCliente.SelectedValue;
		objprimeraInscripcion.EstadoID = ddlEstado.SelectedValue;
		objprimeraInscripcion.ObservacionID = ddlObservacionEntrega.SelectedValue;
		objprimeraInscripcion.UsuarioID = UserID.ToString();
		objprimeraInscripcion.ValorPrimeraInscripcionID = ddlValorPrimeraInscripcion.SelectedValue;
		objprimeraInscripcion.ValorTramitaID = ddlValorTramita.SelectedValue;
		objprimeraInscripcion.ValorServicioTagID = ddlValorServicioTAG.SelectedValue;
		objprimeraInscripcion.ValorNotariaID = ddlValorNotaria.SelectedValue;
		objprimeraInscripcion.ValorDespachoCorreoID = ddlValorDespachoCorreo.SelectedValue;
		objprimeraInscripcion.OficinaID = ddlOficinas.SelectedValue;
		objprimeraInscripcion.AnoProceso = ddlAnoProceso.SelectedValue;
		objprimeraInscripcion.chkTag = chkTAG.Checked;
		objprimeraInscripcion.chkPlacas = chkPlacas.Checked;
		objprimeraInscripcion.chkRUT = chkRUT.Checked;
		objprimeraInscripcion.chkEC = chkEC.Checked;
		objprimeraInscripcion.chkCI = chkCI.Checked;
		objprimeraInscripcion.ClienteID = ClienteID.Text;
		objprimeraInscripcion.AdquirenteID = AdquirenteID.Text;
		objprimeraInscripcion.RepresentanteLegalID = RepresentanteLegalID.Text;
		objprimeraInscripcion.DireccionClienteID = DireccionClienteID.Text;
		objprimeraInscripcion.ContactoClienteID = ContactoClienteID.Text;

		PrimeraInscripcion.INS_PrimeraInscripcion(objprimeraInscripcion);
		#endregion PRIMERA INSCRIPCION

		DireccionModel objDireccion = new DireccionModel();

		#region DIRECCION CLIENTE

		//Aqui grabar Direccion Cliente			DireccionClienteID
		objDireccion.PersonaEmpresaID = ClienteID.Text;
		objDireccion.DireccionID = DireccionClienteID.Text;
		objDireccion.Direccion = txtDireccionCliente.Text;
		objDireccion.NumeroDireccion = txtNumeroDireccionCliente.Text;
		objDireccion.ComplementoDireccion = txtComplementoDireccionCliente.Text;
		objDireccion.ComunaID = ddlComunaCliente.SelectedValue;
		#endregion DIRECCION CLIENTE



		#region CONTACTO DIRECCION CLIENTE
		//Aqui grabo Contacto Cliente
		ContactoModel objContacto = new ContactoModel();
		objContacto.DireccionID = objDireccion.DireccionID;
		objContacto.ContactoID = ContactoClienteID.Text;
		objContacto.Contacto = txtContacto.Text;
		objContacto.Telefono = txtTelefonoContacto.Text;
		objContacto.Email = txtEmailContacto.Text;
		#endregion CONTACTO DIRECCION CLIENTE



		#region DIRECCION ADQUIRENTE
		//Aqui grabar Direccion Adquirente   DireccionAdquirenteID
		objDireccion.PersonaEmpresaID = AdquirenteID.Text;
		objDireccion.DireccionID = DireccionAdquirenteID.Text;
		objDireccion.Direccion = txtDireccionAdquirente.Text;
		objDireccion.NumeroDireccion = txtNumeroDireccionAdquirente.Text;
		objDireccion.ComplementoDireccion = txtComplementoDireccionAdquirente.Text;
		objDireccion.ComunaID = ddlComunaAdquirente.SelectedValue;
		#endregion DIRECCION ADQUIRENTE


	}

	protected void btnNuevoPrimera_Click(object sender, EventArgs e)
	{
		#region -- BUSCAR --
		txtPPUBuscar.Text = "";
		txtNroFacturaBuscar.Text = "";
		txtRUTFacturaBuscar.Text = "";
		#endregion -- BUSCAR --


		#region -- DATOSTRAMITA 1 --
		txtPPU.Text = "";
		txtDVPPU.Text = "";
		ddlEstado.SelectedIndex = 0;
		txtNroOperacion.Text = "";
		txtOrigen.Text = "";
		txtCodigoCIT.Text = "";
		txtNroFactura.Text = "";
		txtVencimientoContratoLeasing.Text = "";

		txtRUTCliente.Text = "";
		txtNombreRazonSocialCliente.Text = "";
		txtDireccionCliente.Text = "";
		txtNumeroDireccionCliente.Text = "";
		txtComplementoDireccionCliente.Text = "";
		ddlComunaCliente.SelectedIndex = 0;
		ddlCiudadCliente.SelectedIndex = 0;

		// Datos representante legal
		txtRUTRepresentanteLegal.Text = "";
		txtNombreRepresentanteLegal.Text = "";

		txtContacto.Text = "";
		txtTelefonoContacto.Text = "";
		txtEmailContacto.Text = "";
		txtNroSolicitud.Text = "";
		ddlOficinas.SelectedIndex = 0;
		txtFechaSolicitudRNVM.Text = "";
		chkRUT.Checked = false;
		chkEC.Checked = false;
		chkCI.Checked = false;
		txtNroValija.Text = "";
		txtEjecutivo.Text = "";
		txtSucursal.Text = "";

		#endregion -- DATOSTRAMITA 1 --

		#region -- DATOSTRAMITA 2 --
		ddlAnoProceso.SelectedIndex = 0;
		txtFechaRecepcionBanco.Text = "";
		txtFechaPadron.Text = "";
		txtCodigoDespachoCorreo.Text = "";
		ddlObservacionEntrega.SelectedIndex = 0;
		ddlNroPlacas.SelectedIndex = 0;
		chkTAG.Checked = false;
		chkPlacas.Checked = false;
		txtFechaIngresoRNVM.Text = "";
		txtObservaciones.Text = "";
		txtCorrelativoEntrega.Text = "";
		txtFolio.Text = "";
		txtEstadoMeraTenencia.Text = "PENDIENTE**";
		ddlValorPrimeraInscripcion.SelectedIndex = 0;
		ddlValorTramita.SelectedIndex = 0;
		ddlValorServicioTAG.SelectedIndex = 0;
		ddlValorNotaria.SelectedIndex = 0;
		ddlValorDespachoCorreo.SelectedIndex = 0;
		txtFechaIngresoTAG.Text = "";
		chkF88.Checked = false;
		txtValorF88.Text = "";
		chkFotocopiaLegalizadaCert5594.Checked = false;
		chkFotocopiaRUTBanco.Checked = false;
		chk1U.Checked = false;
		chk2U.Checked = false;
		chk3U.Checked = false;
		chk4U.Checked = false;
		chkSolicitudPrimeraInscripcion.Checked = false;
		chkCertificadoLeasing.Checked = false;
		chkCertificadoCombustibles.Checked = false;
		chkContratoTelevia.Checked = false;
		chkConvenioPAC.Checked = false;
		chkDispositivoTelevia.Checked = false;
		chkContratoLeasing.Checked = false;
		chkPadron.Checked = false;
		chkPendienteContrato.Checked = false;
		chkPendienteAnotacionMeraTenencia.Checked = false;
		chkDespachoExterno.Checked = false;
		chkInformativoSeguro.Checked = false;




		#endregion -- DATOSTRAMITA 2 --

		#region -- DATOS ADQUIRENTE --
		// Datos Adquiernte
		txtRutAdquirente.Text = "";
		txtNombreRazonSocialAdquirente.Text = "";
		txtDireccionAdquirente.Text = "";
		txtNumeroDireccionAdquirente.Text = "";
		txtComplementoDireccionAdquirente.Text = "";
		ddlComunaAdquirente.SelectedIndex = 0;
		ddlCiudadAdquirente.SelectedIndex = 0;
		#endregion -- DATOS ADQUIRENTE --


		#region -- DATOS VEHICULO --
		ddlTipoVehiculo.SelectedIndex = 0;
		ddlMarca.SelectedIndex = 0;
		ddlModelo.SelectedIndex = 0;
		txtAnoFabricacion.Text = "";
		ddlColor.SelectedIndex = 0;
		ddlPuertas.SelectedIndex = 0;
		ddlAsientos.SelectedIndex = 0;
		txtCarga.Text = "";
		ddlUnidadCarga.SelectedIndex = 0;
		txtPesoBruto.Text = "";
		ddlUnidadPeso.SelectedIndex = 0;
		txtPotenciaMotor.Text = "";
		ddlUnidadPotencia.SelectedIndex = 0;
		ddlTraccion.SelectedIndex = 0;
		txtNroMotor.Text = "";
		txtNroChasis.Text = "";
		txtNroVin.Text = "";
		txtOtraCarrocería.Text = "";
		txtNroDisposicionEjes.Text = "";
		ddlCarroceria.SelectedIndex = 0;
		txtCodigoCIT.Text = "";
		txtCodigoCITVehiculo.Text = "";

		#endregion -- DATOS VEHICULO --

		#region -- DATOS DOCUMENTOS_RECIBIDOS --
		grvDocuemntosRecibidos.DataSource = null;
		grvDocuemntosRecibidos.DataBind();

		#endregion -- DATOS DOCUMENTOS_RECIBIDOS --


		#region -- DESPACHOS --

		grvDespachos.DataSource = null ;
		grvDespachos.DataBind();

		#endregion -- DESPACHOS --


	}

	protected void btnEliminarPrimera_Click(object sender, EventArgs e)
	{
	}
	protected void btnSalirPrimera_Click(object sender, EventArgs e)
	{
	}




	//protected void rptrDocumentosRecibidos_ItemDataBound(object sender, RepeaterItemEventArgs e)
	//{
	//	if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.Footer)
	//	{
	//		DataSet dsAll = Comun.SEL_ALL_ds();

	//		DropDownList ddlTipoDocumento = new DropDownList();
	//		ddlTipoDocumento = (DropDownList)e.Item.FindControl("ddlTipoDocumento");

	//		ddlTipoDocumento.DataSource = dsAll.Tables[Comun.Tablas.TIPOSDOCUMENTOS];
	//		ddlTipoDocumento.DataBind();

	//	}


	//	if (e.Item.ItemType == ListItemType.Header)
	//	{
	//		//e.Item.Visible = false;
	//		DataTable dtDatos = new DataTable();
	//		dtDatos = DocumentosRecibidos.SEL_DocumentosRecibidos("1");
	//		if (dtDatos.Rows.Count > 0)
	//		{
	//			GridView grvDocuemntosRecibidos = new GridView();
	//			grvDocuemntosRecibidos = (GridView)e.Item.FindControl("grvDocuemntosRecibidos");
	//			grvDocuemntosRecibidos.DataSource = dtDatos;
	//			grvDocuemntosRecibidos.DataBind();
	//		}

	//	}

	//	if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
	//	{
	//		e.Item.Visible = false;
	//		DataRowView row = e.Item.DataItem as DataRowView;

	//		TextBox txtTextBox = new TextBox();
	//		txtTextBox = (TextBox)e.Item.FindControl("txtIDDocumentoRecibido");
	//		txtTextBox.Text = row["id"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtNaturalezaAdquisición");
	//		txtTextBox.Text = row["naturalezaAdquisicion"].ToString();


	//		txtTextBox = (TextBox)e.Item.FindControl("txtNroDocumentoCausa");
	//		txtTextBox.Text = row["nroDocumentoCausa"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtRutDocumento");
	//		txtTextBox.Text = row["rutEmisorDocumento"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtRazonSocialProveedor");
	//		txtTextBox.Text = row["NombreRazonSocialEmisorDocumento"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtValorNetoFactura");
	//		txtTextBox.Text = row["valorNeto"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtValorIvaFactura");
	//		txtTextBox.Text = row["valorIVAFactura"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtValorTotalFactura");
	//		txtTextBox.Text = row["valorTotalFactura"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtLugarDocumento");
	//		txtTextBox.Text = row["lugarDocumento"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtFechaDocumento");
	//		txtTextBox.Text = row["fechaDocumento"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtNombreAutorizante");
	//		txtTextBox.Text = row["nombreAutorizanteEmisor"].ToString();

	//		txtTextBox = (TextBox)e.Item.FindControl("txtAcreedorBeneficiarioDemandante");
	//		txtTextBox.Text = row["acreedorBeneficiarioDemandante"].ToString();
	//	}
	//}


}