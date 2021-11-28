using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarGuiaRemisionPlantaDTO
    {
        public int GuiaRemisionPlantaId { get; set; }
        public string CorrelativoGRP { get; set; }
        public string CorrelativoNSP { get; set; }
        public string MotivoSalida { get; set; }
        public string FechaTraslado { get; set; }
        public string FechaEmision { get; set; }
        public string UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
    }
}
