using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class LoginModel
	{
		public int errNumber { get; set; }
		public string mensaje { get; set; }

		public string UsuarioID { get; set; }
		public string NombreUsuario { get; set; }
		public string EmailUsuario { get; set; }

	}

}
