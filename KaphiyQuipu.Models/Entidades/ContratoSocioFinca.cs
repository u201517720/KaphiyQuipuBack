using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class ContratoSocioFinca
    {
        public ContratoSocioFinca()
        {

        }

        public int ID { get; set; }
        public int ContratoId { get; set; }
        public int SocioFincaId { get; set; }
        public int CantidadSolicitada { get; set; }
        public string HashBC { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
