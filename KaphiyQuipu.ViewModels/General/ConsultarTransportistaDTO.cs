using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarTransportistaDTO
    {
        public int TransporteId { get; set; }
        public string Conductor { get; set; }
        public string Dni { get; set; }
        public string NroCelular { get; set; }
        public string PlacaCarreta { get; set; }
        public string Licencia { get; set; }
        public string Soat { get; set; }
    }
}
