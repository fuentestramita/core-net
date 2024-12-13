using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class DespachosModel
	{
		public int errNumber { get; set; }
		public string mensaje { get; set; }

		public string EmpresaID { get; set; }
		public string UsuarioID { get; set; }


		public string DespachoID { get; set; }
		public string PrimeraInscripcionID { get; set; }
		public string Origen { get; set; }
		public string SolicitaDespacho { get; set; }
		public string ImprimirParaEntrega { get; set; }
		public string CodigoDespacho { get; set; }
		public string EntregaEfectuada { get; set; }
		public string PDFEntrega { get; set; }
		public string fechaRecepcion { get; set; }
		public string FechaEntrega { get; set; }
		public string Observacion { get; set; }
		public string FechaRecepcionCourier { get; set; }
		public string FechaEntregaCourier { get; set; }
		public string CodigoDespachoCourier { get; set; }
		public string ServicioCourierID { get; set; }
		public string ItemID { get; set; }
	}

}
