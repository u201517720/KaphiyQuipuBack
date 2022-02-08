using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarDocumentoPagoPorIdDTO
    {
        public string CorrelativoDPA { get; set; }
        public string Ruc { get; set; }
        public string Fecha { get; set; }
        public string Agricultor { get; set; }
        public string Motivo { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal MontoPago { get; set; }
        public string Estado { get; set; }
        public string NombreArchivo { get; set; }
        public string CorrelativoCC { get; set; }
        public string EstadoId { get; set; }
    }
}
