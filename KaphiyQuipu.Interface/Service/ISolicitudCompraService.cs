using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO.SolicitudCompra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Service
{
    public interface ISolicitudCompraService
    {
        Task<TransactionResult> Registrar(SolicitudCompraDTO solicitudCompra);
        Task<SolicitudCompraOutputDTO> ObtenerSolicitud(string correlativo);
    }
}
