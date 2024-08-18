using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
	static public class Despachos
	{
		static public DataTable SEL_Despachos(string PrimeraInscripcionID)
		{
			return despachos.SEL_Despachos(PrimeraInscripcionID);
		}


	}
}
