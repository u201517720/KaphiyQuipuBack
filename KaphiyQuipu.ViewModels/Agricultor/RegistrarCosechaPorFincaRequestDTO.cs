using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class RegistrarCosechaPorFincaRequestDTO
    {
        public int CodigoSocioFinca { get; set; }
        public decimal PesoNeto { get; set; }
        public DateTime FechaCosecha { get; set; }
        public string UnidadMedida { get; set; }
        public string Usuario { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
