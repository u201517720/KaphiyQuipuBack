using AutoMapper;
using Core.Common.Domain.Model;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public class GuiaRecepionMateriaPrimaService : IGuiaRecepionMateriaPrimaService
    {
        private IGuiaRecepcionMateriaPrimaRepository _IGuiaRecepcionRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IContratoCompraContract _contratoCompraContract;
        private readonly IMapper _Mapper;

        public GuiaRecepionMateriaPrimaService(IGuiaRecepcionMateriaPrimaRepository guiaRecepcionMateriaPrimaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IContratoCompraContract contratoCompraContract)
        {
            _IGuiaRecepcionRepository = guiaRecepcionMateriaPrimaRepository;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _contratoCompraContract = contratoCompraContract;
        }

        public List<ConsultaGuiaRecepcionMateriaPrimaDTO> Consultar(ConsultarGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue)
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "La fecha inicio y fin son obligatorias. Por favor, ingresarlas." });
            }

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 365)
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "El rango entre las fechas no puede ser mayor a 1 año." });
            }
            request.FechaFin = request.FechaFin.AddHours(23).AddMinutes(59).AddSeconds(59);
            var list = _IGuiaRecepcionRepository.Consultar(request);
            return list.ToList();
        }

        public string Registrar(RegistrarActualizarGuiaRecepcionRequestDTO request)
        {
            GuiaRecepcionMateriaPrima guia = _Mapper.Map<GuiaRecepcionMateriaPrima>(request);
            guia.FechaRegistro = DateTime.Now;
            guia.UsuarioRegistro = request.UsuarioRegistro;
            guia.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.GuiaRecepcion);

            TransactionResult result = _contratoCompraContract.AgregarAnalisisFisicoCafe(guia, guia.FechaRegistro).Result;
            guia.HashBC = result.TransactionHash;
            string affected = _IGuiaRecepcionRepository.Registrar(guia);

            return affected;
        }

        public ConsultarPorIdGuiaRecepcionMateriaPrimaDTO ConsultarPorId(ConsultarPorIdGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            ConsultarPorIdGuiaRecepcionMateriaPrimaDTO response = new ConsultarPorIdGuiaRecepcionMateriaPrimaDTO();
            var guiaRecepcion = _IGuiaRecepcionRepository.ConsultarPorId(request.GuiaRecepcionId);
            if (guiaRecepcion.Any())
            {
                response = guiaRecepcion.ToList().FirstOrDefault();
            }

            if (response != null)
            {
                var agricultores = _IGuiaRecepcionRepository.ObtenerAgricultores(request.GuiaRecepcionId);
                response.agricultores = agricultores.ToList();
                var controles = _IGuiaRecepcionRepository.ObtenerControlesCalidad(request.GuiaRecepcionId);
                response.controlesCalidad = controles.ToList();
            }
            return response;
        }
    }
}
