using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaSolicitudCompraRequestDTO
    {
        public ConsultaSolicitudCompraRequestDTO()
        {

        }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int RolId { get; set; }
        public string CodigoCliente { get; set; }
    }
}
