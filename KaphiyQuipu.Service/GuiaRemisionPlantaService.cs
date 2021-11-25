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
    public class GuiaRemisionPlantaService : IGuiaRemisionPlantaService
    {
        private readonly IMapper _Mapper;
        ICorrelativoRepository _ICorrelativoRepository;
        IGuiaRemisionPlantaRepository _IGuiaRemisionPlantaRepository;

        public GuiaRemisionPlantaService(IMapper mapper, ICorrelativoRepository correlativoRepository, IGuiaRemisionPlantaRepository guiaRemisionPlantaRepository)
        {
            _Mapper = mapper;
            _ICorrelativoRepository = correlativoRepository;
            _IGuiaRemisionPlantaRepository = guiaRemisionPlantaRepository;
        }

        public string Registrar(GenerarGuiaRemisionPlantaRequestDTO request)
        {
            GuiaRemisionPlanta guiaSalida = _Mapper.Map<GuiaRemisionPlanta>(request);
            guiaSalida.FechaRegistro = DateTime.Now;
            guiaSalida.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.GuiaRemisionPlanta);

            string affected = _IGuiaRemisionPlantaRepository.Registrar(guiaSalida);

            return affected;
        }
    }
}
