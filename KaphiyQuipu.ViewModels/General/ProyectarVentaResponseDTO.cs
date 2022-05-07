using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class ProyectarVentaResponseDTO
    {
        public ProyectarVentaResponseDTO()
        {
            Columnas = new List<string>();
            Valores = new List<decimal>();
            Result = new Result();
            ValoresCosecha = new List<decimal>();
            ColumnasCosecha = new List<string>();
        }
        public dynamic Data { get; set; }
        public List<decimal> Valores { get; set; }
        public List<string> Columnas { get; set; }
        public Result Result { get; set; }
        public List<decimal> ValoresCosecha { get; set; }
        public List<string> ColumnasCosecha { get; set; }
    }
}
