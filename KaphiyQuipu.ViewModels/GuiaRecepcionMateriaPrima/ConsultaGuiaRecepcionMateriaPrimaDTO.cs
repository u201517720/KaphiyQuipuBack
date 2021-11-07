using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaGuiaRecepcionMateriaPrimaDTO
    {
        public ConsultaGuiaRecepcionMateriaPrimaDTO()
        {

        }

        public int GuiaRecepcionId { get; set; }
        public int ContratoId { get; set; }
        public string Correlativo { get; set; }
        public string CorrelativoContrato { get; set; }
        public string RazonSocial { get; set; }
        public int TotalSacos { get; set; }
        public decimal PesoSaco { get; set; }
        public string Calidad { get; set; }
        public string Certificacion { get; set; }
        public string HashBC { get; set; }
        public string UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
    }
}
