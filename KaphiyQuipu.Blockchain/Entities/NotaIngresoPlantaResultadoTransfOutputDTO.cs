using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class NotaIngresoPlantaResultadoTransfOutputDTO: IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string Correlativo { get; set; }

        [Parameter("string", 2)]
        public string CafeExportacionSacos { get; set; }

        [Parameter("string", 3)]
        public string CafeExportacionKilos { get; set; }

        [Parameter("string", 4)]
        public string CafeExportacionMCSacos { get; set; }

        [Parameter("string", 5)]
        public string CafeExportacionMCKilos { get; set; }

        [Parameter("string", 6)]
        public string CafeSegundaSacos { get; set; }

        [Parameter("string", 7)]
        public string CafeSegundaKilos { get; set; }

        [Parameter("string", 8)]
        public string CafeDescarteMaquinaSacos { get; set; }

        [Parameter("string", 9)]
        public string CafeDescarteMaquinaKilos { get; set; }

        [Parameter("string", 10)]
        public string CafeDescarteEscojoSacos { get; set; }

        [Parameter("string", 11)]
        public string CafeDescarteEscojoKilos { get; set; }

        [Parameter("string", 12)]
        public string CafeBolaSacos { get; set; }

        [Parameter("string", 13)]
        public string CafeBolaKilos { get; set; }

        [Parameter("string", 14)]
        public string CafeCiscoSacos { get; set; }

        [Parameter("string", 15)]
        public string CafeCiscoKilos { get; set; }

        [Parameter("string", 16)]
        public string TotalCafeSacos { get; set; }

        [Parameter("string", 17)]
        public string TotalCafeKgNetos { get; set; }

        [Parameter("string", 18)]
        public string PiedraOtrosKgNetos { get; set; }

        [Parameter("string", 19)]
        public string CascaraOtrosKgNetos { get; set; }

        [Parameter("string", 20)]
        public string Usuario { get; set; }

        [Parameter("uint256", 21)]
        public long FechaRegistro { get; set; }
    }
}
