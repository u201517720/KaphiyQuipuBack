using System;

namespace KaphiyQuipu.Models
{
	public class OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleTipo
	{
		#region Properties
		
		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadId value.
		/// </summary>
		public int OrdenServicioControlCalidadId
		{ get; set; }

		/// <summary>
		/// Gets or sets the AtributoDetalleId value.
		/// </summary>
		public string AtributoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the AtributoDetalleDescripcion value.
		/// </summary>
		public string AtributoDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public decimal? Valor
		{ get; set; }

		#endregion
	}
}
