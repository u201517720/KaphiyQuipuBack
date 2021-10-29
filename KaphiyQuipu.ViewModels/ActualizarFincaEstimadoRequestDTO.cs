﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
   public class ActualizarFincaEstimadoRequestDTO
	{

		//public int GuiaRecepcionMateriaPrimaId
		//{ get; set; }

		/// <summary>
		/// Gets or sets the DefectoDetalleId value.
		/// </summary>
		public int Anio
		{ get; set; }

		/// <summary>
		/// Gets or sets the DefectoDetalleDescripcion value.
		/// </summary>
		public decimal Estimado
		{ get; set; }

		public decimal Consumido
		{ get; set; }

		public string ProductoId
		{ get; set; }

		


	}
}
