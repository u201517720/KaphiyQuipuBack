using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConfirmarVoucherPagoContratoCompraRequestDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
