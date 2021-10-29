using System;

namespace KaphiyQuipu.Models
{
	public class NotaCompra
	{
		#region Properties
		/// <summary>
		/// Gets or sets the NotaCompraId value.
		/// </summary>
		public int NotaCompraId
		{ get; set; }

		/// <summary>
		/// Gets or sets the GuiaRecepcionMateriaPrimaId value.
		/// </summary>
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
		public string Numero
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
		/// Gets or sets the KilosNetosPesado value.
		/// </summary>
		public decimal KilosNetosPesado
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescuentoPorHumedad value.
		/// </summary>
		public decimal DescuentoPorHumedad
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosNetosDescontar value.
		/// </summary>
		public decimal KilosNetosDescontar
		{ get; set; }

		/// <summary>
		/// Gets or sets the KilosNetosPagar value.
		/// </summary>
		public decimal KilosNetosPagar
		{ get; set; }

		/// <summary>
		/// Gets or sets the QQ55 value.
		/// </summary>
		public decimal QQ55
		{ get; set; }

		
		/// <summary>
		/// Gets or sets the TipoId value.
		/// </summary>
		public string TipoId
		{ get; set; }

		public int ValorId
		{ get; set; }
		

		/// <summary>
		/// Gets or sets the MonedaId value.
		/// </summary>
		public string MonedaId
		{ get; set; }
		/// <summary>
		/// Gets or sets the PrecioGuardado value.
		/// </summary>
		public decimal? PrecioGuardado
		{ get; set; }

		/// <summary>
		/// Gets or sets the PrecioPagado value.
		/// </summary>
		public decimal? PrecioPagado
		{ get; set; }

		/// <summary>
		/// Gets or sets the Importe value.
		/// </summary>
		public decimal? Importe
		{ get; set; }

		/// <summary>
		/// Gets or sets the EstadoId value.
		/// </summary>
		public string EstadoId
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaRegistro value.
		/// </summary>
		public DateTime FechaRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioRegistro value.
		/// </summary>
		public string UsuarioRegistro
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioLiquidacion value.
		/// </summary>
		public string UsuarioLiquidacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaLiquidacion value.
		/// </summary>
		public DateTime? FechaLiquidacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaUltimaActualizacion value.
		/// </summary>
		public DateTime? FechaUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioUltimaActualizacion value.
		/// </summary>
		public string UsuarioUltimaActualizacion
		{ get; set; }

		public DateTime FechaCosecha
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		public string Observaciones
		{ get; set; }
		#endregion
	}
}
