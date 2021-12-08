using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class RegistrarNotaIngresoPlantaRequestDTO
    {
        public int GuiaRemisionAcopioId { get; set; }
        public string Observaciones { get; set; }
        public string UsuarioRegistro { get; set; }
        public string Contrato { get; set; }
    }
}
