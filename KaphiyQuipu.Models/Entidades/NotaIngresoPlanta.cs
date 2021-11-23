using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class NotaIngresoPlanta
    {
        public int Id { get; set; }
        public string Correlativo { get; set; }
        public int GuiaRemisionAcopioId { get; set; }
        public string Observaciones { get; set; }
        public string HashBC { get; set; }
        public string Olores { get; set; }
        public string Colores { get; set; }
        public decimal? ExportableGramos { get; set; }
        public decimal? ExportablePorcentaje { get; set; }
        public decimal? DescarteGramos { get; set; }
        public decimal? DescartePorcentaje { get; set; }
        public decimal? CascarillaGramos { get; set; }
        public decimal? CascarillaPorcentaje { get; set; }
        public decimal? TotalGramos { get; set; }
        public decimal? TotalPorcentaje { get; set; }
        public decimal? HumedadPorcentaje { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
