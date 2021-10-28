using System;

namespace KaphiyQuipu.Models
{
	public class NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo
	{
        #region Properties


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
