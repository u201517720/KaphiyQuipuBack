using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGuiaRemisionPlantaRepository
    {
        string Registrar(GuiaRemisionPlanta guia);
        IEnumerable<ConsultarCorrelativoGuiaRemisionPlantaDTO> ConsultarCorrelativo(string correlativo);
        IEnumerable<ConsultarGuiaRemisionPlantaDTO> Consultar(DateTime fechaInicio, DateTime fechaFin);
    }
}
