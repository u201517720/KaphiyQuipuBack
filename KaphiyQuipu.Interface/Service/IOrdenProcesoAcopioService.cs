using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface IOrdenProcesoAcopioService
    {
        string Registrar(RegistrarOrdenProcesoAcopioRequestDTO request);
        List<ConsultarOrdenProcesoAcopioDTO> Consultar(ConsultaOrdenProcesoAcopioRequestDTO request);
    }
}
