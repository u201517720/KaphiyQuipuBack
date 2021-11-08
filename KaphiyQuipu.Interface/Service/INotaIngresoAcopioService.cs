using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface INotaIngresoAcopioService
    {
        string Registrar(RegistrarNotaIngresoAcopioRequestDTO request);
        List<ConsultaNotaIngresoAcopioDTO> Consultar(ConsultaNotaIngresoAcopioRequestDTO request);
    }
}
