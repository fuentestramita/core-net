using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class DocumentosRecibidosModel
	{
		public int errNumber { get; set; }
		public string mensaje { get; set; }

		public string EmpresaID { get; set; }
		public string UsuarioID { get; set; }
		public string DocumentoRecibidoID { get; set; }
		public string PrimeraInscripcionID { get; set; }
		public string TipoDocumentoID { get; set; }
		public string NaturalezaAdquisicion { get; set; } = "";
		public string NumeroDocumentoCausa { get; set; } = "";
		public string ValorNeto { get; set; }
		public string ValorIVAFactura { get; set; }
		public string ValorTotalFactura { get; set; }
		public string LugarDocumento { get; set; }
		public string FechaDocumento { get; set; }
		public string NombreAutorizanteEmisor { get; set; }
		public string AcreedorBeneficiarioDemandante { get; set; }
		public string PDF { get; set; }
		public string EmisorDocumentoID { get; set; }

	}

}
