using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface INotaIngresoPlantaService
    {
        List<ConsultaNotaIngresoPlantaDTO> Consultar(ConsultarNotaIngresoPlantaRequestDTO request);
        string Registrar(RegistrarNotaIngresoPlantaRequestDTO request);
        ConsultarPorIdNotaIngresoPlantaDTO ConsultarPorId(ConsultarPorIdNotaIngresoPlantaRequestDTO request);
        void RegistrarControlCalidad(RegistrarControlCalidadNotaIngresoPlantaRequestDTO request);
        void ConfirmarRecepcionMateriaPrima(ConfirmarRecepcionMateriaPrimaNotaIngresoPlantaRequestDTO request);
        void AutorizarTransformacion(AutorizarTransformacionNotaIngresoPlantaRequestDTO request);
        void FinalizarEtiquetado(FinalizarEtiquetadoNotaIngresoPlantaRequestDTO request);
    }
}
