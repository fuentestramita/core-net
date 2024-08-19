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
	static public class PersonaEmpresas
	{
		static public DataTable SEL_PersonasEmpresas(string PersonaEmpresaID, string RUT)
		{
			return DataLayer.personaEmpresas.SEL_PersonasEmpresas(PersonaEmpresaID, RUT);
		}

		static public DataTable INS_PersonaEmpresa(PersonasEmpresasModel modeloPersonaEmpresan)
		{
			return DataLayer.personaEmpresas.INS_PersonaEmpresa(modeloPersonaEmpresan);
		}

	}
}

