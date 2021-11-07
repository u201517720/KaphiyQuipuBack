using System;

namespace KaphiyQuipu.Models
{
	public class SocioFincaEstimadoTipo
	{
		#region Properties

		public string ProductoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
		public int SocioFincaId
		{ get; set; }

        /// <summary>
        /// Gets or sets the ColorDetalleId value.
        /// </summary>
        public int Anio
		{ get; set; }

		/// <summary>
		/// Gets or sets the ColorDetalleDescripcion value.
		/// </summary>
		

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public decimal Estimado
		{ get; set; }


		public decimal Consumido
		{ get; set; }
		

		#endregion
	}
}
