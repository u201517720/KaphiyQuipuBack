using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ProyectarCosechaResponseDTO
    {
        public ProyectarCosechaResponseDTO()
        {
            Columnas = new List<string>();
            Valores = new List<decimal>();
            Result = new Result();
        }
        public dynamic Data { get; set; }
        public List<decimal> Valores { get; set; }
        public List<string> Columnas { get; set; }
        public Result Result { get; set; }
    }
}
