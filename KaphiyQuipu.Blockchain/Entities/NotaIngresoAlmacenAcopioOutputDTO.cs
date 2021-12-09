using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class NotaIngresoAlmacenAcopioOutputDTO : IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string correlativo { get; set; }

        [Parameter("string", 2)]
        public string Almacen { get; set; }

        [Parameter("uint256", 3)]
        public long Fecha { get; set; }
    }
}
