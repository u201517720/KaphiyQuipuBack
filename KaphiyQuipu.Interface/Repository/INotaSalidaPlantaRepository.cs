using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaSalidaPlantaRepository
    {
        string Registrar(NotaSalidaPlanta salida);
        IEnumerable<ConsultarNotaSalidaPlantaDTO> Consultar(DateTime fechaInicio, DateTime fechaFin);
        IEnumerable<ConsultarPorIdNotaSalidaPlantaDTO> ConsultarPorId(int id);
    }
}
