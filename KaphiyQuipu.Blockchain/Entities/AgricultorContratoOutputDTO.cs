using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class DataAgricultorContratoOutputDTO : IFunctionOutputDTO
    {
        [Parameter("tuple[]", 1)]
        public virtual List<AgricultorContratoOutputDTO> Lista { get; set; }
    }

    [FunctionOutput]
    public class AgricultorContratoOutputDTO: IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string NroContrato { get; set; }

        [Parameter("string", 2)]
        public string NroDocumento { get; set; }

        [Parameter("string", 3)]
        public string Finca { get; set; }

        [Parameter("string", 4)]
        public string Certificacion { get; set; }
    }
}
