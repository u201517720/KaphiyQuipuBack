﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
   public class LiquidarNotaCompraRequestDTO
    {

        public int NotaCompraId { get; set; }
        public String Usuario { get; set; }

		public String MonedaId { get; set; }

		public decimal PrecioPagado
		{ get; set; }

		/// <summary>
		/// Gets or sets the Importe value.
		/// </summary>
		public decimal Importe
		{ get; set; }

		


		public decimal? TotalAdelanto
		{ get; set; }

		public decimal TotalPagar
		{ get; set; }

	}
}
