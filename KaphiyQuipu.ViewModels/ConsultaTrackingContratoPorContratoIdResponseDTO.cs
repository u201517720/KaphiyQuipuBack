﻿using Core.Common.Domain.Model;

namespace CoffeeConnect.DTO
{

    public class ConsultaTrackingContratoPorContratoIdResponseDTO
    {
        public ConsultaTrackingContratoPorContratoIdResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
