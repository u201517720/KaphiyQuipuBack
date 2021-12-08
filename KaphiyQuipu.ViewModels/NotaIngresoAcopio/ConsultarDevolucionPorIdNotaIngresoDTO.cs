using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarDevolucionPorIdNotaIngresoDTO
    {
        public int NotaIngresoDevolucionId { get; set; }
        public string AlmacenId { get; set; }
        public int GuiaRemisionPlantaId { get; set; }
        public string CorrelativoGRP { get; set; }
        public string Producto { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal PesoSaco { get; set; }
        public string FechaRegistro { get; set; }
        public string Observaciones { get; set; }
        public string EstadoId { get; set; }
        public string CorrelativoNID { get; set; }
    }
}
