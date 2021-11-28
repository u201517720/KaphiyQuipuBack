using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Service
{
    public interface IGuiaRemisionAcopioService
    {
        Task<string> Registrar(RegistrarGuiaRemisionAcopioRequestDTO request);
        ConsultarPorCorrelativoGuiaRemisionDTO ConsultarPorCorrelativo(ConsultarPorCorrelativoGuiaRemisionRequestDTO request);
        Task<string> RegistrarDevolucion(RegistrarDevolucionGuiaRemisionRequestDTO request);
        List<ConsultarGuiaRemisionAcopioDTO> Consultar(ConsultarGuiaRemisionAcopioRequestDTO request);
    }
}
