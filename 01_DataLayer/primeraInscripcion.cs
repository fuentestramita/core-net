using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataLayer
{
	static public class primeraInscripcion
	{
		static public DataTable SEL_PrimeraInscripcion(string EmpresaID, string PrimeraInscripcionID, string PPU, string NroFactura, string RutFactura)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[5];

			dAccess.AddParameter(ref pPos, "@EmpresaID", EmpresaID, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PrimeraInscripcionID", PrimeraInscripcionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PPU", PPU, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroFactura", NroFactura, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RUTFactura", RutFactura, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("SEL_PrimeraInscripcion", Param).Tables[0];

		}


		static public DataTable INS_PrimeraInscripcion(PrimeraInscripcionModel modeloPrimeraInscripcion)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[5];

			dAccess.AddParameter(ref pPos, "@PrimeraInscripcionID", modeloPrimeraInscripcion.PrimeraInscripcionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@EmpresaID", modeloPrimeraInscripcion.EmpresaID, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PPU", modeloPrimeraInscripcion.PPU, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroOperacion", modeloPrimeraInscripcion.NumeroOperacion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Origen", modeloPrimeraInscripcion.Origen, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroFactura", modeloPrimeraInscripcion.NumeroFactura, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RutCliente", modeloPrimeraInscripcion.RutCliente, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@VencimientoContratoLeasing", modeloPrimeraInscripcion.VencimientoContratoLeasing, SqlDbType.DateTime, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroSolicitud", modeloPrimeraInscripcion.NumeroSolicitud, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@EstaEntregado", modeloPrimeraInscripcion.TieneListadoPrimeraInscripcion, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaSolicitudRNVM", modeloPrimeraInscripcion.FechaSolicitudRNVM, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroValija", modeloPrimeraInscripcion.NumeroValija, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Ejecutivo", modeloPrimeraInscripcion.Ejecutivo, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Sucursal", modeloPrimeraInscripcion.Sucursal, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaRecepcionBanco", modeloPrimeraInscripcion.FechaRecepcionBanco, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaPadron", modeloPrimeraInscripcion.FechaPadron, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CodigoDespachoCorreo", modeloPrimeraInscripcion.CodigoDespachoCorreo, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroPlacas", modeloPrimeraInscripcion.NumeroPlacas, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaIngresoRNVM", modeloPrimeraInscripcion.FechaIngresoRNVM, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Observaciones", modeloPrimeraInscripcion.Observaciones, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CorrelativoEntrega", modeloPrimeraInscripcion.CorrelativoEntrega, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Folio", modeloPrimeraInscripcion.Folio, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaIngresoTAG", modeloPrimeraInscripcion.FechaIngresoTAG, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@F88", modeloPrimeraInscripcion.F88, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorF88", modeloPrimeraInscripcion.ValorF88, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FLCertCum5594", modeloPrimeraInscripcion.FLCertCum5594, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FotocopiaRutBanco", modeloPrimeraInscripcion.FotocopiaRutBanco, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CertificadoDS5594", modeloPrimeraInscripcion.CertificadoDS5594, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@chk1U", modeloPrimeraInscripcion.chk1U, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@chk2U", modeloPrimeraInscripcion.chk2U, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@chk3U", modeloPrimeraInscripcion.chk3U, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@chk4U", modeloPrimeraInscripcion.chk4U, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@SolicitudPrimeraInscripcion", modeloPrimeraInscripcion.SolicitudPrimeraInscripcion, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CertificadoLeasing", modeloPrimeraInscripcion.CertificadoLeasing, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CertificadoCombustibles", modeloPrimeraInscripcion.CertificadoCombustibles, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ContratoTelevia", modeloPrimeraInscripcion.ContratoTelevia, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ConvenioPAC", modeloPrimeraInscripcion.ConvenioPAC, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DispositivoTelevia", modeloPrimeraInscripcion.DispositivoTelevia, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ContratoLeasing", modeloPrimeraInscripcion.ContratoLeasing, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Padron", modeloPrimeraInscripcion.Padron, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PendienteContrato", modeloPrimeraInscripcion.PendienteContrato, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PendienteAnotacionMeraTenencia", modeloPrimeraInscripcion.PendienteAnotacionMeraTenencia, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DespachoExterno", modeloPrimeraInscripcion.DespachoExterno, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@InformativoSeguro", modeloPrimeraInscripcion.InformativoSeguro, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaCreacion", modeloPrimeraInscripcion.FechaCreacion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaActualizacion", modeloPrimeraInscripcion.FechaActualizacion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@VehiculoID", modeloPrimeraInscripcion.VehiculoID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ComunaID", modeloPrimeraInscripcion.ComunaClienteID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@EstadoID", modeloPrimeraInscripcion.EstadoID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ObservacionID", modeloPrimeraInscripcion.ObservacionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ClienteID", modeloPrimeraInscripcion.ClienteID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@UsuarioID", modeloPrimeraInscripcion.UsuarioID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@AdquirenteID", modeloPrimeraInscripcion.AdquirenteID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorPrimeraInscripcionID", modeloPrimeraInscripcion.ValorPrimeraInscripcionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorTramitaID", modeloPrimeraInscripcion.ValorTramitaID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorServicioTagID", modeloPrimeraInscripcion.ValorServicioTagID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorNotariaID", modeloPrimeraInscripcion.ValorNotariaID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorDespachoCorreoID", modeloPrimeraInscripcion.ValorDespachoCorreoID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@OficinaID", modeloPrimeraInscripcion.OficinaID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@AnoProceso", modeloPrimeraInscripcion.AnoProceso, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@AnoFiltro", modeloPrimeraInscripcion.AnoFiltro, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@chkTag", modeloPrimeraInscripcion.chkTag, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@chkPlacas", modeloPrimeraInscripcion.chkPlacas, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RepresentanteLegalID", modeloPrimeraInscripcion.RepresentanteLegalID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@chkRUT", modeloPrimeraInscripcion.chkRUT, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@chkEC", modeloPrimeraInscripcion.chkEC, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@chkCI", modeloPrimeraInscripcion.chkCI, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DireccionClienteID", modeloPrimeraInscripcion.DireccionClienteID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ContactoClienteID", modeloPrimeraInscripcion.ContactoClienteID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("INS_PrimeraInscripcion", Param).Tables[0];

		}

	}
}
