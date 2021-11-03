using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Service
{
    public interface ISolicitudCompraService
    {
        string Registrar(RegistrarActualizarSolicitudCompraRequestDTO request);
        List<ConsultaSolicitudCompraDTO> Consultar(ConsultaSolicitudCompraRequestDTO request);
        ConsultaSolicitudCompraPorIdDTO ConsultarPorId(ConsultaSolicitudCompraPorIdRequestDTO request);
        Task<TransactionResult> Registrar(SolicitudCompraDTO solicitudCompra);
        Task<SolicitudCompraOutputDTO> ObtenerSolicitud(string correlativo);
    }
}
