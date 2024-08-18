using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
	static public class Empresas
	{
		static public DataTable SEL_EMPRESAS()
		{
			return DataLayer.Empresas.SEL_EMPRESAS();
		}


}
}
