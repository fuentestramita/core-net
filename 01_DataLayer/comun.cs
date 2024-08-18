using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	static public class comun
	{


		static public DataSet SEL_ALL()
		{
			DataAccess dAccess = new DataAccess();
			dAccess.Open("tramita_db");
			return dAccess.getData("SEL_ALL");
		}


	}
}
