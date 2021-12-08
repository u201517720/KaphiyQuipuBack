using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class TrazabilidadContratoOutput : IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string Proceso { get; set; }

        [Parameter("string", 2)]
        public string correlativo { get; set; }

        [Parameter("uint256", 3)]
        public long fecha { get; set; }
    }
}
