﻿using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.ERC20;
using KaphiyQuipu.Blockchain.Facade;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.Blockchain.Services;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Configuration;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Blockchain.Contracts
{
    public interface IContratoCompraContract
    {
        Task<TransactionResult> RegistrarContrato(ContratoCompraDTO contrato);
        Task<ContratoCompraOutputDTO> ObtenerContrato(string nroContrato);
        Task<TransactionResult> AgregarAgricultor(AgricultorContratoDTO agricultor);
        Task<List<AgricultorContratoOutputDTO>> ObtenerAgricultoresPorContrato(string nroContrato);
        Task<TransactionResult> AgregarControlCalidad(RegistrarControlCalidadDTO controlCalidad);
        Task<TransactionResult> AgregarAnalisisFisicoCafe(GuiaRecepcionMateriaPrima guia);
    }

    public class ContratoCompraContract : IContratoCompraContract
    {
        private readonly IContractFacade _ContractFacade;
        private readonly IConfiguration _configuration;
        private readonly IContractOperation _contractOperation;
        private readonly IAccountService _accountService;
        private readonly Web3 _web3;
        private IAccount _account;
        private ContractDAO contract;

        public ContratoCompraContract(IContractFacade contractFacade,
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

            contract = _ContractFacade.GetContract(_configuration["Ethereum:Contracts:ContratoCompra:Name"], true, _configuration["Ethereum:Contracts:ContratoCompra:Address"]).Result;
        }

        public async Task<TransactionResult> RegistrarContrato(ContratoCompraDTO contrato)
        {
            TransactionResult result = await _contractOperation.GenericTransaction(contract.Contract, _web3, _account.Address, Functions.ContratoCompra.AGREGAR_CONTRATO,
                                           contrato.NroContrato,
                                           contrato.Distribuidor,
                                           contrato.Producto,
                                           contrato.SubProducto,
                                           contrato.TipoProduccion,
                                           contrato.Calidad,
                                           contrato.GradoPreparacion,
                                           contrato.FechaSolicitud.Ticks);

            return result;
        }

        public async Task<ContratoCompraOutputDTO> ObtenerContrato(string nroContrato)
        {
            var solicitudOutput = await contract.Contract.GetFunction(Functions.ContratoCompra.OBTENER_CONTRATO).CallDeserializingToObjectAsync<GenericOutputDTO<ContratoCompraOutputDTO>>(nroContrato);
            return solicitudOutput.Data;
        }


        public async Task<TransactionResult> AgregarAgricultor(AgricultorContratoDTO agricultor)
        {
            TransactionResult result = await _contractOperation.GenericTransaction(contract.Contract, _web3, _account.Address, Functions.ContratoCompra.AGREGAR_AGRICULTOR,
                                           agricultor.NroContrato,
                                           agricultor.NroDocumento,
                                           agricultor.Finca,
                                           agricultor.Certificacion);

            return result;
        }

        public async Task<List<AgricultorContratoOutputDTO>> ObtenerAgricultoresPorContrato(string nroContrato)
        {
            var solicitudOutput = await contract.Contract.GetFunction(Functions.ContratoCompra.OBTENER_AGRICULTORES).CallDeserializingToObjectAsync<DataAgricultorContratoOutputDTO>(nroContrato);
            return solicitudOutput.Lista;
        }

        public async Task<TransactionResult> AgregarControlCalidad(RegistrarControlCalidadDTO controlCalidad)
        {
            TransactionResult result = await _contractOperation.GenericTransaction(contract.Contract, _web3, _account.Address, Functions.ContratoCompra.AGREGAR_CONTROL_CALIDAD,
                                           controlCalidad.ContratoSocioFincaId,
                                           controlCalidad.Humedad,
                                           controlCalidad.ListaOlores,
                                           controlCalidad.ListaColores,
                                           controlCalidad.Observaciones,
                                           controlCalidad.UsuarioCreacion
                                           );

            return result;
        }

        public async Task<TransactionResult> AgregarAnalisisFisicoCafe(GuiaRecepcionMateriaPrima guia)
        {
            TransactionResult result = await _contractOperation.GenericTransaction(contract.Contract, _web3, _account.Address, Functions.ContratoCompra.AGREGAR_ANALISIS_FISICO_CAFE,
                                             guia.Correlativo,
                                             guia.CafeExportacionGramosAFC.ToString("0.00"),
                                             guia.CafeExportacionPorcAFC.ToString("0.00"),
                                             guia.DescarteGramosAFC.ToString("0.00"),
                                             guia.DescartePorcAFC.ToString("0.00"),
                                             guia.CascaraGramosAFC.ToString("0.00"),
                                             guia.CascaraPorcAFC.ToString("0.00"),
                                             guia.TotalGramosAFC.ToString("0.00"),
                                             guia.TotalPorcAFC.ToString("0.00")
                                           );

            return result;
        }
    }
}
