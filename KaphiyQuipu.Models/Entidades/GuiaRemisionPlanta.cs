using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class GuiaRemisionPlanta
    {
        public int ID { get; set; }
        public string Correlativo { get; set; }
        public int NotaSalidaPlantaId { get; set; }
        public string MotivoTrasladoId { get; set; }
        public DateTime FechaTraslado { get; set; }
        public DateTime FechaEmision { get; set; }
        public string HashBC { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
