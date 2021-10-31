using System;

namespace KaphiyQuipu.DTO
{
    public class ConsultaContratoDTO
    {
        public ConsultaContratoDTO()
        {

        }
        public int ContratoId { get; set; }
        public string CorrelativoContrato { get; set; }
        public int SolicitudCompraId { get; set; }
        public string CorrelativoSolicitud { get; set; }
        public int DistribuidorId { get; set; }
        public string RazonSocial { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int SubProductoId { get; set; }
        public string SubProducto { get; set; }
        public int CalidadId { get; set; }
        public string Calidad { get; set; }
        public string EstadoId { get; set; }
        public string DescripcionEstado { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistroString { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string FechaActualizacionString { get; set; }
    }
}
