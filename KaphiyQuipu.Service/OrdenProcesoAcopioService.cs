using AutoMapper;
using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaphiyQuipu.Service
{
    public class OrdenProcesoAcopioService: IOrdenProcesoAcopioService
    {
        private ICorrelativoRepository _ICorrelativoRepository;
        IOrdenProcesoAcopioRepository _IOrdenProcesoAcopioRepository;
        private readonly IMapper _Mapper;

        public OrdenProcesoAcopioService(ICorrelativoRepository correlativoRepository, IOrdenProcesoAcopioRepository ordenProcesoAcopioRepository, IMapper mapper)
        {
            _ICorrelativoRepository = correlativoRepository;
            _IOrdenProcesoAcopioRepository = ordenProcesoAcopioRepository;
            _Mapper = mapper;
        }

        public string Registrar(RegistrarOrdenProcesoAcopioRequestDTO request)
        {
            OrdenProcesoAcopio ordenProceso = _Mapper.Map<OrdenProcesoAcopio>(request);
            ordenProceso.FechaRegistro = DateTime.Now;
            ordenProceso.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.OrdenProcesoAcopio);

            string affected = _IOrdenProcesoAcopioRepository.Registrar(ordenProceso);

            return affected;
        }

        public List<ConsultarOrdenProcesoAcopioDTO> Consultar(ConsultaOrdenProcesoAcopioRequestDTO request)
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
            var list = _IOrdenProcesoAcopioRepository.Consultar(request.FechaInicio, request.FechaFin);
            return list.ToList();
        }

        public ConsultarPorIdOrdenProcesoDTO ConsultarPorId(ConsultarPorIdOrdenProcesoRequestDTO request)
        {
            ConsultarPorIdOrdenProcesoDTO response = new ConsultarPorIdOrdenProcesoDTO();
            var guiaRecepcion = _IOrdenProcesoAcopioRepository.ConsultarPorId(request.OrdenProcesoId);
            if (guiaRecepcion.Any())
            {
                response = guiaRecepcion.ToList().FirstOrDefault();
            }
            return response;
        }
    }
}
