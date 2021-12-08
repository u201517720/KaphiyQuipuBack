using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class RegistrarDevolucionNotaIngresoRequestDTO
    {
        public string Correlativo { get; set; }
        public int GuiaRemisionPlantaId { get; set; }
        public string AlmacenId { get; set; }
        public string Observaciones { get; set; }
        public string HashBC { get; set; }
        public string UsuarioRegistro { get; set; }
        public string Contrato { get; set; }
    }
}
