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
	static public class direcciones
	{
		static public DataTable SEL_Direccion(string DireccionID, string PersonaEmpresaID)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[2];

			dAccess.AddParameter(ref pPos, "@DireccionID", DireccionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PersonaEmpresaID", PersonaEmpresaID, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("SEL_Direccion", Param).Tables[0];

		}


		static public DataTable INS_Direccion(DireccionModel modeloDireccion)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[8];

			dAccess.AddParameter(ref pPos, "@EmpresaID", modeloDireccion.EmpresaID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@UsuarioID", modeloDireccion.UsuarioID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@PersonaEmpresaID", modeloDireccion.PersonaEmpresaID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@DireccionID", modeloDireccion.DireccionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Direccion", modeloDireccion.Direccion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NumeroDireccion", modeloDireccion.NumeroDireccion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ComplementoDireccion", modeloDireccion.ComplementoDireccion, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ComunaID", modeloDireccion.ComunaID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("INS_Direccion", Param).Tables[0];

		}

	}
}
