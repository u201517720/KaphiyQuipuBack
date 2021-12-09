using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class AnalisisFisicoCafeOutputDTO : IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string CafeGramos { get; set; }

        [Parameter("string", 2)]
        public string CafePorcentaje { get; set; }

        [Parameter("string", 3)]
        public string DescarteGramos { get; set; }

        [Parameter("string", 4)]
        public string DescartePorcentaje { get; set; }

        [Parameter("string", 5)]
        public string CascaraGramos { get; set; }

        [Parameter("string", 6)]
        public string CascaraPorcentaje { get; set; }

        [Parameter("string", 7)]
        public string TotalGramos { get; set; }

        [Parameter("string", 8)]
        public string TotalPorcentaje { get; set; }

        [Parameter("uint256", 9)]
        public long Fecha { get; set; }
    }
}
