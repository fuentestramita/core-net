using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
	static public class DocumentosRecibidos
	{
		static public DataTable SEL_DocumentosRecibidos(string PrimeraInscripcionID)
		{
			return documentosRecibidos.SEL_DocumentosRecibidos(PrimeraInscripcionID);
		}


	}
}
