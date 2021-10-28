using AutoMapper;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Service;
using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Service
{
    public class SolicitudCompraService : ISolicitudCompraService
    {
        private readonly IMapper _Mapper;
        private ICorrelativoRepository _ICorrelativoRepository;
        private ISolicitudCompraRepository _ISolicitudCompraRepository;

        public SolicitudCompraService(ICorrelativoRepository correlativoRepository, IMapper mapper, ISolicitudCompraRepository solicitudCompraRepository)
        {
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _ISolicitudCompraRepository = solicitudCompraRepository;
        }

        public int Registrar(RegistrarActualizarSolicitudCompraRequestDTO request)
        {
            Result resultValidacion = ValidarRegistrar(request);

            if (resultValidacion != null)
            {
                throw new ResultException(resultValidacion);
            }

            SolicitudCompra solicitudCompra = _Mapper.Map<SolicitudCompra>(request);
            solicitudCompra.UsuarioRegistro = request.UsuarioRegistro;
            solicitudCompra.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.SolicitudCompra);
            int affected = _ISolicitudCompraRepository.Insertar(solicitudCompra);

            return affected;
        }

        Result ValidarRegistrar(RegistrarActualizarSolicitudCompraRequestDTO request)
        {
            Result result = null;
            string message = string.Empty;
            if (request.DistribuidorId <= 0)
            {
                result = new Result { ErrCode = "01", Message = "El distribuidor es obligatorio." };
            }
            else if (request.PaisId <= 0)
            {
                result = new Result { ErrCode = "02", Message = "El país es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.DepartamentoId))
            {
                result = new Result { ErrCode = "03", Message = "El departamento es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.MonedaId))
            {
                result = new Result { ErrCode = "04", Message = "La moneda es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.UnidadMedidaId))
            {
                result = new Result { ErrCode = "05", Message = "La unidad de medida es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.TipoProduccionId))
            {
                result = new Result { ErrCode = "06", Message = "El tipo de producción es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.EmpaqueId))
            {
                result = new Result { ErrCode = "07", Message = "El empaque es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.TipoEmpaqueId))
            {
                result = new Result { ErrCode = "08", Message = "El tipo de empaque es obligatorio." };
            }
            else if (request.TotalSacos <= 0)
            {
                result = new Result { ErrCode = "09", Message = "El total de sacos es obligatorio." };
            }
            else if (request.PesoSaco <= 0)
            {
                result = new Result { ErrCode = "10", Message = "El peso del saco es obligatorio." };
            }
            else if (request.PesoKilos <= 0)
            {
                result = new Result { ErrCode = "11", Message = "El peso en kilos es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.ProductoId))
            {
                result = new Result { ErrCode = "12", Message = "El producto es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.SubProductoId))
            {
                result = new Result { ErrCode = "13", Message = "El sub producto es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.GradoPreparacionId))
            {
                result = new Result { ErrCode = "14", Message = "El grado de preparación es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.CalidadId))
            {
                result = new Result { ErrCode = "15", Message = "La calidad es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.UsuarioRegistro))
            {
                result = new Result { ErrCode = "16", Message = "El usuario de registro es obligatorio." };
            }
            return result;
        }
    }
}
