using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class ContratoCompraOutputDTO: IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string Contrato { get; set; }

        [Parameter("string", 2)]
        public string Distribuidor { get; set; }

        [Parameter("string", 3)]
        public string Producto { get; set; }

        [Parameter("string", 4)]
        public string SubProducto { get; set; }

        [Parameter("string", 5)]
        public string TipoProduccion { get; set; }

        [Parameter("string", 6)]
        public string Calidad { get; set; }

        [Parameter("string", 7)]
        public string GradoPrepracion { get; set; }

        [Parameter("uint256", 8)]
        public long FechaSolicitud { get; set; }
    }
}
