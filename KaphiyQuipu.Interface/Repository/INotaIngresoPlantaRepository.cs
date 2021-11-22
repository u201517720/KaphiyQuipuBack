using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaIngresoPlantaRepository
    {
        IEnumerable<ConsultaNotaIngresoPlantaDTO> Consultar(DateTime fechaInicio, DateTime fechaFin);
        string Registrar(NotaIngresoPlanta nota);
        IEnumerable<ConsultarPorIdNotaIngresoPlantaDTO> ConsultarPorId(int id);
    }
}
