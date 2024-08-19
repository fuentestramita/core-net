using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
		public class DireccionModel
		{
			public int errNumber  { get; set; }
			public string mensaje { get; set; }

			public string DireccionID { get; set; }
			public string Direccion { get; set; }
			public string NumeroDireccion { get; set; }
			public string ComplementoDireccion { get; set; }
			public string PersonaEmpresaID { get; set; }
			public string ComunaID { get; set; }
			}

}
