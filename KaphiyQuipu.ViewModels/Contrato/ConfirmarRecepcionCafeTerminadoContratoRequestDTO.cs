using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConfirmarRecepcionCafeTerminadoContratoRequestDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrato { get; set; }
        public int Puntaje { get; set; }
        public string Comentarios { get; set; }
    }
}
