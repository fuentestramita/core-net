using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
		public class ContactoModel
		{
			public int errNumber  { get; set; }
			public string mensaje { get; set; }

			public string ContactoID { get; set; }
			public string Contacto { get; set; }
			public string Telefono { get; set; }
			public string Email { get; set; }
			public string DireccionID { get; set; }
			}

}
