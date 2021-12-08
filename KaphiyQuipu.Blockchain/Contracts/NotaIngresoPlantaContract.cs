using KaphiyQuipu.Blockchain.Contracts.Interface;
using KaphiyQuipu.Blockchain.Entities;
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
    public class NotaIngresoPlantaContract: INotaIngresoPlantaContract
    {
        private readonly IContractFacade _ContractFacade;
        private readonly IConfiguration _configuration;
        private readonly IContractOperation _contractOperation;
        private readonly IAccountService _accountService;
        private readonly Web3 _web3;
        private IAccount _account;
        private ContractDAO contract;

        public NotaIngresoPlantaContract(IContractFacade contractFacade,
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

            contract = _ContractFacade.GetContract(_configuration["Ethereum:Contracts:NotaIngresoPlanta:Name"], true, _configuration["Ethereum:Contracts:NotaIngresoPlanta:Address"]).Result;
        }

        public async Task<TransactionResult> RegistrarControlCalidad(RegistrarControlCalidadNotaIngresoPlantaRequestDTO controlCalidad, string correlativo, DateTime fechaRegistro)
        {
            NotaIngresoPlantaCalidadOutputDTO notaIngreso = new NotaIngresoPlantaCalidadOutputDTO();
            notaIngreso.Correlativo = correlativo;
            notaIngreso.Olores = controlCalidad.DescripcionOlores;
            notaIngreso.Colores = controlCalidad.DescripcionColores;
            notaIngreso.ExportableGramos = controlCalidad.ExportableGramos.ToString("0.00");
            notaIngreso.ExportablePorcentaje = controlCalidad.ExportablePorcentaje.ToString("0.00");
            notaIngreso.DescarteGramos = controlCalidad.DescarteGramos.ToString("0.00");
            notaIngreso.DescartePorcentaje = controlCalidad.DescartePorcentaje.ToString("0.00");
            notaIngreso.CascarillaGramos = controlCalidad.CascarillaGramos.ToString("0.00");
            notaIngreso.CascarillaPorcentaje = controlCalidad.CascarillaPorcentaje.ToString("0.00");
            notaIngreso.TotalGramos = controlCalidad.TotalGramos.ToString("0.00");
            notaIngreso.TotalPorcentaje = controlCalidad.TotalPorcentaje.ToString("0.00");
            notaIngreso.HumedadPorcentaje = controlCalidad.HumedadPorcentaje.ToString("0.00");
            notaIngreso.Usuario = controlCalidad.UsuarioActualizacion;
            notaIngreso.FechaRegistro = fechaRegistro.Ticks;
            TransactionResult result = await _contractOperation.GenericTransaction(contract.Contract, _web3, _account.Address, Functions.NotaIngresoPlanta.AGREGAR_CONTROL_CALIDAD,
                                                                                    notaIngreso
                                                                                   );

            return result;
        }

        public async Task<NotaIngresoPlantaCalidadOutputDTO> ObtenerControlCalidadPorCorrelativo(string correlativo)
        {
            var solicitudOutput = await contract.Contract.GetFunction(Functions.NotaIngresoPlanta.OBTENER_CONTROL_CALIDAD).CallDeserializingToObjectAsync<GenericOutputDTO<NotaIngresoPlantaCalidadOutputDTO>>(correlativo);
            return solicitudOutput.Data;
        }

        
        public async Task<TransactionResult> RegistrarResultadoTransformacion(RegistrarResultadosTransformacionNotaIngresoPlantaRequestDTO resultado, string correlativo, DateTime fechaRegistro)
        {
            NotaIngresoPlantaResultadoTransfOutputDTO resultadoTransformacion = new NotaIngresoPlantaResultadoTransfOutputDTO();
            resultadoTransformacion.Correlativo = correlativo;
            resultadoTransformacion.CafeExportacionSacos = resultado.CafeExportacionSacos.ToString("0.00");
            resultadoTransformacion.CafeExportacionKilos = resultado.CafeExportacionKilos.ToString("0.00");
            resultadoTransformacion.CafeExportacionMCSacos = resultado.CafeExportacionMCSacos.ToString("0.00");
            resultadoTransformacion.CafeExportacionMCKilos = resultado.CafeExportacionMCKilos.ToString("0.00");
            resultadoTransformacion.CafeSegundaSacos = resultado.CafeSegundaSacos.ToString("0.00");
            resultadoTransformacion.CafeSegundaKilos = resultado.CafeSegundaKilos.ToString("0.00");
            resultadoTransformacion.CafeDescarteMaquinaSacos = resultado.CafeDescarteMaquinaSacos.ToString("0.00");
            resultadoTransformacion.CafeDescarteMaquinaKilos = resultado.CafeDescarteMaquinaKilos.ToString("0.00");
            resultadoTransformacion.CafeDescarteEscojoSacos = resultado.CafeDescarteEscojoSacos.ToString("0.00");
            resultadoTransformacion.CafeDescarteEscojoKilos = resultado.CafeDescarteEscojoKilos.ToString("0.00");
            resultadoTransformacion.CafeBolaSacos = resultado.CafeBolaSacos.ToString("0.00");
            resultadoTransformacion.CafeBolaKilos = resultado.CafeBolaKilos.ToString("0.00");
            resultadoTransformacion.CafeCiscoSacos = resultado.CafeCiscoSacos.ToString("0.00");
            resultadoTransformacion.CafeCiscoKilos = resultado.CafeCiscoKilos.ToString("0.00");
            resultadoTransformacion.TotalCafeSacos = resultado.TotalCafeSacos.ToString("0.00");
            resultadoTransformacion.TotalCafeKgNetos = resultado.TotalCafeKgNetos.ToString("0.00");
            resultadoTransformacion.PiedraOtrosKgNetos = resultado.PiedraOtrosKgNetos.ToString("0.00");
            resultadoTransformacion.CascaraOtrosKgNetos = resultado.CascaraOtrosKgNetos.ToString("0.00");
            resultadoTransformacion.Usuario = resultado.UsuarioRegistro;
            resultadoTransformacion.FechaRegistro = fechaRegistro.Ticks;

            TransactionResult result = await _contractOperation.GenericTransaction(contract.Contract, _web3, _account.Address, Functions.NotaIngresoPlanta.AGREGAR_RESULTADO_TRANSFORMACION,
                                                                                    resultadoTransformacion
                                                                                   );

            return result;
        }

        public async Task<NotaIngresoPlantaResultadoTransfOutputDTO> ObtenerResultadoTransformacionPorCorrelativo(string correlativo)
        {
            var solicitudOutput = await contract.Contract.GetFunction(Functions.NotaIngresoPlanta.OBTENER_RESULTADO_TRANSFORMACION).CallDeserializingToObjectAsync<GenericOutputDTO<NotaIngresoPlantaResultadoTransfOutputDTO>>(correlativo);
            return solicitudOutput.Data;
        }
    }
}
