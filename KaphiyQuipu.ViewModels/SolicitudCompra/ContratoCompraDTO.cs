using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO.SolicitudCompra
{
    public class ContratoCompraDTO
    {
        public int Id { get; set; }
        public string NroContrato { get; set; }
        public string Distribuidor { get; set; }
        public string Producto { get; set; }
        public string SubProducto { get; set; }
        public string TipoProduccion { get; set; }
        public string Calidad { get; set; }
        public string GradoPreparacion { get; set; }
        public DateTime FechaSolicitud { get; set; }
    }
}
