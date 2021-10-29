using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;

namespace KaphiyQuipu.DTO
{
	public class CalculoPrecioDiaRendimientoDTO
	{
		#region Properties

		public decimal PrecioPromedioContrato
		{ get; set; }

		public decimal TipoCambio
		{ get; set; }		

		public List<CalculoPrecioDiaRendimientoBE> CalculoPrecioDiaRendimiento
		{ get; set; }




		#endregion
	}
}
