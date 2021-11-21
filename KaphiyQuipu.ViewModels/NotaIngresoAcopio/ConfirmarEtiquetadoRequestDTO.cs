using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConfirmarEtiquetadoRequestDTO
    {
        public int NotaIngresoId { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Correlativo { get; set; }
    }
}
