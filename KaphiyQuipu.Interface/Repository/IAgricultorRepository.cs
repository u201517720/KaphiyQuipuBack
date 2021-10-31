using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IAgricultorRepository
    {
        IEnumerable<ConsultaAgricultorDTO> Consultar(ConsultaAgricultorRequestDTO request);
    }
}
