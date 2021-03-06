using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface INotaSalidaPlantaService
    {
        string Registrar(GenerarNotaSalidaPlantaRequestDTO request);
        List<ConsultarNotaSalidaPlantaDTO> Consultar(ConsultarNotaSalidaPlantaRequestDTO request);
        ConsultarPorIdNotaSalidaPlantaDTO ConsultarPorId(ConsultarPorIdNotaSalidaPlantaRequestDTO request);
    }
}
