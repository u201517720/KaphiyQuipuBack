using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class GuiaRemisionAcopio
    {
        public int ID { get; set; }
        public string Correlativo { get; set; }
        public int OrdenProcesoId { get; set; }
        public int EmpresaAcopioId { get; set; }
        public int EmpresaProcesadoraId { get; set; }
        public int TransporteId { get; set; }
        public DateTime FechaTraslado { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
