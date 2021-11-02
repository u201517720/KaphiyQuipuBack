using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.Facade;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.Blockchain.Services;
using KaphiyQuipu.DTO.SolicitudCompra;
using Microsoft.Extensions.Configuration;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Blockchain.ERC20
{
    public interface ISolicitudCompraContract
    {
        Task<TransactionResult> RegistrarSolicitud(SolicitudCompraDTO solicitud);
        Task<SolicitudCompraOutputDTO> ObtenerSolicitud(string correlativo);
    }

    public class SolicitudCompraContract: ISolicitudCompraContract
    {
        private readonly IContractFacade _ContractFacade;
        private readonly IConfiguration _configuration;
        private readonly IContractOperation _contractOperation;
        private readonly IAccountService _accountService;
        private readonly Web3 _web3;
        private IAccount _account;
        private ContractDAO contract;

        public SolicitudCompraContract( IContractFacade contractFacade,
                                        IConfiguration configuration,
                                        IContractOperation contractOperation,
                                        IAccountService accountService)
        {
            _ContractFacade = contractFacade;
            _configuration = configuration;
            _contractOperation = contractOperation;
            _accountService = accountService;
            _web3 = _accountService.GetWeb3();
            _account = _accountService.GetAccount();

            contract =  _ContractFacade.GetContract(_configuration["Ethereum:Contracts:SolicitudCompra:Name"], true, _configuration["Ethereum:Contracts:SolicitudCompra:Address"]).Result;
        }

        public async Task<TransactionResult> RegistrarSolicitud(SolicitudCompraDTO solicitud)
        {
            try
            {
                TransactionResult result = await _contractOperation.GenericTransaction(contract.Contract, _web3, _account.Address, Functions.SolicitudCompra.AGREGAR_SOLICITUD,
                                           solicitud.Correlativo,
                                           solicitud.TipoProduccion,
                                           solicitud.Producto,
                                           solicitud.SubProducto,
                                           solicitud.GradoPreparacion,
                                           solicitud.Calidad,
                                           solicitud.Distribuidor,
                                           solicitud.Usuario,
                                           DateTime.Now.Ticks);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SolicitudCompraOutputDTO> ObtenerSolicitud(string correlativo)
        {
            var solicitudOutput = await contract.Contract.GetFunction(Functions.SolicitudCompra.OBTENER_SOLICITUD).CallDeserializingToObjectAsync<GenericOutputDTO<SolicitudCompraOutputDTO>>(correlativo);
            return solicitudOutput.Data;
        }
    }
}
