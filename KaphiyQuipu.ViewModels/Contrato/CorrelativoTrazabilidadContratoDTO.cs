using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO.ContratoCompraVenta
{
    public class CorrelativoTrazabilidadContratoDTO
    {
        public int IdContrato { get; set; }
        public string NroContrato { get; set; }
        public string HashBCContrato { get; set; }
        public string NroGuiaRecepcion { get; set; }
        public string NroNotaIngresoAlmacenAcopio { get; set; }
        public string NroOrdenProceso { get; set; }
        public string NroGuiaRemisionAcopio { get; set; }
        public string NroNotaIngresoPlanta { get; set; }
    }
}
