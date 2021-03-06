using KaphiyQuipu.DTO;
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
        void AsociarAgricultoresContrato(AsociarAgricultoresContratoRequestDTO request);
        List<ObtenerAgricultoresPorContratoDTO> ObtenerAgricultoresPorContrato(ObtenerAgricultoresPorContratoRequestDTO request);
        void RegistrarControlCalidad(RegistrarControlCalidadRequestDTO request);
        void ConfirmarRecepcionCafeTerminado(ConfirmarRecepcionCafeTerminadoContratoRequestDTO request);
        Task<List<(string, List<object>)>> ObtenerDatosTrazabilidad(string nroContrato);
        void AsignarTransportistas(AsignarTransportistasRequestDTO request);
        void AsignarResponsableCalidad(AsignarResponsableCalidadRequestDTO request);
    }
}
