using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConfirmarEnvioRequestDTO
    {
        public ConfirmarEnvioRequestDTO()
        {

        }

        public int ContratoSocioFincaId { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
