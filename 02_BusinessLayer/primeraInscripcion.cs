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
	static public class PrimeraInscripcion
	{
		static public DataTable SEL_PrimeraInscripcion(string EmpresaID, string PrimeraInscripcionID, string PPU, string NroFactura, string RutFactura)
		{
			return DataLayer.primeraInscripcion.SEL_PrimeraInscripcion(EmpresaID, PrimeraInscripcionID, PPU, NroFactura, RutFactura);
		}

		static public DataTable INS_PrimeraInscripcion(PrimeraInscripcionModel modeloPrimeraInscripcion)
		{
			return DataLayer.primeraInscripcion.INS_PrimeraInscripcion(modeloPrimeraInscripcion);
		}

	}
}

