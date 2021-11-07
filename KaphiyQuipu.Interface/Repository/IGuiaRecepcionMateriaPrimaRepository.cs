using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGuiaRecepcionMateriaPrimaRepository
    {
        IEnumerable<ConsultaGuiaRecepcionMateriaPrimaDTO> Consultar(ConsultarGuiaRecepcionMateriaPrimaRequestDTO request);
    }
}
