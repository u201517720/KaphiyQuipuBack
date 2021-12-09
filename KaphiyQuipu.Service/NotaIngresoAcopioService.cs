using AutoMapper;
using Core.Common;
using Core.Common.Domain.Model;
using Core.Common.Email;
using Core.Common.Razor;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Service
{
    public class NotaIngresoAcopioService: INotaIngresoAcopioService
    {
        private readonly IMapper _Mapper;
        private ICorrelativoRepository _ICorrelativoRepository;
        private INotaIngresoAcopioRepository _INotaIngresoAcopioRepository;
        private IContratoCompraContract _contratoCompraContract;
        private IViewRender _viewRender;
        private IEmailService _emailService;

        public NotaIngresoAcopioService(IMapper mapper, ICorrelativoRepository correlativoRepository, INotaIngresoAcopioRepository notaIngresoAcopioRepository, IContratoCompraContract contratoCompraContract,
            IViewRender viewRender, IEmailService emailService)
        {
            _Mapper = mapper;
            _ICorrelativoRepository = correlativoRepository;
            _INotaIngresoAcopioRepository = notaIngresoAcopioRepository;
            _contratoCompraContract = contratoCompraContract;
            _viewRender = viewRender;
            _emailService = emailService;
        }

        public List<ConsultaNotaIngresoAcopioDTO> Consultar(ConsultaNotaIngresoAcopioRequestDTO request)
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
            var list = _INotaIngresoAcopioRepository.Consultar(request);
            return list.ToList();
        }

        public ConsultaPorIdNotaIngresoAcopioDTO ConsultarPorId(ConsultaPorIdNotaIngresoAcopioRequestDTO request)
        {
            ConsultaPorIdNotaIngresoAcopioDTO response = new ConsultaPorIdNotaIngresoAcopioDTO();
            var guiaRecepcion = _INotaIngresoAcopioRepository.ConsultarPorId(request.NotaIngresoAcopioId);
            if (guiaRecepcion.Any())
            {
                response = guiaRecepcion.ToList().FirstOrDefault();
            }

            if (response != null)
            {
                var agricultores = _INotaIngresoAcopioRepository.ObtenerAgricultores(request.NotaIngresoAcopioId);
                response.agricultores = agricultores.ToList();
                var controles = _INotaIngresoAcopioRepository.ObtenerControlesCalidad(request.NotaIngresoAcopioId);
                response.controlesCalidad = controles.ToList();
            }
            return response;
        }

        public string Registrar(RegistrarNotaIngresoAcopioRequestDTO request)
        {
            NotaIngresoAlmacenAcopio notaIngreso = _Mapper.Map<NotaIngresoAlmacenAcopio>(request);
            notaIngreso.FechaRegistro = DateTime.Now;
            notaIngreso.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.NotaIngresoAcopio);

            string affected = _INotaIngresoAcopioRepository.Registrar(notaIngreso);

            return affected;
        }

        public void UbicarMateriaPrimaAlmacen(UbicarMateriaPrimaAlmacenRequestDTO request)
        {
            request.Fecha = DateTime.Now;
            TransactionResult result =  _contratoCompraContract.AgregarNotaIngresoAlmacenAcopio(request).Result;
            request.HashBC = result.TransactionHash;
            _INotaIngresoAcopioRepository.UbicarMateriaPrimaAlmacen(request);
        }

        public List<StickerAcopioDTO> ObtenerStickers(int notaIngresoId)
        {
            var stickers = _INotaIngresoAcopioRepository.ObtenerStickers(notaIngresoId);
            List<StickerAcopioDTO> response = stickers.ToList();
            return response;
        }

        public async Task<bool> ConfirmarEtiquetado(ConfirmarEtiquetadoRequestDTO request)
        {
            request.Fecha = DateTime.Now;
            _INotaIngresoAcopioRepository.ConfirmarEtiquetado(request.NotaIngresoId, request.Usuario, request.Fecha);

            ParametroEmail oParametroEmail = new ParametroEmail();
            oParametroEmail.Para = "jjordandt@gmail.com";
            oParametroEmail.Asunto = "Finalización de etiquetado de sacos";
            oParametroEmail.IsHtml = true;
            oParametroEmail.Mensaje = await _viewRender.RenderAsync(@"Mailing\mail-confirmar-etiquetado", request);

            return await _emailService.SendEmailAsync(oParametroEmail);
        }

        public List<ConsultarDevolucionNotaIngresoAcopioDTO> ConsultarDevolucion(ConsultarDevolucionNotaIngresoAcopioRequestDTO request)
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
            var list = _INotaIngresoAcopioRepository.ConsultarDevolucion(request.FechaInicio, request.FechaFin);
            return list.ToList();
        }

        public string RegistrarDevolucion(RegistrarDevolucionNotaIngresoRequestDTO request)
        {
            NotaIngresoDevolucion notaIngreso = _Mapper.Map<NotaIngresoDevolucion>(request);
            notaIngreso.FechaRegistro = DateTime.Now;
            notaIngreso.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.NotaIngresoDevolucion);

            TransactionResult result = _contratoCompraContract.AgregarTrazabilidad(request.Contrato, Constants.TrazabilidadBC.RECEPCION_CAFE_PROCESADO_POR_COOPERATIVA, notaIngreso.Correlativo, notaIngreso.FechaRegistro).Result;
            notaIngreso.HashBC = result.TransactionHash;

            string affected = _INotaIngresoAcopioRepository.RegistrarDevolucion(notaIngreso);

            return affected;
        }

        public ConsultarDevolucionPorIdNotaIngresoDTO ConsultarDevolucionPorId(ConsultarDevolucionPorIdNotaIngresoRequestDTO request)
        {
            ConsultarDevolucionPorIdNotaIngresoDTO response = new ConsultarDevolucionPorIdNotaIngresoDTO();
            var notaIngreso = _INotaIngresoAcopioRepository.ConsultarDevolucionPorId(request.Id);
            if (notaIngreso.Any())
            {
                response = notaIngreso.ToList().FirstOrDefault();
            }

            return response;
        }

        public void ConfirmarAtencionCompleta(ConfirmarAtencionCompletaNotaIngresoDevoRequestDTO request)
        {
            _INotaIngresoAcopioRepository.ConfirmarAtencionCompleta(request.Id, request.Usuario, DateTime.Now);
        }

        public GenerarEtiquetasAcopioResponseDTO GenerarEtiquetasAcopio(int id)
        {
            GenerarEtiquetasAcopioResponseDTO response = new GenerarEtiquetasAcopioResponseDTO();
            response.listaEtiquetas = _INotaIngresoAcopioRepository.GenerarEtiquetasAcopio(id).ToList();
            return response;
        }
    }
}
