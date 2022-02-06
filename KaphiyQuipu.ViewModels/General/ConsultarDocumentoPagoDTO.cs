using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarDocumentoPagoDTO
    {
        public int PagoAcopioId { get; set; }
        public string CorrelativoDPA { get; set; }
        public string CorrelativoCC { get; set; }
        public string CorrelativoGR { get; set; }
        public decimal MontoPago { get; set; }
        public string Motivo { get; set; }
        public string UsuReg { get; set; }
        public string FecReg { get; set; }
        public string Agricultor { get; set; }
        public string NombreArchivo { get; set; }
    }
}
