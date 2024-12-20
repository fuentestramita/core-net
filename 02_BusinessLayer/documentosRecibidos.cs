using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Models;

namespace BusinessLayer
{
	static public class DocumentosRecibidos
	{
		static public DataTable SEL_DocumentosRecibidos(string PrimeraInscripcionID, string DocumentoRecibidoID)
		{
			return documentosRecibidos.SEL_DocumentosRecibidos(PrimeraInscripcionID, DocumentoRecibidoID);
		}

		static public DataTable INS_DocumentoRecibido(DocumentosRecibidosModel objDocumentosRecibidos)
		{
			return DataLayer.documentosRecibidos.INS_DocumentoRecibido(objDocumentosRecibidos);
		}

	}
}
