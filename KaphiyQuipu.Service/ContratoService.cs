
using AutoMapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using KaphiyQuipu.Service.Adjunto;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO.SolicitudCompra;
using System.Threading.Tasks;

namespace KaphiyQuipu.Service
{
    public partial class ContratoService : IContratoService
    {
        private readonly IMapper _Mapper;
        private IContratoRepository _IContratoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private IMaestroRepository _IMaestroRepository;
        private IEmpresaRepository _IEmpresaRepository;
        private IContratoCompraContract _contratoCompraContract;

        public ContratoService(IContratoRepository contratoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository, IEmpresaRepository empresaRepository,
                               IContratoCompraContract contratoCompraContract)
        {
            _IContratoRepository = contratoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
            _IEmpresaRepository = empresaRepository;
            _contratoCompraContract = contratoCompraContract;
        }

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public List<ConsultaContratoDTO> Consultar(ConsultaContratoRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue)
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });
            }

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });
            }

            var list = _IContratoRepository.Consultar(request);
            return list.ToList();
        }

        public ConsultaContratoPorIdDTO ConsultarPorId(ConsultaContratoPorIdRequestDTO request)
        {
            return _IContratoRepository.ConsultarPorId(request.ContratoId);
        }

        public string Registrar(RegistrarActualizarContratoRequestDTO request)
        {
            Contrato contrato = _Mapper.Map<Contrato>(request);
            contrato.FechaRegistro = DateTime.Now;
            contrato.UsuarioRegistro = request.UsuarioRegistro;
            contrato.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.Contrato);

            string affected = _IContratoRepository.Registrar(contrato);

            return affected;
        }

        public async Task<TransactionResponse<string>> Confirmar(ContratoCompraDTO request)
        {
            TransactionResponse<string> response = new TransactionResponse<string>();
            ConsultaContratoPorIdDTO contrato = _IContratoRepository.ConsultarPorId(request.Id);
            request.FechaSolicitud = contrato.FechaRegistro;

            TransactionResult result = await _contratoCompraContract.RegistrarContrato(request);

            if (result != null)
            {
                _IContratoRepository.Confirmar(request.Id, result.TransactionHash);
                response.Data = result.TransactionHash;
                response.Result.Success = true;
            }

            return response;
        }
    }
}
