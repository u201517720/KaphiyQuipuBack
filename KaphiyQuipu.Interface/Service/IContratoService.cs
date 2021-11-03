using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using KaphiyQuipu.DTO.SolicitudCompra;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Service
{
    public interface IContratoService
    {
        List<ConsultaContratoDTO> Consultar(ConsultaContratoRequestDTO request);
        ConsultaContratoPorIdDTO ConsultarPorId(ConsultaContratoPorIdRequestDTO request);
        string Registrar(RegistrarActualizarContratoRequestDTO request);
        Task<TransactionResponse<string>> Confirmar(ContratoCompraDTO request);
    }
}
