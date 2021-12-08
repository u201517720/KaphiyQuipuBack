using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class RegistrarDevolucionGuiaRemisionRequestDTO
    {
        public int NotaIngresoDevolucionId { get; set; }
        public string UsuarioRegistro { get; set; }
        public string Contrato { get; set; }
    }
}
