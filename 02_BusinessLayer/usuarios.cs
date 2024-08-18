using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BusinessLayer
{
	static public class usuarios
	{
		static public DataTable SEL_MenuUsuario(string UsuarioID)
		{
			return DataLayer.usuarios.SEL_MenuUsuario(UsuarioID);
		}

	}
}

