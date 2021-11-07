
using AutoMapper;
using Core.Common.Domain.Model;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGYM.Common;

namespace KaphiyQuipu.Service
{
    public partial class ContratoService : IContratoService
    {
        private readonly IMapper _Mapper;
        private IContratoRepository _IContratoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private IContratoCompraContract _contratoCompraContract;

        public ContratoService(IContratoRepository contratoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository, IEmpresaRepository empresaRepository,
                               IContratoCompraContract contratoCompraContract)
        {
            _IContratoRepository = contratoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
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
                throw new ResultException(new Result { ErrCode = "01", Message = "La fecha inicio y fin son obligatorias. Por favor, ingresarlas." });
            }

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "El rango entre las fechas no puede ser mayor a 1 año." });
            }
            request.FechaFin = request.FechaFin.AddHours(23).AddMinutes(59).AddSeconds(59);
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

            //new EmailManager().enviarCorreo("","PRUEBA", )

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
                _IContratoRepository.Confirmar(request.Id, result.TransactionHash, request.Usuario);
                response.Data = result.TransactionHash;
                response.Result.Success = true;
            }

            return response;
        }

        public void AsociarAgricultoresContrato(AsociarAgricultoresContratoRequestDTO request)
        {
            if (request.agricultores.Count > 0)
            {
                request.Fecha = DateTime.Now;
                request.agricultores.ForEach(x => x.Fecha = request.Fecha);

                _IContratoRepository.AsociarAgricultoresContrato(request.agricultores);
            }
        }

        public List<ObtenerAgricultoresPorContratoDTO> ObtenerAgricultoresPorContrato(ObtenerAgricultoresPorContratoRequestDTO request)
        {
            List<ObtenerAgricultoresPorContratoDTO> agricultores = new List<ObtenerAgricultoresPorContratoDTO>();
            var lista = _IContratoRepository.ObtenerAgricultoresPorContrato(request.ContratoId);
            agricultores = lista.ToList();
            agricultores.ForEach(x =>
            {
                x.NombreCompleto = string.Format("{0}, {1}", x.ApellidoSocio, x.NombreSocio);
                x.FechaRegistroString = x.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss");
            });
            return agricultores;
        }
    }
}
