using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGuiaRemisionAcopioRepository
    {
        string Registrar(GuiaRemisionAcopio request);
        IEnumerable<ConsultarPorCorrelativoGuiaRemisionDTO> ConsultarPorCorrelativo(string correlativo);
        string RegistrarDevolucion(GuiaRemisionDevolucion guia);
        IEnumerable<ConsultarGuiaRemisionAcopioDTO> Consultar(DateTime fechaInicio, DateTime fechaFin);
        IEnumerable<ConsultarPorIdGuiaRemisionAcopioDTO> ConsultarPorId(int id);
    }
}
