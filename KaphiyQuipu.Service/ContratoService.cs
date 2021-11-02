
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

        public ContratoService(IContratoRepository contratoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository, IEmpresaRepository empresaRepository)
        {
            _IContratoRepository = contratoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _IMaestroRepository = maestroRepository;
            _IEmpresaRepository = empresaRepository;
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
    }
}
