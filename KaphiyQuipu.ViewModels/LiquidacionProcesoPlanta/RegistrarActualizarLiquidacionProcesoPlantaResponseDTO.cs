using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class RegistrarActualizarLiquidacionProcesoPlantaResponseDTO
    {
        public RegistrarActualizarLiquidacionProcesoPlantaResponseDTO()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
    }
}
