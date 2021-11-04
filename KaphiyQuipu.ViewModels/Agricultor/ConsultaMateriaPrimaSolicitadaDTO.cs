using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaMateriaPrimaSolicitadaDTO
    {
        public ConsultaMateriaPrimaSolicitadaDTO()
        {

        }

        public int ContratoSocioFincaId { get; set; }
        public int SocioId { get; set; }
        public int SocioFincaId { get; set; }
        public string CorrelativoContrato { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string Ruc { get; set; }
        public string ProductoId { get; set; }
        public string Producto { get; set; }
        public string SubProductoId { get; set; }
        public string SubProducto { get; set; }
        public decimal PesoSaco { get; set; }
        public string UnidadMedidaId { get; set; }
        public int CantidadSolicitada { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string FechaActualizacionString { get; set; }
    }
}
