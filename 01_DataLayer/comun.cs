using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	static public class comun
	{


		static public DataSet SEL_ALL()
		{
			DataAccess dAccess = new DataAccess();
			dAccess.Open("tramita_db");
			return dAccess.getData("SEL_ALL");
		}



		static public  void BulkInsertToSql(DataTable dataTable, string tableName)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tramita_db"].ToString();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
				{
					bulkCopy.DestinationTableName = tableName;

					// Mapea las columnas del DataTable a las columnas de la tabla SQL
					foreach (DataColumn column in dataTable.Columns)
					{
						bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
					}

					bulkCopy.WriteToServer(dataTable);
				}
			}
		}
	}



}
