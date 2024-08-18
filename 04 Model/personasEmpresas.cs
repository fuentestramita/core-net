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
		public string mensaje { get; set; }

		public string PersonaEmpresaID { get; set; }
		public string RUT { get; set; }
		public string NombreRazonSocial { get; set; }
		public string ApPaterno { get; set; }
		public string ApMaterno { get; set; }
		public string EMail { get; set; }
		public string FonoContacto1 { get; set; }
		public string FonoContacto2 { get; set; }
		public string Direccion { get; set; }
		public string NroDireccion { get; set; }
		public string ComplementoDireccion { get; set; }
		public string ComunaID { get; set; }
	}

}
