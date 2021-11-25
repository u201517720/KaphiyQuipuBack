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
