using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	static public class despachos
	{
		static public DataTable SEL_Despachos(string PrimeraInscripcionID)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[1];

			dAccess.AddParameter(ref pPos, "@PrimeraInscripcionID", PrimeraInscripcionID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("SEL_Despachos", Param).Tables[0];

		}
	}
}
