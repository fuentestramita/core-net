using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class PersonasEmpresasModel
	{
		public int errNumber { get; set; }
		public string mensaje { get; set; } = "";

		public string EmpresaID { get; set; }
		public string UsuarioID { get; set; }
		public string PersonaEmpresaID { get; set; }
		public string RUT { get; set; } = "";
		public string NombreRazonSocial { get; set; } = "";
		public string ApPaterno { get; set; } = "";
		public string ApMaterno { get; set; } = "";
		public string EMail { get; set; } = "";
		public string FonoPersona { get; set; } = "";
		public string NombreContacto { get; set; } = "";
		public string FonoContacto { get; set; } = "";
		public string EMailContacto { get; set; } = "";
	}

}
