using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Service
{
    public interface IGuiaRemisionPlantaService
    {
        Task<string> Registrar(GenerarGuiaRemisionPlantaRequestDTO request);
        ConsultarCorrelativoGuiaRemisionPlantaDTO ConsultarCorrelativo(ConsultarCorrelativoGuiaRemisionPlantaRequestDTO request);
    }
}
