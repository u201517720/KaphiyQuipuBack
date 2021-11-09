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
    public class NotaIngresoAcopioService: INotaIngresoAcopioService
    {
        private readonly IMapper _Mapper;
        private ICorrelativoRepository _ICorrelativoRepository;
        private INotaIngresoAcopioRepository _INotaIngresoAcopioRepository;

        public NotaIngresoAcopioService(IMapper mapper, ICorrelativoRepository correlativoRepository, INotaIngresoAcopioRepository notaIngresoAcopioRepository)
        {
            _Mapper = mapper;
            _ICorrelativoRepository = correlativoRepository;
            _INotaIngresoAcopioRepository = notaIngresoAcopioRepository;
        }

        public List<ConsultaNotaIngresoAcopioDTO> Consultar(ConsultaNotaIngresoAcopioRequestDTO request)
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
            var list = _INotaIngresoAcopioRepository.Consultar(request);
            return list.ToList();
        }

        public ConsultaPorIdNotaIngresoAcopioDTO ConsultarPorId(ConsultaPorIdNotaIngresoAcopioRequestDTO request)
        {
            ConsultaPorIdNotaIngresoAcopioDTO response = new ConsultaPorIdNotaIngresoAcopioDTO();
            var guiaRecepcion = _INotaIngresoAcopioRepository.ConsultarPorId(request.NotaIngresoAcopioId);
            if (guiaRecepcion.Any())
            {
                response = guiaRecepcion.ToList().FirstOrDefault();
            }

            if (response != null)
            {
                var agricultores = _INotaIngresoAcopioRepository.ObtenerAgricultores(request.NotaIngresoAcopioId);
                response.agricultores = agricultores.ToList();
                var controles = _INotaIngresoAcopioRepository.ObtenerControlesCalidad(request.NotaIngresoAcopioId);
                response.controlesCalidad = controles.ToList();
            }
            return response;
        }

        public string Registrar(RegistrarNotaIngresoAcopioRequestDTO request)
        {
            NotaIngresoAlmacenAcopio notaIngreso = _Mapper.Map<NotaIngresoAlmacenAcopio>(request);
            notaIngreso.FechaRegistro = DateTime.Now;
            notaIngreso.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.NotaIngresoAcopio);

            string affected = _INotaIngresoAcopioRepository.Registrar(notaIngreso);

            return affected;
        }

        public void UbicarMateriaPrimaAlmacen(UbicarMateriaPrimaAlmacenRequestDTO request)
        {
            request.Fecha = DateTime.Now;
            _INotaIngresoAcopioRepository.UbicarMateriaPrimaAlmacen(request);
        }
    }
}
