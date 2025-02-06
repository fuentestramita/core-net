using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using static BusinessLayer.Comun;

namespace BusinessLayer
{
	static public class Comun
	{
		public static class Tablas
		{
			public const int CALIDADMEROTENEDOR = 0;
			public const int CARROCERIAS = 1;
			public const int CIUDADES = 2;
			public const int COLORES = 3;
			public const int COMBUSTIBLES = 4;
			public const int COMUNAS = 5;
			public const int ESTADOSREGISTRO = 6;
			public const int LIMITACIONES = 7;
			public const int MARCAS = 8;
			public const int MODELOS = 9;
			public const int MONEDAS = 10;
			public const int NATURALEZASDOCTOS = 11;
			public const int NOTARIOS = 12;
			public const int OBSERVACIONES = 13;
			public const int OBSERVACIONESCORREO = 14;
			public const int OBSERVACIONESLIMBO = 15;
			public const int POTENCIAMOTOR = 16;
			public const int REGIONES = 17;
			public const int TIPOSDOCUMENTOS = 18;
			public const int TIPOSVEHICULOS = 19;
			public const int TITULOSMERATENENCIA = 20;
			public const int TRACCION = 21;
			public const int UNIDADMEDIDA = 22;
			public const int VALORESCOBRO = 23;
			public const int OFICINAS = 24;
		}




		static public DataSet SEL_ALL_ds()
		{
			return DataLayer.comun.SEL_ALL();
		}


		static void BulkInsertToSql(DataTable dataTable, string tableName)
		{
			DataLayer.comun.BulkInsertToSql(dataTable, tableName);
			return;
		}


		public static class Clientes
		{
			public const int BANCOCORPBANCA = 1;
			public const int BANCOSANTANDER = 2;
			public const int BANCOCHILE = 3;
			public const int BANCOITAU = 4;
			public const int BANCOCREDITOEINVERSIONES = 5;
			public const int SCANIA = 6;
			public const int SANTANDERFACTORY = 7;
			public const int BODEGASGENERALESDELEASING = 8;
			public const int CLIENTEPRUEBAS = 9;
		}
	}
}
