using AutoMapper;
using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaphiyQuipu.Service
{
    public class NotaIngresoPlantaService: INotaIngresoPlantaService
    {
        private readonly IMapper _Mapper;
        INotaIngresoPlantaRepository _INotaIngresoPlantaRepository;

        public NotaIngresoPlantaService(IMapper mapper, INotaIngresoPlantaRepository notaIngresoPlantaRepository)
        {
            _Mapper = mapper;
            _INotaIngresoPlantaRepository = notaIngresoPlantaRepository;
        }

        public List<ConsultaNotaIngresoPlantaDTO> Consultar(ConsultarNotaIngresoPlantaRequestDTO request)
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
            var list = _INotaIngresoPlantaRepository.Consultar(request.FechaInicio, request.FechaFin);
            return list.ToList();
        }
    }
}
