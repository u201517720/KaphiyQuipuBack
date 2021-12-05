using KaphiyQuipu.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<bool> RegistrarResultadosTransformacion(RegistrarResultadosTransformacionNotaIngresoPlantaRequestDTO request);
        GenerarEtiquetasPlantaResponseDTO GenerarEtiquetasPlanta(int id);
    }
}
