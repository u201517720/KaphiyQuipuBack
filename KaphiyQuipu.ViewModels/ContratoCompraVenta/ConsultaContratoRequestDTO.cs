using System;

namespace KaphiyQuipu.DTO
{
    public class ConsultaContratoRequestDTO
    {
        public ConsultaContratoRequestDTO()
        {

        }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int RolId { get; set; }
        public string CodigoDistribuidor { get; set; }
        public int UserId { get; set; }

    }
}
