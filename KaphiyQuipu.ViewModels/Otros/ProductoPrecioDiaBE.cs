using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ProductoPrecioDiaBE
    {
        public string ProductoId { get; set; }
        public string SubProductoId { get; set; }

        public decimal PrecioDia { get; set; }
    }
}
