using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarPorIdNotaIngresoPlantaDTO
    {
        public int GuiaRemisionId { get; set; }
        public string CorrelativoGRA { get; set; }
        public string CorrelativoNIP { get; set; }
        public string Empresa { get; set; }
        public string EmpresaRUC { get; set; }
        public string EmpresaDireccion { get; set; }
        public string Conductor { get; set; }
        public string PlacaTractor { get; set; }
        public string Certificacion { get; set; }
        public string Producto { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal KilosBrutosPC { get; set; }
        public decimal TaraSacoPC { get; set; }
        public decimal KilosNetos { get; set; }
        public string Observaciones { get; set; }
        public string FechaRegistro { get; set; }
        public string EstadoId { get; set; }
        public string Responsable { get; set; }
        public string Olores { get; set; }
        public string Colores { get; set; }
        public decimal ExportableGramos { get; set; }
        public decimal ExportablePorcentaje { get; set; }
        public decimal DescarteGramos { get; set; }
        public decimal DescartePorcentaje { get; set; }
        public decimal CascarillaGramos { get; set; }
        public decimal CascarillaPorcentaje { get; set; }
        public decimal TotalGramos { get; set; }
        public decimal TotalPorcentaje { get; set; }
        public decimal HumedadPorcentaje { get; set; }
    }
}
