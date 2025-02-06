using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class PrimeraInscripcionModel
	{
		public int errNumber { get; set; }
		public string mensaje { get; set; }
		public string PrimeraInscripcionID { get; set; }
		public string EmpresaID { get; set; }
		public string PPU { get; set; } = "";
		public string NumeroOperacion { get; set; } = "";
		public string Origen { get; set; } = "";
		public string NumeroFactura { get; set; } = "";
		public string RutCliente { get; set; } = "";
		public string VencimientoContratoLeasing { get; set; }
		public string NumeroSolicitud { get; set; } = "";
		public bool TieneListadoPrimeraInscripcion { get; set; }
		public string FechaSolicitudRNVM { get; set; }
		public string NumeroValija { get; set; } = "";
		public string Ejecutivo { get; set; } = "";
		public string Sucursal { get; set; } = "";
		public string FechaRecepcionBanco { get; set; }
		public string FechaPadron { get; set; }
		public string CodigoDespachoCorreo { get; set; } = "";
		public string NumeroPlacas { get; set; }
		public string FechaIngresoRNVM { get; set; }
		public string Observaciones { get; set; } = "";
		public string CorrelativoEntrega { get; set; } = "";
		public string Folio { get; set; } = "";
		public string FechaIngresoTAG { get; set; }
		public bool F88 { get; set; }
		public string ValorF88 { get; set; } = "";
		public bool FLCertCum5594 { get; set; }
		public bool FotocopiaRutBanco { get; set; }
		public bool CertificadoDS5594 { get; set; }
		public bool chk1U { get; set; }
		public bool chk2U { get; set; }
		public bool chk3U { get; set; }
		public bool chk4U { get; set; }
		public bool SolicitudPrimeraInscripcion { get; set; }
		public bool CertificadoLeasing { get; set; }
		public bool CertificadoCombustibles { get; set; }
		public bool ContratoTelevia { get; set; }
		public bool ConvenioPAC { get; set; }
		public bool DispositivoTelevia { get; set; }
		public bool ContratoLeasing { get; set; }
		public bool Padron { get; set; }
		public bool PendienteContrato { get; set; }
		public bool PendienteAnotacionMeraTenencia { get; set; }
		public bool DespachoExterno { get; set; }
		public bool InformativoSeguro { get; set; }
		public string FechaCreacion { get; set; }
		public string FechaActualizacion { get; set; }
		public string VehiculoID { get; set; }
		public string ComunaClienteID { get; set; }
		public string EstadoID { get; set; }
		public string ObservacionID { get; set; }
		public string ClienteID { get; set; }
		public string UsuarioID { get; set; }
		public string AdquirenteID { get; set; }
		public string ValorPrimeraInscripcionID { get; set; }
		public string ValorTramitaID { get; set; }
		public string ValorServicioTagID { get; set; }
		public string ValorNotariaID { get; set; }
		public string ValorDespachoCorreoID { get; set; }
		public string OficinaID { get; set; }
		public string AnoProceso { get; set; } = "";
		public string AnoFiltro { get; set; } = "";
		public bool chkTag { get; set; }
		public bool chkPlacas { get; set; }
		public string RepresentanteLegalID { get; set; }
		public bool chkRUT { get; set; }
		public bool chkEC { get; set; }
		public bool chkCI { get; set; }
		public string DireccionClienteID { get; set; }
		public string DireccionAdquirenteID { get; set; }
	}


	public class CargaPrimeraInscripcionModel
	{
		public int errNumber { get; set; }
		public string mensaje { get; set; }
		public string tmpBulkPrimeraID { get; set; }
		public string FileName { get; set; }
		public string EmpresaID { get; set; }
		public string PPU { get; set; }
		public string NumeroOperacion { get; set; }
		public string NumeroFactura { get; set; }
		public string RUTProveedor { get; set; }
		public string DigitoRutProveedor { get; set; }
		public string NombreProveedor { get; set; }
		public string FechaRecepcion { get; set; }
		public string TipoVehiculo { get; set; }
		public string RutCliente { get; set; }
		public string RazonSocialCliente { get; set; }
		public string Calle { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public string Comuna { get; set; }
		public string Ciudad { get; set; }
		public string VencimientoContrato { get; set; }
		public string CodigoCliente { get; set; }
		public string Ejecutivo { get; set; }
		public string Sucursal { get; set; }
		public string CertificadoHomologacion { get; set; }
		public string Marca { get; set; }
		public string Modelo { get; set; }
		public string NroMotor { get; set; }
		public string NroChasis { get; set; }
		public string NroVin { get; set; }
		public string Color { get; set; }
		public string Traccion { get; set; }
		public int DisposicionEjes { get; set; }
		public string TipoCarroceria { get; set; }
		public int AnoFabricacion { get; set; }
		public int PesoBrutoVehicular { get; set; }
		public int CapacidadCarga { get; set; }
		public string TipoCombustible { get; set; }
		public int PotenciaMotor { get; set; }
		public string RutPropietario { get; set; }
		public string RazonSocialPropietario { get; set; }
		public string DireccionPropietario { get; set; }
		public string NumeroPropietario { get; set; }
		public string ComunaPropietario { get; set; }
		public string ContactoPropietario { get; set; }
		public string TelefonoContacto { get; set; }
		public string SolicitaDespacho { get; set; }
		public int CorrelativoCarga { get; set; }
		public string FechaRecepcionDespacho { get; set; }
		public string F88 { get; set; }
		public decimal ValorF88 { get; set; }
		public string ImprimirParaDespacho { get; set; }
		public string SolicitaDespachoTramita { get; set; }
		public string FechaRecepcionPadron { get; set; }
		public string Origen { get; set; }
		public int AnoFiltro { get; set; }
		public string TAG { get; set; }

	}

}

