using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarPorIdNotaSalidaPlantaDTO
    {
        public string CorrelativoNSP { get; set; }
        public string CorrelativoNIP { get; set; }
        public string Acopiador { get; set; }
        public string DireccionAcopiador { get; set; }
        public string Transformadora { get; set; }
        public string RucTransformadora { get; set; }
        public string DireccionTransformadora { get; set; }
        public string Conductor { get; set; }
        public string PlacaTractor { get; set; }
        public string UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public decimal CafeExportacionSacos { get; set; }
        public decimal TotalCafeKgNetos { get; set; }
        public string Certificacion { get; set; }
        public string TipoProduccion { get; set; }
        public string CorrelativoContrato { get; set; }
        public decimal PesoSaco { get; set; }
        public string Producto { get; set; }
        public string SubProducto { get; set; }
        public string Empaque { get; set; }
        public string TipoEmpaque { get; set; }
    }
}
