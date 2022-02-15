using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultarDocumentoPagoPlantaPorIdDTO
    {
        public string CorrelativoPT { get; set; }
        public string CorrelativoNIP { get; set; }
        public string Motivo { get; set; }
        public decimal MontoPago { get; set; }
        public string NombreArchivo { get; set; }
        public string FecReg { get; set; }
        public string Planta { get; set; }
        public string RucPlanta { get; set; }
        public string Acopio { get; set; }
        public string RucAcopio { get; set; }
        public string Estado { get; set; }
        public int EstadoId { get; set; }
    }
}
