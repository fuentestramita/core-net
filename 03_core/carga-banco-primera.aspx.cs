using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcelDataReader;
using System.Text;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Kiota.Abstractions;
using System.Web.UI.HtmlControls;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Encodings.Web;
using System.Runtime.InteropServices.ComTypes;
using BusinessLayer;
using DataLayer;
using Azure;
using System.Text.RegularExpressions;
using System.Web.Caching;
using Utilities;
using System.Activities.Expressions;
using System.Diagnostics.Metrics;

public partial class cargaPrimera : System.Web.UI.Page
{
	static string staticEmpresaID = "";
	string EmpresaID = "";
	HttpCookie userInfo = new HttpCookie("CoreInfo");
	int UserID = 0;

	protected void Page_Load(object sender, EventArgs e)
	{
		MasterPage master = new MasterPage();
		master = this.Master;
		DropDownList cmbEmpresas = master.FindControl("cmbEmpresas") as DropDownList;
		EmpresaID = cmbEmpresas.SelectedValue;
		staticEmpresaID = EmpresaID;

	}


	protected void btnUpload_Click(object sender, EventArgs e)
	{
		#region CARGA ARCHIVO EXCEL A LA CARPETA UPLOAD

		MasterPage master = new MasterPage();
		master = this.Master;
		HtmlForm MasterForm = new HtmlForm();
		MasterForm = master.FindControl("masterForm") as HtmlForm;
		MasterForm.Enctype = "multipart/form-data";


		string strFileName;
		string strFilePath;
		string strFolder;
		DataTable dtDatosExcelPrimera = new DataTable();
		Models.CargaPrimeraInscripcionModel modelCargaPrimeraInscripcion = new Models.CargaPrimeraInscripcionModel();



		strFolder = Server.MapPath("./UPLOAD/");
		// Retrieve the name of the file that is posted.
		strFileName = oFile.PostedFile.FileName;
		strFileName = Path.GetFileName(strFileName);
		string strNewFileName = String.Format("CargaPrimera_{0}{1}", DateTime.Now.ToString("yyyyMMddTHHmmss"), Path.GetExtension(strFileName)).ToString();

		if (oFile.PostedFile.FileName.ToString() != "")
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
				lblUploadResult.Text = strFileName + " El archivo ya existe, intente nuevamente en unos minutos";
			}
			else
			{
				oFile.PostedFile.SaveAs(strFilePath);
				dtDatosExcelPrimera = utils.ReadExcelFileToDataTable(strFilePath);
				File.Delete(strFilePath);
				lblUploadResult.Text = strFileName + " Archivo cargado correctamente";
			}
		}
		else
		{
			lblUploadResult.Text = "Click 'Browse' to select the file to upload.";
		}
		// Display the result of the upload.
		frmConfirmation.Visible = true;


		#endregion

		#region CARGA ARCHIVO EXCEL A LA BASE DE DATOS

		DataColumn newColumn = new DataColumn("FileName", typeof(string));

		// Insertar la columna en la primera posición
		dtDatosExcelPrimera.Columns.Add(newColumn);
		dtDatosExcelPrimera.Columns["FileName"].SetOrdinal(0);
		foreach (DataRow fila in dtDatosExcelPrimera.Rows)
		{

			modelCargaPrimeraInscripcion.FileName = strNewFileName;
			modelCargaPrimeraInscripcion.EmpresaID = EmpresaID;
			modelCargaPrimeraInscripcion.PPU = fila["PPU"].ToString();
			modelCargaPrimeraInscripcion.NumeroOperacion = fila["NumeroOperacion"].ToString();
			modelCargaPrimeraInscripcion.NumeroFactura = fila["NumeroFactura"].ToString();
			modelCargaPrimeraInscripcion.RUTProveedor = fila["RUTEmisor"].ToString();
			modelCargaPrimeraInscripcion.DigitoRutProveedor = fila["DigitoRutEmisor"].ToString();
			modelCargaPrimeraInscripcion.NombreProveedor = fila["NombreEmisor"].ToString();
			modelCargaPrimeraInscripcion.FechaRecepcion = fila["FechaRecepcion"].ToString();
			modelCargaPrimeraInscripcion.TipoVehiculo = fila["TipoVehiculo"].ToString();
			modelCargaPrimeraInscripcion.RutCliente = fila["RutCliente"].ToString();
			modelCargaPrimeraInscripcion.RazonSocialCliente = fila["RazonSocialCliente"].ToString();
			modelCargaPrimeraInscripcion.Calle = fila["Calle"].ToString();
			modelCargaPrimeraInscripcion.Numero = fila["Numero"].ToString();
			modelCargaPrimeraInscripcion.Complemento = fila["Complemento"].ToString();
			modelCargaPrimeraInscripcion.Comuna = fila["Comuna"].ToString();
			modelCargaPrimeraInscripcion.Ciudad = fila["Ciudad"].ToString();
			modelCargaPrimeraInscripcion.VencimientoContrato = fila["VencimientoContrato"].ToString();
			modelCargaPrimeraInscripcion.CodigoCliente = fila["CodigoCliente"].ToString();
			modelCargaPrimeraInscripcion.Ejecutivo = fila["Ejecutivo"].ToString();
			modelCargaPrimeraInscripcion.Sucursal = fila["Sucursal"].ToString();
			modelCargaPrimeraInscripcion.CertificadoHomologacion = fila["CertificadoHomologacion"].ToString();
			modelCargaPrimeraInscripcion.Marca = fila["Marca"].ToString();
			modelCargaPrimeraInscripcion.Modelo = fila["Modelo"].ToString();
			modelCargaPrimeraInscripcion.NroMotor = fila["NroMotor"].ToString();
			modelCargaPrimeraInscripcion.NroChasis = fila["NroChasis"].ToString();
			modelCargaPrimeraInscripcion.NroVin = fila["NroVin"].ToString();
			modelCargaPrimeraInscripcion.Color = fila["Color"].ToString();
			modelCargaPrimeraInscripcion.Traccion = fila["Traccion"].ToString();
			modelCargaPrimeraInscripcion.DisposicionEjes = int.Parse( utils.isNull(fila["DisposicionEjes"].ToString(),"0") );
			modelCargaPrimeraInscripcion.TipoCarroceria = fila["TipoCarroceria"].ToString();
			modelCargaPrimeraInscripcion.AnoFabricacion = int.Parse(utils.isNull(fila["AnoFabricacion"].ToString(),"0"));
			modelCargaPrimeraInscripcion.PesoBrutoVehicular = int.Parse(utils.isNull(fila["PesoBrutoVehicular"].ToString(), "0"));
			modelCargaPrimeraInscripcion.CapacidadCarga = int.Parse(utils.isNull(fila["CapacidadCarga"].ToString(), "0"));
			modelCargaPrimeraInscripcion.TipoCombustible = fila["TipoCombustible"].ToString();
			modelCargaPrimeraInscripcion.PotenciaMotor = int.Parse(utils.isNull(fila["PotenciaMotor"].ToString(), "0"));
			modelCargaPrimeraInscripcion.RutPropietario = fila["RutPropietario"].ToString();
			modelCargaPrimeraInscripcion.RazonSocialPropietario = fila["RazonSocialPropietario"].ToString();
			modelCargaPrimeraInscripcion.DireccionPropietario = fila["DireccionPropietario"].ToString();
			modelCargaPrimeraInscripcion.NumeroPropietario = fila["NumeroPropietario"].ToString();
			modelCargaPrimeraInscripcion.ComunaPropietario = fila["ComunaPropietario"].ToString();
			modelCargaPrimeraInscripcion.ContactoPropietario = fila["ContactoPropietario"].ToString();
			modelCargaPrimeraInscripcion.TelefonoContacto = fila["TelefonoContacto"].ToString();
			modelCargaPrimeraInscripcion.SolicitaDespacho = fila["SolicitaDespacho"].ToString();
			modelCargaPrimeraInscripcion.CorrelativoCarga = int.Parse(utils.isNull(fila["CorrelativoCarga"].ToString(), "0"));
			modelCargaPrimeraInscripcion.FechaRecepcionDespacho = fila["FechaRecepcionDespacho"].ToString();
			modelCargaPrimeraInscripcion.F88 = fila["F88"].ToString();
			modelCargaPrimeraInscripcion.ValorF88 = int.Parse(utils.isNull(fila["ValorF88"].ToString(), "0"));
			modelCargaPrimeraInscripcion.ImprimirParaDespacho = fila["ImprimirParaDespacho"].ToString();
			modelCargaPrimeraInscripcion.SolicitaDespachoTramita = fila["SolicitaDespachoTramita"].ToString();
			modelCargaPrimeraInscripcion.FechaRecepcionPadron = fila["FechaRecepcionPadron"].ToString();
			modelCargaPrimeraInscripcion.Origen = fila["Origen"].ToString();
			modelCargaPrimeraInscripcion.AnoFiltro = int.Parse(utils.isNull(fila["AnoFiltro"].ToString(), "0"));
			modelCargaPrimeraInscripcion.TAG = fila["TAG"].ToString();


			PrimeraInscripcion.INS_CargabancoPrimera(modelCargaPrimeraInscripcion);

		}
		#endregion

		#region HACE VALIDACIONES DEL ARCHIVO

		DataTable dtValidacion = primeraInscripcion.PRC_ValidaCargaBancoPrimera(strNewFileName);

		grvResultadoCarga.DataSource = dtValidacion;
		grvResultadoCarga.DataBind();

		sectionResultadoValidacion.Visible = true;
		sectionCargaArchivo.Visible = false;
		flsResultadoValidacion.Visible = true;

		#endregion

		master = new MasterPage();
		master = this.Master;
		MasterForm = new HtmlForm();
		MasterForm = master.FindControl("masterForm") as HtmlForm;
		MasterForm.Enctype = "application/x-www-form-urlencoded";

	}


	




	protected void btnCargar_Click(object sender, EventArgs e)
	{

	}

	protected void btnCargaOtroArchivo_Click(object sender, EventArgs e)
	{
		sectionCargaArchivo.Visible = true;
		sectionResultadoValidacion.Visible = false;
		flsResultadoValidacion.Visible = false;

		MasterPage master = new MasterPage();
		master = this.Master;
		HtmlForm MasterForm = new HtmlForm();
		MasterForm = master.FindControl("masterForm") as HtmlForm;
		MasterForm.Enctype = "multipart/form-data";
	}
}

//TODO: Hacer un sp que cargue los datos al formulario de Primera
//TODO: Revisar la carga de primera de asp y aplicar validacioines
