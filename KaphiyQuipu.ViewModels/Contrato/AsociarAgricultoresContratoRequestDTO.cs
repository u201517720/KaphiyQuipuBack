using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO
{
    public class AsociarAgricultoresContratoRequestDTO
    {
        public AsociarAgricultoresContratoRequestDTO()
        {
            agricultores = new List<AsociarAgricultoresContratoDTO>();
        }

        public List<AsociarAgricultoresContratoDTO> agricultores { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class AsociarAgricultoresContratoDTO
    {
        public AsociarAgricultoresContratoDTO()
        {

        }
        public int ContratoId { get; set; }
        public int SocioFincaId { get; set; }
        public int CantidadSolicitada { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
