using System;

namespace KaphiyQuipu.Models
{
	public class NotaIngresoPlantaAnalisisFisicoOlorDetalle
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaIngresoPlantaAnalisisFisicoOlorDetalleId value.
		/// </summary>
		public int NotaIngresoPlantaAnalisisFisicoOlorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the NotaIngresoPlantaId value.
		/// </summary>
		public int NotaIngresoPlantaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OlorDetalleId value.
		/// </summary>
		public string OlorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the OlorDetalleDescripcion value.
		/// </summary>
		public string OlorDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public bool? Valor
		{ get; set; }

		#endregion
	}
}
