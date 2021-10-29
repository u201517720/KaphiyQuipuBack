using System;

namespace KaphiyQuipu.Models
{
	public class OrdenServicioControlCalidadAnalisisSensorialDefectoDetalleTipo
	{
		#region Properties
		
		/// <summary>
		/// Gets or sets the OrdenServicioControlCalidadId value.
		/// </summary>
		public int OrdenServicioControlCalidadId
		{ get; set; }

		/// <summary>
		/// Gets or sets the DefectoDetalleId value.
		/// </summary>
		public string DefectoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the DefectoDetalleDescripcion value.
		/// </summary>
		public string DefectoDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public bool? Valor
		{ get; set; }

		#endregion
	}
}
