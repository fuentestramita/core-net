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
	static public class documentosRecibidos
	{
		static public DataTable SEL_DocumentosRecibidos(string PrimeraInscripcionID, string DocumentoRecibidoID)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[2];

			dAccess.AddParameter(ref pPos, "@PrimeraInscripcionID", PrimeraInscripcionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DocumentoRecibidoID", DocumentoRecibidoID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("SEL_DocumentosRecibidos", Param).Tables[0];
		}



		static public DataTable INS_DocumentoRecibido(DocumentosRecibidosModel objDocumentosRecibidos)
		{

			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[16];

			dAccess.AddParameter(ref pPos, "@EmpresaID", objDocumentosRecibidos.EmpresaID, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@UsuarioID", objDocumentosRecibidos.UsuarioID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DocumentoRecibidoID", utils.isNull(objDocumentosRecibidos.DocumentoRecibidoID,DBNull.Value), SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PrimeraInscripcionID", objDocumentosRecibidos.PrimeraInscripcionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@TipoDocumentoID", objDocumentosRecibidos.TipoDocumentoID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NaturalezaAdquisicion", objDocumentosRecibidos.NaturalezaAdquisicion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroDocumentoCausa", objDocumentosRecibidos.NumeroDocumentoCausa, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorNeto", objDocumentosRecibidos.ValorNeto, SqlDbType.Float, 18, 3, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorIVAFactura", objDocumentosRecibidos.ValorIVAFactura, SqlDbType.Float, 18, 3, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ValorTotalFactura", objDocumentosRecibidos.ValorTotalFactura, SqlDbType.Float, 18, 3, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@LugarDocumento", objDocumentosRecibidos.LugarDocumento, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FechaDocumento", objDocumentosRecibidos.FechaDocumento, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NombreAutorizanteEmisor", objDocumentosRecibidos.NombreAutorizanteEmisor, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@AcreedorBeneficiarioDemandante", objDocumentosRecibidos.AcreedorBeneficiarioDemandante, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PDF", objDocumentosRecibidos.PDF, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@EmisorDocumentoID", objDocumentosRecibidos.EmisorDocumentoID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);


			return dAccess.getData("INS_DocumentoRecibido", Param).Tables[0];

		}
	}
}
