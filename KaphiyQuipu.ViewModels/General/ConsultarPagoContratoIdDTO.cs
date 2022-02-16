using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarPagoContratoIdDTO
    {
        public string CorrelativoPC { get; set; }
        public string CorrelativoCC { get; set; }
        public string Motivo { get; set; }
        public decimal MontoPago { get; set; }
        public string NombreArchivo { get; set; }
        public string FecReg { get; set; }
        public string Cliente { get; set; }
        public string ClienteRUC { get; set; }
        public string Estado { get; set; }
        public string Remitente { get; set; }
        public string RemitenteRUC { get; set; }
        public string Moneda { get; set; }
        public int EstadoId { get; set; }
    }
}
