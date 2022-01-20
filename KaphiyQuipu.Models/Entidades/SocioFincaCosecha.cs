using System;

namespace KaphiyQuipu.Models
{
    public class SocioFincaCosecha
    {
        public int ID { get; set; }
        public int SocioFincaId { get; set; }
        public decimal Cantidad { get; set; }
        public bool Estado { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string EstadoId { get; set; }
        public DateTime FechaCosecha { get; set; }
        public string UnidadMedicionId { get; set; }
    }
}
