using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaMateriaPrimaSolicitadaRequestDTO
    {
        public ConsultaMateriaPrimaSolicitadaRequestDTO()
        {

        }

        public int UserId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
