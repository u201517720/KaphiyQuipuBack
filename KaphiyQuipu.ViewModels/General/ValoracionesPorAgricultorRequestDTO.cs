using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ValoracionesPorAgricultorRequestDTO
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Usuario { get; set; }
        public int Tipo { get; set; }
    }
}
