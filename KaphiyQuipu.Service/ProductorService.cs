﻿
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class ProductorService : IProductorService
    {
        private readonly IMapper _Mapper;

        private IProductorRepository _IProductorRepository;

        private ICorrelativoRepository _ICorrelativoRepository;


        public ProductorService(IProductorRepository productorRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IProductorRepository = productorRepository;

            _ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



        }


        public List<ConsultaProductorBE> ConsultarProductor(ConsultaProductorRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });
            }

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });
            }

            var list = _IProductorRepository.ConsultarProductor(request);
            return list.ToList();
        }

        public int RegistrarProductor(RegistrarActualizarProductorRequestDTO request)
        {
            ConsultaProductorRequestDTO consultaProductorRequestDTO = new ConsultaProductorRequestDTO();
            consultaProductorRequestDTO.TipoDocumentoId = request.TipoDocumentoId;
            consultaProductorRequestDTO.NumeroDocumento = request.NumeroDocumento;

            var list = _IProductorRepository.ValidarProductor(consultaProductorRequestDTO);

            if(list.ToList().Count>0)
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "El Productor ya se encuentra registrado." });
            }
            


            Productor productor = _Mapper.Map<Productor>(request);
            productor.FechaRegistro = DateTime.Now;
            productor.UsuarioRegistro = request.Usuario;



            productor.Numero = _ICorrelativoRepository.Obtener(null, Documentos.Productor);

            int affected = _IProductorRepository.Insertar(productor);

            return affected;
        }

        public int ActualizarProductor(RegistrarActualizarProductorRequestDTO request)
        {
            Productor productor = _Mapper.Map<Productor>(request);
            productor.FechaUltimaActualizacion = DateTime.Now;
            productor.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IProductorRepository.Actualizar(productor);

            return affected;
        }

        public ConsultaProductorIdBE ConsultarProductorId(ConsultaProductorIdRequestDTO request)
        {
            return _IProductorRepository.ConsultarProductorId(request.ProductorId);
        }

    }
}
