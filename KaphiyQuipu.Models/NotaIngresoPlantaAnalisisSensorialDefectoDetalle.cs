using System;

namespace KaphiyQuipu.Models
{
	public class NotaIngresoPlantaAnalisisSensorialDefectoDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoPlantaAnalisisSensorialDefectoDetalleId value.
		/// </summary>
		public int NotaIngresoPlantaAnalisisSensorialDefectoDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public int NotaIngresoPlantaId
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
