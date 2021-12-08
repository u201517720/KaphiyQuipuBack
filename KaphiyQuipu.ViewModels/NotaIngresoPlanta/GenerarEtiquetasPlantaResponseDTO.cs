using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class GenerarEtiquetasPlantaResponseDTO
    {
        public GenerarEtiquetasPlantaResponseDTO()
        {
            Result = new Result();
            listaEtiquetas = new List<EtiquetaPlanta>();
        }

        public Result Result { get; set; }
        public IList<EtiquetaPlanta> listaEtiquetas { get; set; }
    }

    public class EtiquetaPlanta
    {
        public string CorrelativoNIP { get; set; }
        public string CorrelativoGRA { get; set; }
        public string Producto { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal PesoKilos { get; set; }
        public decimal KilosNetos { get; set; }
    }
}
