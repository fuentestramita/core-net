using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Models;

namespace BusinessLayer
{
	static public class Despachos
	{
		static public DataTable SEL_Despachos(string PrimeraInscripcionID, string DespachoID)
		{
			return despachos.SEL_Despachos(PrimeraInscripcionID, DespachoID);
		}

		static public DataTable SEL_ServicioCourier()
		{

			return despachos.SEL_ServicioCourier();

		}

		static public DataTable SEL_Items()
		{

			return despachos.SEL_Items();

		}

		static public DataTable INS_Despacho(DespachosModel objDespachosModel)
		{
			return despachos.INS_Despacho(objDespachosModel);
		}

		}
	}
