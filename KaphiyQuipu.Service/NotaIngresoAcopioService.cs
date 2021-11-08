using AutoMapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
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

        public string Registrar(RegistrarNotaIngresoAcopioRequestDTO request)
        {
            NotaIngresoAlmacenAcopio notaIngreso = _Mapper.Map<NotaIngresoAlmacenAcopio>(request);
            notaIngreso.FechaRegistro = DateTime.Now;
            notaIngreso.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.NotaIngresoAcopio);

            string affected = _INotaIngresoAcopioRepository.Registrar(notaIngreso);

            return affected;
        }
    }
}
