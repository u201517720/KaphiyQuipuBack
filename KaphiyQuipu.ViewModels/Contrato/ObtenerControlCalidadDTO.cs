using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ObtenerControlCalidadDTO
    {
        public int ContratoSocioFincaId { get; set; }
        public string NombreCompleto { get; set; }
        public decimal Humedad { get; set; }
        public string Observaciones { get; set; }
        public string ListaOlores { get; set; }
        public string ListaColores { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int Puntaje { get; set; }
        public string Comentarios { get; set; }
    }
}
