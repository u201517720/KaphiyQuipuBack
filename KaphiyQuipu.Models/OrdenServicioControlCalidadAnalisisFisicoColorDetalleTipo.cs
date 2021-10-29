using System;

namespace KaphiyQuipu.Models
{
	public class OrdenServicioControlCalidadAnalisisFisicoColorDetalleTipo
	{
        #region Properties

        /// <summary>
        /// Gets or sets the OrdenServicioControlCalidadId value.
        /// </summary>
        public int OrdenServicioControlCalidadId
        { get; set; }

        /// <summary>
        /// Gets or sets the ColorDetalleId value.
        /// </summary>
        public string ColorDetalleId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ColorDetalleDescripcion value.
		/// </summary>
		public string ColorDetalleDescripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public bool? Valor
		{ get; set; }

		#endregion
	}
}
