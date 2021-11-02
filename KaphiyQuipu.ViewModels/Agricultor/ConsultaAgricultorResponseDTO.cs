using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ConsultaAgricultorResponseDTO
    {
        public ConsultaAgricultorResponseDTO()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
    }
}
