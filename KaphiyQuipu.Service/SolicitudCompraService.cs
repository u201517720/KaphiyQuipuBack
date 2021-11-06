using AutoMapper;
using Core.Common.Domain.Model;
using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.ERC20;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaphiyQuipu.Blockchain.Contracts;

namespace KaphiyQuipu.Service
{
    public class SolicitudCompraService : ISolicitudCompraService
    {
        private readonly IMapper _Mapper;
        private ICorrelativoRepository _ICorrelativoRepository;
        private ISolicitudCompraRepository _ISolicitudCompraRepository;
        private readonly ISolicitudCompraContract _solicitudCompraContract;

        public SolicitudCompraService(ICorrelativoRepository correlativoRepository, IMapper mapper, ISolicitudCompraRepository solicitudCompraRepository,
                                      ISolicitudCompraContract solicitudCompraContract)
        {
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _ISolicitudCompraRepository = solicitudCompraRepository;
            _solicitudCompraContract = solicitudCompraContract;
        }

        public List<ConsultaSolicitudCompraDTO> Consultar(ConsultaSolicitudCompraRequestDTO request)
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
            var list = _ISolicitudCompraRepository.Consultar(request);
            return list.ToList();
        }

        public ConsultaSolicitudCompraPorIdDTO ConsultarPorId(ConsultaSolicitudCompraPorIdRequestDTO request)
        {
            ConsultaSolicitudCompraPorIdDTO solicitudCompra = _ISolicitudCompraRepository.ConsultarPorId(request.SolicitudCompraId);
            return solicitudCompra;
        }

        public string Registrar(RegistrarActualizarSolicitudCompraRequestDTO request)
        {
            Result resultValidacion = ValidarRegistrar(request);

            if (resultValidacion != null)
            {
                throw new ResultException(resultValidacion);
            }

            SolicitudCompra solicitudCompra = _Mapper.Map<SolicitudCompra>(request);
            solicitudCompra.UsuarioRegistro = request.UsuarioRegistro;
            solicitudCompra.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.SolicitudCompra);
            string affected = _ISolicitudCompraRepository.Insertar(solicitudCompra);

            return affected;
        }

        Result ValidarRegistrar(RegistrarActualizarSolicitudCompraRequestDTO request, bool register = true)
        {
            Result result = null;
            string message = string.Empty;
            if (!register && string.IsNullOrEmpty(request.CodigoCliente))
            {
                result = new Result { ErrCode = "01", Message = "El distribuidor es obligatorio." };
            }
            else if (string.IsNullOrEmpty(request.PaisId))
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

        public async Task<TransactionResult> Registrar(SolicitudCompraDTO solicitudCompra)
        {
            return await _solicitudCompraContract.RegistrarSolicitud(solicitudCompra);
        }

        public async Task<SolicitudCompraOutputDTO> ObtenerSolicitud(string correlativo)
        {
            return await _solicitudCompraContract.ObtenerSolicitud(correlativo);
        }
    }
}
