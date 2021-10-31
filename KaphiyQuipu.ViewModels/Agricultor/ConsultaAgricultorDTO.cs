using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaAgricultorDTO
    {
        public ConsultaAgricultorDTO()
        {
        }

        public int SocioId { get; set; }
        public int SocioFincaId { get; set; }
        public string NombreSocio { get; set; }
        public string ApellidoSocio { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroTelefonoCelular { get; set; }
        public string Finca { get; set; }
        public decimal TotalCosecha { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string FechaActualizacionString { get; set; }
    }
}
