﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
   public class RegistrarActualizarPesadoGuiaRecepcionMateriaPrimaRequestDTO
    {
		public int GuiaRecepcionMateriaPrimaId
		{ get; set; }

		

		/// <summary>
		/// Gets or sets the EmpresaId value.
		/// </summary>
		public int EmpresaId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		

		/// <summary>
		/// Gets or sets the TipoProvedorId value.
		/// </summary>
		public string TipoProvedorId
		{ get; set; }

		/// <summary>
		/// Gets or sets the SocioId value.
		/// </summary>
		public int? SocioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the TerceroId value.
		/// </summary>
		public int? TerceroId
		{ get; set; }

		/// <summary>
		/// Gets or sets the IntermediarioId value.
		/// </summary>
		public int? IntermediarioId
		{ get; set; }

		/// <summary>
		/// Gets or sets the ProductoId value.
		/// </summary>
		public string ProductoId
		{ get; set; }

		public string NumeroReferencia
		{ get; set; }

		public string SocioFincaCertificacion
		{ get; set; }


		/// <summary>
		/// Gets or sets the SubProductoId value.
		/// </summary>
		public string SubProductoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaCosecha value.
		/// </summary>
		public DateTime FechaCosecha
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaPesado value.
		/// </summary>
		public DateTime FechaPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioPesado value.
		/// </summary>
		public string UsuarioPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the UnidadMedidaIdPesado value.
		/// </summary>
		public string UnidadMedidaIdPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the CantidadPesado value.
		/// </summary>
		public decimal CantidadPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosBrutosPesado value.
		/// </summary>
		public decimal KilosBrutosPesado
		{ get; set; }



		/// <summary>
		/// Gets or sets the TaraPesado value.
		/// </summary>
		public decimal TaraPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionPesado value.
		/// </summary>
		public string ObservacionPesado
		{ get; set; }

		public int? SocioFincaId
		{ get; set; }

		public int? TerceroFincaId
		{ get; set; }

		public string IntermediarioFinca
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>

		public string TipoProduccionId
		{ get; set; }
		

	}
}
