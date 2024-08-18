using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
	static public class Vehiculos
	{
		static public DataTable SEL_VEHICULOS(string VehiculoID)
		{
			return vehiculos.SEL_VEHICULOS(VehiculoID);
		}


	}
}
