
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaContratoPorIdDTO
    {
        public int ContratoId { get; set; }
        public string Correlativo { get; set; }
        public int DistribuidorId { get; set; }
        public string Distribuidor { get; set; }
        public string PaisId { get; set; }
        public string DepartamentoId { get; set; }
        public string MonedaId { get; set; }
        public string UnidadMedidaId { get; set; }
        public string TipoProduccionId { get; set; }
        public string EmpaqueId { get; set; }
        public string TipoEmpaqueId { get; set; }
        public int TotalSacos { get; set; }
        public decimal PesoSaco { get; set; }
        public decimal PesoKilos { get; set; }
        public string ProductoId { get; set; }
        public string SubProductoId { get; set; }
        public string GradoPreparacionId { get; set; }
        public string CalidadId { get; set; }
        public string CertificacionId { get; set; }
        public string ObservacionesSolicitud { get; set; }
        public string ObservacionesContrato { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string DescripcionEstado { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string FechaRegistroString { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string FechaActualizacionString { get; set; }
    }
}
