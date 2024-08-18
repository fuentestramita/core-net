using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	static public class login
	{
		static public DataTable SEL_Login(string RutUsuario, string ClaveUsuario)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[2];

			dAccess.AddParameter(ref pPos, "@RutUsuario", RutUsuario, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ClaveUsuario", ClaveUsuario, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			return dAccess.getData("SEL_Login", Param).Tables[0];
		}



		static public DataTable INS_CodigoLogin(string UsuarioID, string CodigoAccesoUsuario)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[2];

			dAccess.AddParameter(ref pPos, "@UsuarioID", UsuarioID, SqlDbType.Decimal, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CodigoAccesoUsuario", CodigoAccesoUsuario, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			return dAccess.ExecProdIns("INS_CodigoLogin", Param);
		}


		static public DataTable SEL_ValidaCodigoUsuario(string RutUsuario, string CodigoUsuario)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[2];

			dAccess.AddParameter(ref pPos, "@RutUsuario", RutUsuario, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@CodigoAccesoUsuario", CodigoUsuario, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			return dAccess.getData("SEL_ValidaCodigoUsuario", Param).Tables[0];
		}


	}
}
