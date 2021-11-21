using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarPorIdOrdenProcesoDTO
    {
        public int OrdenProcesoId { get; set; }
        public int NotaIngresoAcopioId { get; set; }
        public string Empresa { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public string CorrelativoOP { get; set; }
        public string CorrelativoNI { get; set; }
        public string TipoProduccion { get; set; }
        public string Certificacion { get; set; }
        public string Producto { get; set; }
        public string SubProducto { get; set; }
        public string Calidad { get; set; }
        public string Empaque { get; set; }
        public string TipoEmpaque { get; set; }
        public string Grado { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal PesoSaco { get; set; }
        public decimal PesoKilos { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaInicioProceso { get; set; }
        public string FechaFinProceso { get; set; }
        public string Responsable { get; set; }
        public string EstadoId { get; set; }
        public string TipoProcesoId { get; set; }
    }
}
