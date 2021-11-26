using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarCorrelativoGuiaRemisionPlantaDTO
    {
        public int GuiaRemisionPlantaId { get; set; }
        public string CorrelativoGRP { get; set; }
        public string Producto { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal PesoSaco { get; set; }
    }
}
