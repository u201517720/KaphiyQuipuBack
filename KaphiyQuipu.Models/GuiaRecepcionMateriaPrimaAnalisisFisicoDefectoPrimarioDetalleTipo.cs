using System;

namespace CoffeeConnect.Models
{
	public class GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo
	{
        #region Properties


        /// <summary>
        /// Gets or sets the GuiaRecepcionMateriaPrimaId value.
        /// </summary>
        public int GuiaRecepcionMateriaPrimaId
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
