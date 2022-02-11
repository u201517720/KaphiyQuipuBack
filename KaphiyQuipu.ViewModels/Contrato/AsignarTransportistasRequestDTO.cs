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
        public string Codigo { get; set; }
    }

    public class AsignarTransportistasDTO
    {
        public int IdProceso { get; set; }
        public int TransporteId { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
