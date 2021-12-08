using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class RegistrarControlCalidadNotaIngresoPlantaRequestDTO
    {
        public int Id { get; set; }
        public string Olores { get; set; }
        public string DescripcionOlores { get; set; }
        public string Colores { get; set; }
        public string DescripcionColores { get; set; }
        public decimal ExportableGramos { get; set; }
        public decimal ExportablePorcentaje { get; set; }
        public decimal DescarteGramos { get; set; }
        public decimal DescartePorcentaje { get; set; }
        public decimal CascarillaGramos { get; set; }
        public decimal CascarillaPorcentaje { get; set; }
        public decimal TotalGramos { get; set; }
        public decimal TotalPorcentaje { get; set; }
        public decimal HumedadPorcentaje { get; set; }
        public string HashBC { get; set; }
        public string UsuarioActualizacion { get; set; }
    }
}
