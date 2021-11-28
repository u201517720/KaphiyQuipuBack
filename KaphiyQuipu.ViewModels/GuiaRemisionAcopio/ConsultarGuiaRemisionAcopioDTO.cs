using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarGuiaRemisionAcopioDTO
    {
        public int GuiaRemisionAcopioId { get; set; }
        public string CorrelativoGRA { get; set; }
        public string CorrelativoOP { get; set; }
        public string EmpresaAcopio { get; set; }
        public string EmpresaTransformadora { get; set; }
        public string FechaTraslado { get; set; }
        public string FechaEmision { get; set; }
    }
}
