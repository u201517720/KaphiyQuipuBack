﻿using AutoMapper;
using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public class NotaIngresoPlantaService: INotaIngresoPlantaService
    {
        private readonly IMapper _Mapper;
        INotaIngresoPlantaRepository _INotaIngresoPlantaRepository;
        ICorrelativoRepository _ICorrelativoRepository;

        public NotaIngresoPlantaService(IMapper mapper, INotaIngresoPlantaRepository notaIngresoPlantaRepository, ICorrelativoRepository correlativoRepository)
        {
            _Mapper = mapper;
            _INotaIngresoPlantaRepository = notaIngresoPlantaRepository;
            _ICorrelativoRepository = correlativoRepository;
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

        public ConsultarPorIdNotaIngresoPlantaDTO ConsultarPorId(ConsultarPorIdNotaIngresoPlantaRequestDTO request)
        {
            ConsultarPorIdNotaIngresoPlantaDTO response = null;
            var ingresoPlanta = _INotaIngresoPlantaRepository.ConsultarPorId(request.Id);
            if (ingresoPlanta.Any())
            {
                response = ingresoPlanta.ToList().FirstOrDefault();
            }
            
            return response;
        }

        public string Registrar(RegistrarNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta notaIngreso = _Mapper.Map<NotaIngresoPlanta>(request);
            notaIngreso.FechaRegistro = DateTime.Now;
            notaIngreso.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.NotaIngresoPlanta);

            string affected = _INotaIngresoPlantaRepository.Registrar(notaIngreso);

            return affected;
        }
    }
}
