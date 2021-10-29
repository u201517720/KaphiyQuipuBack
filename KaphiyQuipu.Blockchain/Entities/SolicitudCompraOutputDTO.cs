using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Entities
{
    [FunctionOutput]
    public class SolicitudCompraOutputDTO : IFunctionOutputDTO
    {
        [Parameter("string", 1)]
        public string Correlativo { get; set; }

        [Parameter("string", 2)]
        public string TipoProduccion { get; set; }

        [Parameter("string", 3)]
        public string Producto { get; set; }

        [Parameter("string", 4)]
        public string SubProducto { get; set; }

        [Parameter("string", 5)]
        public string GradoPreparacion { get; set; }

        [Parameter("string", 6)]
        public string Calidad { get; set; }

        [Parameter("string", 7)]
        public string Distribuidor { get; set; }

        [Parameter("string", 8)]
        public string Usuario { get; set; }

        [Parameter("uint256", 9)]
        public long FecRegistro { get; set; }
    }
}
