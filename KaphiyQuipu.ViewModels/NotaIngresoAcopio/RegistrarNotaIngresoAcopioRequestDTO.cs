using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class RegistrarNotaIngresoAcopioRequestDTO
    {
        public RegistrarNotaIngresoAcopioRequestDTO()
        {

        }

        public int GuiaRecepcionId { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
