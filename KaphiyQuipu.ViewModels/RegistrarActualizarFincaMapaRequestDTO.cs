﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
	public class RegistrarActualizarFincaMapaRequestDTO
	{
		/// <summary>
		/// Gets or sets the FincaMapaId value.
		/// </summary>
		public int FincaMapaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the FincaId value.
		/// </summary>
		public int FincaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string Nombre
		{ get; set; }

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string Descripcion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Path value.
		/// </summary>
		public string Path
		{ get; set; }


		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string Usuario
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		

	}
}
