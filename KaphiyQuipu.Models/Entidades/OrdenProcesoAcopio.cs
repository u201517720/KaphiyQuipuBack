using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class OrdenProcesoAcopio
    {
        public int ID { get; set; }
        public string Correlativo { get; set; }
        public int NotaIngresoAcopioId { get; set; }
        public string TipoProcesoId { get; set; }
        public int ResponsableId { get; set; }
        public DateTime? FechaInicioProceso { get; set; }
        public DateTime? FechaFinProceso { get; set; }
        public string hashBC { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
