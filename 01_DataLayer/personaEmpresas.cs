using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utilities;

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

			dAccess.AddParameter(ref pPos, "@PersonaEmpresaID", utils.isNull(PersonaEmpresaID,"0"), SqlDbType.BigInt, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "@RUT", RUT, SqlDbType.VarChar, 0, 0, ParameterDirection.Input, ref Param);

			return dAccess.getData("SEL_PersonasEmpresas", Param).Tables[0];

		}


		static public DataTable INS_PersonaEmpresa(PersonasEmpresasModel modeloPersonaEmpresa)
		{
			int pPos = 0;
			DataAccess dAccess = new DataAccess();

			dAccess.Open("tramita_db");
			SqlParameter[] Param = new SqlParameter[12];
			dAccess.AddParameter(ref pPos, "EmpresaID", modeloPersonaEmpresa.EmpresaID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "UsuarioID", modeloPersonaEmpresa.UsuarioID, SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "PersonaEmpresaID", utils.isNull(modeloPersonaEmpresa.PersonaEmpresaID), SqlDbType.BigInt, 0, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "RUT", modeloPersonaEmpresa.RUT, SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "NombreRazonSocial", utils.isNull(modeloPersonaEmpresa.NombreRazonSocial), SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "ApPaterno", utils.isNull(modeloPersonaEmpresa.ApPaterno), SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "ApMaterno", utils.isNull(modeloPersonaEmpresa.ApMaterno), SqlDbType.VarChar, 128, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "EMail", utils.isNull(modeloPersonaEmpresa.EMail), SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "FonoPersona", utils.isNull(modeloPersonaEmpresa.FonoPersona), SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "NombreContacto", utils.isNull(modeloPersonaEmpresa.NombreContacto), SqlDbType.VarChar, 255, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "FonoContacto", utils.isNull(modeloPersonaEmpresa.FonoContacto), SqlDbType.VarChar, 20, 0, ParameterDirection.Input, ref Param);
			dAccess.AddParameter(ref pPos, "EMailContacto", utils.isNull(modeloPersonaEmpresa.EMailContacto), SqlDbType.VarChar, 50, 0, ParameterDirection.Input, ref Param);


			return dAccess.getData("INS_PersonaEmpresa", Param).Tables[0];

		}


	}
}
