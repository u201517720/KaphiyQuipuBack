using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class ContratoControlCalidad
    {
        public ContratoControlCalidad()
        {

        }

        public int ID { get; set; }
        public int ContratoSocioFincaId { get; set; }
        public decimal Humedad { get; set; }
        public string Observaciones { get; set; }
        public string ListaOlores { get; set; }
        public string ListaColores { get; set; }
        public string HashBC { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int PuntajeValoracion { get; set; }
        public string ComentarioValoracion { get; set; }
    }
}
