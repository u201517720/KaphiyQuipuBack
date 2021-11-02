using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IContratoService
    {
        List<ConsultaContratoDTO> Consultar(ConsultaContratoRequestDTO request);
        int RegistrarContrato(RegistrarActualizarContratoRequestDTO request, IFormFile file);
        int ActualizarContrato(RegistrarActualizarContratoRequestDTO request, IFormFile file);
        ConsultaContratoPorIdDTO ConsultarPorId(ConsultaContratoPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);
        int AnularContrato(AnularContratoRequestDTO request);
        ConsultarTrackingContratoPorContratoIdBE ConsultarTrackingContratoPorContratoId(ConsultaTrackingContratoPorContratoIdRequestDTO request);
        List<ConsultarTrackingContratoPorContratoIdBE> ConsultarTrackingContrato(ConsultaTrackingContratoRequestDTO request);
        int AsignarAcopio(AsignarAcopioContratoRequestDTO request);
        ConsultaContratoAsignado ConsultarContratoAsignado(ConsultaContratoAsignadoRequestDTO request);
    }
}
