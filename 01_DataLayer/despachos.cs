using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DataLayer
{
	static public class despachos
	{
		static public DataTable SEL_Despachos(string PrimeraInscripcionID, string DespachoID)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[2];

			dAccess.AddParameter(ref pPos, "@PrimeraInscripcionID", PrimeraInscripcionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DespachoID", DespachoID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			

			return dAccess.getData("SEL_Despachos", Param).Tables[0];

		}

		static public DataTable SEL_ServicioCourier()
		{
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");

			return dAccess.getData("SEL_ServicioCourier").Tables[0];

		}

		static public DataTable SEL_Items()
		{
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");

			return dAccess.getData("SEL_Items").Tables[0];

		}


		static public DataTable INS_Despacho(DespachosModel objDespachosModel)
		{

			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[18];

			dAccess.AddParameter(ref pPos, "@EmpresaID", objDespachosModel.EmpresaID, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@UsuarioID", objDespachosModel.UsuarioID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);

			dAccess.AddParameter(ref pPos, "@DespachoID", utils.isNull(objDespachosModel.DespachoID, DBNull.Value), SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PrimeraInscripcionID", objDespachosModel.PrimeraInscripcionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Origen", objDespachosModel.Origen, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@SolicitaDespacho", objDespachosModel.SolicitaDespacho, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ImprimirParaEntrega", objDespachosModel.ImprimirParaEntrega, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CodigoDespacho", objDespachosModel.CodigoDespacho, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@EntregaEfectuada", objDespachosModel.EntregaEfectuada, SqlDbType.Bit, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PDFEntrega", objDespachosModel.PDFEntrega, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@fechaRecepcion", objDespachosModel.fechaRecepcion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaEntrega", objDespachosModel.FechaEntrega, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Observacion", objDespachosModel.Observacion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaRecepcionCourier", objDespachosModel.FechaRecepcionCourier, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaEntregaCourier", objDespachosModel.FechaEntregaCourier, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CodigoDespachoCourier", objDespachosModel.CodigoDespachoCourier, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ServicioCourierID", objDespachosModel.ServicioCourierID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ItemID", objDespachosModel.ItemID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("INS_Despacho", Param).Tables[0];

		}
	}
}
