using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarDocumentoPagoRequestDTO
    {
        public string CorrelativoDPA { get; set; }
        public string CorrelativoCC { get; set; }
        public int Id { get; set; }
    }
}
