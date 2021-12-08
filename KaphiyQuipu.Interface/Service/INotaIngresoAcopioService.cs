using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Service
{
    public interface INotaIngresoAcopioService
    {
        string Registrar(RegistrarNotaIngresoAcopioRequestDTO request);
        List<ConsultaNotaIngresoAcopioDTO> Consultar(ConsultaNotaIngresoAcopioRequestDTO request);
        ConsultaPorIdNotaIngresoAcopioDTO ConsultarPorId(ConsultaPorIdNotaIngresoAcopioRequestDTO request);
        void UbicarMateriaPrimaAlmacen(UbicarMateriaPrimaAlmacenRequestDTO request);
        List<StickerAcopioDTO> ObtenerStickers(int notaIngresoId);
        Task<bool> ConfirmarEtiquetado(ConfirmarEtiquetadoRequestDTO request);
        List<ConsultarDevolucionNotaIngresoAcopioDTO> ConsultarDevolucion(ConsultarDevolucionNotaIngresoAcopioRequestDTO request);
        string RegistrarDevolucion(RegistrarDevolucionNotaIngresoRequestDTO request);
        ConsultarDevolucionPorIdNotaIngresoDTO ConsultarDevolucionPorId(ConsultarDevolucionPorIdNotaIngresoRequestDTO request);
        void ConfirmarAtencionCompleta(ConfirmarAtencionCompletaNotaIngresoDevoRequestDTO request);
        GenerarEtiquetasAcopioResponseDTO GenerarEtiquetasAcopio(int id);
    }
}
