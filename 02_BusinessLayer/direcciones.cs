using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
{
	static public class Direcciones
	{
		static public DataTable SEL_Direccion(string DireccionID, string PersonaEmpresaID)
		{
			return DataLayer.direcciones.SEL_Direccion(DireccionID, PersonaEmpresaID);
		}

		static public DataTable INS_Direccion(DireccionModel modeloDireccion)
		{
			return DataLayer.direcciones.INS_Direccion(modeloDireccion);
		}

	}
}

