using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Models
{
    public class TipoCambio
    {
        public int ID { get; set; }
        public decimal Compra { get; set; }
        public decimal Venta { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public string EstadoId { get; set; }
        public DateTime FecReg { get; set; }
    }
}
