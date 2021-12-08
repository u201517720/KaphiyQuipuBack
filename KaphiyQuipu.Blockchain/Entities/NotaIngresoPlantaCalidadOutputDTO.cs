using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class NotaIngresoPlantaCalidadOutputDTO: IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string Correlativo { get; set; }

        [Parameter("string", 2)]
        public string Olores { get; set; }

        [Parameter("string", 3)]
        public string Colores { get; set; }

        [Parameter("string", 4)]
        public string ExportableGramos { get; set; }

        [Parameter("string", 5)]
        public string ExportablePorcentaje { get; set; }

        [Parameter("string", 6)]
        public string DescarteGramos { get; set; }

        [Parameter("string", 7)]
        public string DescartePorcentaje { get; set; }

        [Parameter("string", 8)]
        public string CascarillaGramos { get; set; }

        [Parameter("string", 9)]
        public string CascarillaPorcentaje { get; set; }

        [Parameter("string", 10)]
        public string TotalGramos { get; set; }

        [Parameter("string", 11)]
        public string TotalPorcentaje { get; set; }

        [Parameter("string", 12)]
        public string HumedadPorcentaje { get; set; }

        [Parameter("string", 13)]
        public string Usuario { get; set; }

        [Parameter("uint256", 14)]
        public long FechaRegistro { get; set; }
    }
}
