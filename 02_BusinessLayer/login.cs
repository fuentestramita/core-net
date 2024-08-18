using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
	static public class login
	{
		static public DataTable SEL_Login(string RutUsuario, string ClaveUsuario)
		{
			return DataLayer.login.SEL_Login(RutUsuario, ClaveUsuario);
		}

		static public DataTable INS_CodigoLogin(string UsuarioID, string CodigoAccesoUsuario)
		{

			return DataLayer.login.INS_CodigoLogin(UsuarioID, CodigoAccesoUsuario);
		}

		static public DataTable SEL_ValidaCodigoUsuario(string RutUsuario, string CodigoUsuario)
		{

			return DataLayer.login.SEL_ValidaCodigoUsuario(RutUsuario, CodigoUsuario);
		}

}
}
