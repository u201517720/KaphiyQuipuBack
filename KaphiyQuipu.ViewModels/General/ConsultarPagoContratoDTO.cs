using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarPagoContratoDTO
    {
        public int PagoContratoId { get; set; }
        public string CorrelativoPC { get; set; }
        public string CorrelativoSC { get; set; }
        public string CorrelativoCC { get; set; }
        public string Motivo { get; set; }
        public decimal MontoPago { get; set; }
        public string NombreArchivo { get; set; }
        public string UsuReg { get; set; }
        public string FecReg { get; set; }
        public string Cliente { get; set; }
        public string Estado { get; set; }
        public string Moneda { get; set; }
    }
}
