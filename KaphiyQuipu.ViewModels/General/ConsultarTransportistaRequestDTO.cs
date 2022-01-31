using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarTransportistaRequestDTO
    {
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public int ContratoId { get; set; }
    }
}
