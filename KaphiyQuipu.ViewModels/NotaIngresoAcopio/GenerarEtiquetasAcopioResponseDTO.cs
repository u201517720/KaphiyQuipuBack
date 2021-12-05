using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class GenerarEtiquetasAcopioResponseDTO
    {
        public GenerarEtiquetasAcopioResponseDTO()
        {
            Result = new Result();
            listaEtiquetas = new List<EtiquetaAcopio>();
        }

        public Result Result { get; set; }
        public IList<EtiquetaAcopio> listaEtiquetas { get; set; }
    }

    public class EtiquetaAcopio
    {
        public string Correlativo { get; set; }
        public string Socio { get; set; }
        public string Documento { get; set; }
        public string Finca { get; set; }
        public int NroSacos { get; set; }
        public string Producto { get; set; }
        public string Certificadora { get; set; }
        public string TipoProduccion { get; set; }
        public string Certificacion { get; set; }
        public string CorrelativoNIA { get; set; }
        public decimal Humedad { get; set; }
    }
}
