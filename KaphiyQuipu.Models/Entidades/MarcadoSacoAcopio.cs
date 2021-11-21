using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class MarcadoSacoAcopio
    {
        public int ID { get; set; }
        public string Correlativo { get; set; }
        public int OrdenProcesoId { get; set; }
        public int EmpresaId { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
