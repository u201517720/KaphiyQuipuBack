using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class EvaluarDisponibilidadDTO
    {
        public bool Aceptado { get; set; }
        public string Mensaje { get; set; }
        public decimal CantidadDisponible { get; set; }
    }
}
