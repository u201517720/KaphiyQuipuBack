using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ListarCosechasPorAgricultorDTO
    {
        public int SocioFincaCosechaId { get; set; }
        public string Codigo { get; set; }
        public string UnidadMedicionId { get; set; }
        public string UnidadMedida { get; set; }
        public string TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string Finca { get; set; }
        public decimal PesoNeto { get; set; }
        public string FechaRegistroString { get; set; }
        public string FechaActualizacionString { get; set; }
        public string TipoDocumento { get; set; }
        public string FechaCosechaString { get; set; }
    }
}
