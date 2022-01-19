using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class EvaluarDisponibilidadRequestDTO
    {
        public EvaluarDisponibilidadRequestDTO()
        {

        }

        public int CodigoSolicitudCompra { get; set; }
        public string CodigoTipoCertificacion { get; set; }
        public decimal PesoNeto { get; set; }
        public int PesoSaco { get; set; }
        public string Usuario { get; set; }
    }
}
