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
    public class MarcadoSacoAcopioService: IMarcadoSacoAcopioService
    {
        private readonly IMapper _Mapper;
        private ICorrelativoRepository _ICorrelativoRepository;
        IMarcadoSacoAcopioRepository _IMarcadoSacoAcopioRepository;

        public MarcadoSacoAcopioService(IMapper mapper, ICorrelativoRepository correlativoRepository, IMarcadoSacoAcopioRepository marcadoSacoAcopioRepository)
        {
            _Mapper = mapper;
            _ICorrelativoRepository = correlativoRepository;
            _IMarcadoSacoAcopioRepository = marcadoSacoAcopioRepository;
        }

        public string Registrar(RegistrarGuiaRemisionAcopioRequestDTO request)
        {
            MarcadoSacoAcopio notaIngreso = _Mapper.Map<MarcadoSacoAcopio>(request);
            notaIngreso.FechaRegistro = DateTime.Now;
            notaIngreso.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.MarcadoSacosAcopio);

            string affected = _IMarcadoSacoAcopioRepository.Registrar(notaIngreso);

            return affected;
        }
    }
}
