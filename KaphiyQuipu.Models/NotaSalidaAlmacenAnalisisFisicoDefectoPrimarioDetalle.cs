using System;

namespace KaphiyQuipu.Models
{
	public class NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleId value.
		/// </summary>
		public int NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaSalidaAlmacenId value.
		/// </summary>
		public int NotaSalidaAlmacenId
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
		/// Gets or sets the DefectoDetalleEquivalente value.
		/// </summary>
		public string DefectoDetalleEquivalente
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public decimal? Valor
		{ get; set; }

		#endregion
	}
}
