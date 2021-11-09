using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaPorIdNotaIngresoAcopioControlCalidadDTO
    {
        public int ContratoId { get; set; }
        public int ContratoSocioFincaId { get; set; }
        public decimal Humedad { get; set; }
        public string Observaciones { get; set; }
        public string ListaOlores { get; set; }
        public string ListaColores { get; set; }
        public string NombreCompleto { get; set; }
    }
}
