using System;

namespace KaphiyQuipu.Models
{
	public class GuiaRecepcionMateriaPrima
	{
		#region Properties
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

		public string NumeroReferencia
		{ get; set; }

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

		public string TipoProduccionId
		{ get; set; }


		/// <summary>
		/// Gets or sets the ProductoId value.
		/// </summary>
		public string ProductoId
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

		public int? ContratoAsignadoId
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

		public decimal KilosNetosPesado
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

		/// <summary>
		/// Gets or sets the ExportableGramosAnalisisFisico value.
		/// </summary>
		public decimal? ExportableGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the ExportablePorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? ExportablePorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescarteGramosAnalisisFisico value.
		/// </summary>
		public decimal? DescarteGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the DescartePorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? DescartePorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the CascarillaGramosAnalisisFisico value.
		/// </summary>
		public decimal? CascarillaGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the CascarillaPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? CascarillaPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalGramosAnalisisFisico value.
		/// </summary>
		public decimal? TotalGramosAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the TotalPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? TotalPorcentajeAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the HumedadPorcentajeAnalisisFisico value.
		/// </summary>
		public decimal? HumedadPorcentajeAnalisisFisico
		{ get; set; }

		public decimal? TotalAnalisisSensorial
		{ get; set; }

		public decimal? SubTotalAnalisisSensorial
		{ get; set; }

		public decimal? DefectosTasaAnalisisSensorial
		{ get; set; }


		public decimal? DefectosIntensidadAnalisisSensorial
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisFisico value.
		/// </summary>
		public string ObservacionAnalisisFisico
		{ get; set; }

		/// <summary>
		/// Gets or sets the FechaCalidad value.
		/// </summary>
		public DateTime? FechaCalidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioCalidad value.
		/// </summary>
		public string UsuarioCalidad
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionRegistroTostado value.
		/// </summary>
		public string ObservacionRegistroTostado
		{ get; set; }

		/// <summary>
		/// Gets or sets the ObservacionAnalisisSensorial value.
		/// </summary>
		public string ObservacionAnalisisSensorial
		{ get; set; }


		public int? SocioFincaId
		{ get; set; }

		public int? TerceroFincaId
		{ get; set; }

		public string IntermediarioFinca
		{ get; set; }

		public string SocioFincaCertificacion
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
		/// Gets or sets the FechaUltimaActualizacion value.
		/// </summary>
		public DateTime? FechaUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the UsuarioUltimaActualizacion value.
		/// </summary>
		public string UsuarioUltimaActualizacion
		{ get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo
		{ get; set; }

		#endregion
	}
}
