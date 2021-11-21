using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarOrdenProcesoAcopioDTO
    {
        public int OrdenProcesoId { get; set; }
        public string CorrelativoOP { get; set; }
        public string CorrelativoNIA { get; set; }
        public string TipoProceso { get; set; }
        public string Responsable { get; set; }
        public string FechaInicioProceso { get; set; }
        public string FechaFinProceso { get; set; }
        public string UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public string FechaActualizacion { get; set; }
    }
}
