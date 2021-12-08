using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class ControlCalidadAgricultorOutputDTO: IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string PorcentajeHumedad { get; set; }

        [Parameter("string", 2)]
        public string Olor { get; set; }

        [Parameter("string", 3)]
        public string Color { get; set; }

        [Parameter("string", 4)]
        public string Observacion { get; set; }

        [Parameter("string", 5)]
        public string Responsable { get; set; }
    }
}
