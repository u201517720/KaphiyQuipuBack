﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class NotaIngresoPlanta
    {
        public int ID { get; set; }
        public string Correlativo { get; set; }
        public int GuiaRemisionAcopioId { get; set; }
        public string Observaciones { get; set; }
        public string HashBC { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
