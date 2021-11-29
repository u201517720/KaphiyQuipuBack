using System;

namespace KaphiyQuipu.Models
{
    public class Contrato
    {
        public Contrato()
        {

        }

        public int ContratoId { get; set; }
        public string Correlativo { get; set; }
        public int SolicitudCompraId { get; set; }
        public int EmpresaId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal Tara { get; set; }
        public decimal KilosNetos { get; set; }
        public string Observaciones { get; set; }
        public string HashBC { get; set; }
        public int Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
