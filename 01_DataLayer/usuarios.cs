using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	static public class usuarios
	{

		static public DataTable SEL_MenuUsuario(string UsuarioID)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[1];

			dAccess.AddParameter(ref pPos, "@UsuarioID", UsuarioID, SqlDbType.Int, 0, 0, ParameterDirection.Input, ref Param);
			return dAccess.getData("SEL_MenuUsuario", Param).Tables[0];
		}

	}
}
