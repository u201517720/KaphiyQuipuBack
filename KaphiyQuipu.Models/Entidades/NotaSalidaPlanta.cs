using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class NotaSalidaPlanta
    {
        public int ID { get; set; }
        public string Correlativo { get; set; }
        public int NotaIngresoPlantaId { get; set; }
        public int EmpresaAcopioId { get; set; }
        public int EmpresaProcesadoraId { get; set; }
        public int TransporteId { get; set; }
        public string HashBC { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
