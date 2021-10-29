using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaSolicitudCompraDTO
    {
        public ConsultaSolicitudCompraDTO()
        {
        }

        public int SolicitudCompraId { get; set; }
        public string Correlativo { get; set; }
        public string RazonSocial { get; set; }
        public string ProductoId { get; set; }
        public string Producto { get; set; }
        public string SubProductoId { get; set; }
        public string SubProducto { get; set; }
        public string CalidadId { get; set; }
        public string Calidad { get; set; }
        public string EstadoId { get; set; }
        public string DescripcionEstado { get; set; }
        public bool Estado { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string FechaRegistroString { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string FechaActualizacionString { get; set; }
    }
}
