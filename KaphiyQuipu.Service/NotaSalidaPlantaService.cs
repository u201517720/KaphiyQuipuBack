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
    public class NotaSalidaPlantaService: INotaSalidaPlantaService
    {
        private readonly IMapper _Mapper;
        ICorrelativoRepository _ICorrelativoRepository;
        INotaSalidaPlantaRepository _INotaSalidaPlantaRepository;

        public NotaSalidaPlantaService(IMapper mapper, ICorrelativoRepository correlativoRepository, INotaSalidaPlantaRepository notaSalidaPlantaRepository)
        {
            _Mapper = mapper;
            _ICorrelativoRepository = correlativoRepository;
            _INotaSalidaPlantaRepository = notaSalidaPlantaRepository;
        }

        public List<ConsultarNotaSalidaPlantaDTO> Consultar(ConsultarNotaSalidaPlantaRequestDTO request)
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
            var list = _INotaSalidaPlantaRepository.Consultar(request.FechaInicio, request.FechaFin);
            return list.ToList();
        }

        public ConsultarPorIdNotaSalidaPlantaDTO ConsultarPorId(ConsultarPorIdNotaSalidaPlantaRequestDTO request)
        {
            ConsultarPorIdNotaSalidaPlantaDTO response = null;
            var lista = _INotaSalidaPlantaRepository.ConsultarPorId(request.Id);
            if (lista != null)
            {
                response = lista.FirstOrDefault();
            }
            return response;
        }

        public string Registrar(GenerarNotaSalidaPlantaRequestDTO request)
        {
            NotaSalidaPlanta notaSalida = _Mapper.Map<NotaSalidaPlanta>(request);
            notaSalida.FechaRegistro = DateTime.Now;
            notaSalida.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.NotaSalidaPlanta);

            string affected = _INotaSalidaPlantaRepository.Registrar(notaSalida);

            return affected;
        }
    }
}
