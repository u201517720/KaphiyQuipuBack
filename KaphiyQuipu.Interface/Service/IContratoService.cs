using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IContratoService
    {
        List<ConsultaContratoDTO> Consultar(ConsultaContratoRequestDTO request);
        ConsultaContratoPorIdDTO ConsultarPorId(ConsultaContratoPorIdRequestDTO request);
        string Registrar(RegistrarActualizarContratoRequestDTO request);
    }
}
