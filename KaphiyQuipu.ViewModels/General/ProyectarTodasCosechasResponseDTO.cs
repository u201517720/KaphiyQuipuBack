using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ProyectarTodasCosechasResponseDTO
    {
        public ProyectarTodasCosechasResponseDTO()
        {
            Result = new Result();
            Columnas = new List<string>();
            Valores = new List<List<string>>();
        }
        public Result Result { get; set; }
        public List<string> Columnas { get; set; }
        public List<List<string>> Valores { get; set; }
    }
}
