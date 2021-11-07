using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ObtenerAgricultoresPorContratoDTO
    {
        public ObtenerAgricultoresPorContratoDTO()
        {

        }

        public int ContratoSocioFincaId { get; set; }
        public string NombreSocio { get; set; }
        public string ApellidoSocio { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroTelefonoCelular { get; set; }
        public string Finca { get; set; }
        public string TipoCertificacion { get; set; }
        public int CantidadSolicitada { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string FechaRegistroString { get; set; }
    }
}
