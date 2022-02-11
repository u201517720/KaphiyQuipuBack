using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarPorIdGuiaRemisionAcopioDTO
    {
        public string CorrelativoGRA { get; set; }
        public string CorrelativoOP { get; set; }
        public string EmpresaAcopio { get; set; }
        public string RucAcopio { get; set; }
        public string DireccionAcopio { get; set; }
        public string EmpresaTransformadora { get; set; }
        public string RucTransformadora { get; set; }
        public string DireccionTransformadora { get; set; }
        public string FechaTraslado { get; set; }
        public string FechaEmision { get; set; }
        public string MotivoSalida { get; set; }
        //public string Conductor { get; set; }
        //public string RucTransporte { get; set; }
        //public string PlacaTractor { get; set; }
        //public string Licencia { get; set; }
        //public string NumeroConstanciaMTC { get; set; }
        //public string MarcaVehiculo { get; set; }
        public string CorrelativoContrato { get; set; }
        public string Producto { get; set; }
        public string UnidadMedida { get; set; }
        public string TipoProduccion { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal PesoKilos { get; set; }
        public string EstadoId { get; set; }
    }
}
