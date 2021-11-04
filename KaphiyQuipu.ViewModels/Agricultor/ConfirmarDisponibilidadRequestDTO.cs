using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConfirmarDisponibilidadRequestDTO
    {
        public ConfirmarDisponibilidadRequestDTO()
        {

        }

        public int ContratoSocioFincaId { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
