using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarDocumentoPagoPlantaDTO
    {
        public int PagoPlantaId { get; set; }
        public string CorrelativoPT { get; set; }
        public string CorrelativoGRA { get; set; }
        public string CorrelativoNIP { get; set; }
        public string Motivo { get; set; }
        public decimal MontoPago { get; set; }
        public string NombreArchivo { get; set; }
        public string UsuReg { get; set; }
        public string FecReg { get; set; }
    }
}
