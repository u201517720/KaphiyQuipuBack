using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class SolicitudCompra
    {
        public SolicitudCompra()
        {

        }

        public int Id { get; set; }
        public string Correlativo { get; set; }
        public string CodigoCliente { get; set; }
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
        public string Observaciones { get; set; }
        public int Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
