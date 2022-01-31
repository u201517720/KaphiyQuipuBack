using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class AsignarTransportistasRequestDTO
    {
        public AsignarTransportistasRequestDTO()
        {
            transportistas = new List<AsignarTransportistasDTO>();
        }

        public List<AsignarTransportistasDTO> transportistas { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class AsignarTransportistasDTO
    {
        public int ContratoId { get; set; }
        public int TransporteId { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
