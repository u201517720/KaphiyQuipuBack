using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.ERC20;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO.SolicitudCompra;
using KaphiyQuipu.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Service
{
    public class SolicitudCompraService: ISolicitudCompraService
    {
        private readonly ISolicitudCompraContract _solicitudCompraContract;
        public SolicitudCompraService(ISolicitudCompraContract solicitudCompraContract)
        {
            _solicitudCompraContract = solicitudCompraContract;
        }

        public async Task<TransactionResult> Registrar(SolicitudCompraDTO solicitudCompra)
        {
            return await _solicitudCompraContract.RegistrarSolicitud(solicitudCompra);
        }

        public async Task<SolicitudCompraOutputDTO> ObtenerSolicitud(string correlativo)
        {
            return await _solicitudCompraContract.ObtenerSolicitud(correlativo);
        }
    }
}
