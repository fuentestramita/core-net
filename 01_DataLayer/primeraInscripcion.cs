﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;
using Utilities;
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
			SqlParameter[] Param = new SqlParameter[65];

			dAccess.AddParameter(ref pPos, "@EmpresaID", modeloPrimeraInscripcion.EmpresaID, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PrimeraInscripcionID", modeloPrimeraInscripcion.PrimeraInscripcionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PPU", modeloPrimeraInscripcion.PPU, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroOperacion", modeloPrimeraInscripcion.NumeroOperacion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Origen", modeloPrimeraInscripcion.Origen, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroFactura", modeloPrimeraInscripcion.NumeroFactura, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@VencimientoContratoLeasing", utils.isNull(modeloPrimeraInscripcion.VencimientoContratoLeasing), SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroSolicitud", modeloPrimeraInscripcion.NumeroSolicitud, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@TieneListadoPrimeraInscripcion", modeloPrimeraInscripcion.TieneListadoPrimeraInscripcion, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param); //EstadoEntregado
			dAccess.AddParameter(ref pPos, "@FechaSolicitudRNVM", utils.isNull(modeloPrimeraInscripcion.FechaSolicitudRNVM), SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroValija", modeloPrimeraInscripcion.NumeroValija, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Ejecutivo", modeloPrimeraInscripcion.Ejecutivo, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Sucursal", modeloPrimeraInscripcion.Sucursal, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaRecepcionBanco", utils.isNull(modeloPrimeraInscripcion.FechaRecepcionBanco), SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaPadron", utils.isNull(modeloPrimeraInscripcion.FechaPadron), SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CodigoDespachoCorreo", modeloPrimeraInscripcion.CodigoDespachoCorreo, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroPlacas", modeloPrimeraInscripcion.NumeroPlacas, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaIngresoRNVM", utils.isNull(modeloPrimeraInscripcion.FechaIngresoRNVM), SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Observaciones", modeloPrimeraInscripcion.Observaciones, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CorrelativoEntrega", modeloPrimeraInscripcion.CorrelativoEntrega, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Folio", modeloPrimeraInscripcion.Folio, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaIngresoTAG", utils.isNull(modeloPrimeraInscripcion.FechaIngresoTAG), SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@F88", modeloPrimeraInscripcion.F88, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorF88", modeloPrimeraInscripcion.ValorF88, SqlDbType.Float, 0, 0, ParameterDirection.Input, ref Param);
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
			dAccess.AddParameter(ref pPos, "@VehiculoID", modeloPrimeraInscripcion.VehiculoID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
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
			dAccess.AddParameter(ref pPos, "@DireccionAdquirenteID", modeloPrimeraInscripcion.DireccionAdquirenteID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("INS_PrimeraInscripcion", Param).Tables[0];

		}


		static public DataTable INS_CargabancoPrimera(CargaPrimeraInscripcionModel modelocCargaPrimeraInscripcion)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[54];

			dAccess.AddParameter(ref pPos, "@FileName", modelocCargaPrimeraInscripcion.FileName, SqlDbType.VarChar, 100, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@EmpresaID", modelocCargaPrimeraInscripcion.EmpresaID, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PPU", modelocCargaPrimeraInscripcion.PPU, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroOperacion", modelocCargaPrimeraInscripcion.NumeroOperacion, SqlDbType.VarChar, 30, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroFactura", modelocCargaPrimeraInscripcion.NumeroFactura, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RUTEmisor", modelocCargaPrimeraInscripcion.RUTProveedor, SqlDbType.VarChar, 15, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DigitoRutEmisor", modelocCargaPrimeraInscripcion.DigitoRutProveedor, SqlDbType.VarChar, 1, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NombreEmisor", modelocCargaPrimeraInscripcion.NombreProveedor, SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaRecepcion", modelocCargaPrimeraInscripcion.FechaRecepcion, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@TipoVehiculo", modelocCargaPrimeraInscripcion.TipoVehiculo, SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RutCliente", modelocCargaPrimeraInscripcion.RutCliente, SqlDbType.VarChar, 15, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RazonSocialCliente", modelocCargaPrimeraInscripcion.RazonSocialCliente, SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Calle", modelocCargaPrimeraInscripcion.Calle, SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Numero", modelocCargaPrimeraInscripcion.Numero, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Complemento", modelocCargaPrimeraInscripcion.Complemento, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Comuna", modelocCargaPrimeraInscripcion.Comuna, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Ciudad", modelocCargaPrimeraInscripcion.Ciudad, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@VencimientoContrato", modelocCargaPrimeraInscripcion.VencimientoContrato, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CodigoCliente", modelocCargaPrimeraInscripcion.CodigoCliente, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Ejecutivo", modelocCargaPrimeraInscripcion.Ejecutivo, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Sucursal", modelocCargaPrimeraInscripcion.Sucursal, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CertificadoHomologacion", modelocCargaPrimeraInscripcion.CertificadoHomologacion, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Marca", modelocCargaPrimeraInscripcion.Marca, SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Modelo", modelocCargaPrimeraInscripcion.Modelo, SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NroMotor", modelocCargaPrimeraInscripcion.NroMotor, SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NroChasis", modelocCargaPrimeraInscripcion.NroChasis, SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NroVin", modelocCargaPrimeraInscripcion.NroVin, SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Color", modelocCargaPrimeraInscripcion.Color, SqlDbType.VarChar, 50, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Traccion", modelocCargaPrimeraInscripcion.Traccion, SqlDbType.VarChar, 50, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DisposicionEjes", modelocCargaPrimeraInscripcion.DisposicionEjes, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@TipoCarroceria", modelocCargaPrimeraInscripcion.TipoCarroceria, SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@AnoFabricacion", modelocCargaPrimeraInscripcion.AnoFabricacion, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PesoBrutoVehicular", modelocCargaPrimeraInscripcion.PesoBrutoVehicular, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CapacidadCarga", modelocCargaPrimeraInscripcion.CapacidadCarga, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@TipoCombustible", modelocCargaPrimeraInscripcion.TipoCombustible, SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PotenciaMotor", modelocCargaPrimeraInscripcion.PotenciaMotor, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RutPropietario", modelocCargaPrimeraInscripcion.RutPropietario, SqlDbType.VarChar, 15, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RazonSocialPropietario", modelocCargaPrimeraInscripcion.RazonSocialPropietario, SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DireccionPropietario", modelocCargaPrimeraInscripcion.DireccionPropietario, SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroPropietario", modelocCargaPrimeraInscripcion.NumeroPropietario, SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ComunaPropietario", modelocCargaPrimeraInscripcion.ComunaPropietario, SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ContactoPropietario", modelocCargaPrimeraInscripcion.ContactoPropietario, SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@TelefonoContacto", modelocCargaPrimeraInscripcion.TelefonoContacto, SqlDbType.VarChar, 50, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@SolicitaDespacho", modelocCargaPrimeraInscripcion.SolicitaDespacho, SqlDbType.VarChar, 3, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CorrelativoCarga", modelocCargaPrimeraInscripcion.CorrelativoCarga, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaRecepcionDespacho", modelocCargaPrimeraInscripcion.FechaRecepcionDespacho, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@F88", modelocCargaPrimeraInscripcion.F88, SqlDbType.VarChar, 3, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorF88", modelocCargaPrimeraInscripcion.ValorF88, SqlDbType.Decimal, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ImprimirParaDespacho", modelocCargaPrimeraInscripcion.ImprimirParaDespacho, SqlDbType.VarChar, 3, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@SolicitaDespachoTramita", modelocCargaPrimeraInscripcion.SolicitaDespachoTramita, SqlDbType.VarChar, 3, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaRecepcionPadron", modelocCargaPrimeraInscripcion.FechaRecepcionPadron, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Origen", modelocCargaPrimeraInscripcion.Origen, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@AnoFiltro", modelocCargaPrimeraInscripcion.AnoFiltro, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@TAG", modelocCargaPrimeraInscripcion.TAG, SqlDbType.VarChar, 3, 0, ParameterDirection.Input, ref Param);


			return dAccess.getData("INS_CargabancoPrimera", Param).Tables[0];
		}

		static public DataTable PRC_ValidaCargaBancoPrimera(string fileName)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[1];
			dAccess.AddParameter(ref pPos, "@Filename", fileName, SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			
			return dAccess.getData("PRC_ValidaCargaBancoPrimera", Param).Tables[0];
		}
		
	}

}
