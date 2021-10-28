using System;

namespace KaphiyQuipu.Models
{
	public class GuiaRemisionAlmacenDetalleTipo
	{
		#region Properties
		public int GuiaRemisionAlmacenId { get; set; }
		public int LoteId { get; set; }

		

		
		public String NumeroLote { get; set; }
		
		public String ProductoId { get; set; }
		public String SubProductoId { get; set; }
		public String UnidadMedidaIdPesado { get; set; }
		public Decimal CantidadPesado { get; set; }

		public Decimal KilosNetosPesado { get; set; }

		public Decimal KilosBrutosPesado { get; set; }		
		

		public Decimal RendimientoPorcentaje { get; set; }
		public Decimal HumedadPorcentaje { get; set; }

		public DateTime FechaLote { get; set; }

		public String TipoProduccionId { get; set; }

		public String TipoCertificacionId { get; set; }

		#endregion
	}
}
