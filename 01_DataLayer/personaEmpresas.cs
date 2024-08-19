using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataLayer
{
	static public class personaEmpresas
	{
		static public DataTable SEL_PersonasEmpresas(string PersonaEmpresaID, string RUT)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[2];

			dAccess.AddParameter(ref pPos, "@PersonaEmpresaID", PersonaEmpresaID, SqlDbType.BigInt, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RUT", RUT, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("SEL_PersonasEmpresas", Param).Tables[0];

		}


		static public DataTable INS_PersonaEmpresa(PersonasEmpresasModel modeloPersonaEmpresa)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[12];

			dAccess.AddParameter(ref pPos, "@PersonaEmpresaID", modeloPersonaEmpresa.PersonaEmpresaID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RUT", modeloPersonaEmpresa.RUT, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NombreRazonSocial", modeloPersonaEmpresa.NombreRazonSocial, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ApPaterno", modeloPersonaEmpresa.ApPaterno, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ApMaterno", modeloPersonaEmpresa.ApMaterno, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@EMail", modeloPersonaEmpresa.EMail, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FonoContacto1", modeloPersonaEmpresa.FonoContacto1, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@FonoContacto2", modeloPersonaEmpresa.FonoContacto2, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@Direccion", modeloPersonaEmpresa.Direccion, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@NroDireccion", modeloPersonaEmpresa.NroDireccion, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ComplementoDireccion", modeloPersonaEmpresa.ComplementoDireccion, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@ComunaID", modeloPersonaEmpresa.ComunaID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);


			return dAccess.getData("INS_PersonaEmpresa", Param).Tables[0];

		}

	}
}
