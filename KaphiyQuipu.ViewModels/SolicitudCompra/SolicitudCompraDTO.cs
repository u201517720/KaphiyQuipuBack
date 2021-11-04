using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class SolicitudCompraDTO
    {
        public string Correlativo { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Moneda { get; set; }
        public string UnidadMedida { get; set; }
        public string TipoProduccion { get; set; }
        public string Empaque { get; set; }
        public string TipoEmpaque { get; set; }
        public string Producto { get; set; }
        public string SubProducto { get; set; }
        public string GradoPreparacion { get; set; }
        public string Calidad { get; set; }
        public string Distribuidor { get; set; }
        public float CantidadSolicitar { get; set; }
        public float PesoSaco { get; set; }
        public float PesoKilos { get; set; }
        public string Usuario { get; set; }
    }
}
