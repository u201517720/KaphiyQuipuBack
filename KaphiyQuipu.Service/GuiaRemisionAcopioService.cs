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
    public class GuiaRemisionAcopioService: IGuiaRemisionAcopioService
    {
        private readonly IMapper _Mapper;
        ICorrelativoRepository _ICorrelativoRepository;
        IViewRender _viewRender;
        IEmailService _emailService;
        IGuiaRemisionAcopioRepository _IGuiaRemisionAcopioRepository;
        IMarcadoSacoAcopioRepository _IMarcadoSacoAcopioRepository;
        private readonly IContratoCompraContract _contratoCompraContract;

        public GuiaRemisionAcopioService(IMapper mapper, ICorrelativoRepository correlativoRepository, IViewRender viewRender, IEmailService emailService, IGuiaRemisionAcopioRepository guiaRemisionAcopioRepository, IMarcadoSacoAcopioRepository marcadoSacoAcopioRepository,
                                        IContratoCompraContract contratoCompraContract)
        {
            _Mapper = mapper;
            _ICorrelativoRepository = correlativoRepository;
            _viewRender = viewRender;
            _emailService = emailService;
            _IGuiaRemisionAcopioRepository = guiaRemisionAcopioRepository;
            _IMarcadoSacoAcopioRepository = marcadoSacoAcopioRepository;
            _contratoCompraContract = contratoCompraContract;
        }

        public List<ConsultarGuiaRemisionAcopioDTO> Consultar(ConsultarGuiaRemisionAcopioRequestDTO request)
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
            var list = _IGuiaRemisionAcopioRepository.Consultar(request.FechaInicio, request.FechaFin);
            return list.ToList();
        }

        public ConsultarPorCorrelativoGuiaRemisionDTO ConsultarPorCorrelativo(ConsultarPorCorrelativoGuiaRemisionRequestDTO request)
        {
            ConsultarPorCorrelativoGuiaRemisionDTO response = null;
            var guiaRecepcion = _IGuiaRemisionAcopioRepository.ConsultarPorCorrelativo(request.Correlativo);
            if (guiaRecepcion.Any())
            {
                response = guiaRecepcion.ToList().FirstOrDefault();
            }
           
            return response;
        }

        public ConsultarPorIdGuiaRemisionAcopioDTO ConsultarPorId(ConsultarPorIdGuiaRemisionAcopioRequestDTO request)
        {
            ConsultarPorIdGuiaRemisionAcopioDTO response = null;
            var lista = _IGuiaRemisionAcopioRepository.ConsultarPorId(request.Id);
            if (lista != null)
            {
                response = lista.FirstOrDefault();
            }
            return response;
        }

        public async Task<string> Registrar(RegistrarGuiaRemisionAcopioRequestDTO request)
        {
            GuiaRemisionAcopio guiaRemision = _Mapper.Map<GuiaRemisionAcopio>(request);
            guiaRemision.FechaRegistro = DateTime.Now;
            guiaRemision.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.GuiaRemisionAcopio);

            TransactionResult result = await _contratoCompraContract.AgregarTrazabilidad(request.Contrato, Constants.TrazabilidadBC.ENVIO_PLANTA_TRANSFORMADORA, guiaRemision.Correlativo, guiaRemision.FechaRegistro);
            guiaRemision.HashBC = result.TransactionHash;
            string affected = _IGuiaRemisionAcopioRepository.Registrar(guiaRemision);

            MarcadoSacoAcopio marcado = _Mapper.Map<MarcadoSacoAcopio>(request);
            marcado.FechaRegistro = DateTime.Now;
            marcado.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.MarcadoSacosAcopio);
            _IMarcadoSacoAcopioRepository.Registrar(marcado);

            ParametroEmail oParametroEmail = new ParametroEmail();
            oParametroEmail.Para = "jjordandt@gmail.com";
            oParametroEmail.Asunto = "Envio de materia prima";
            oParametroEmail.IsHtml = true;
            oParametroEmail.Mensaje = await _viewRender.RenderAsync(@"Mailing\mail-envioMateriaPrima-Planta", guiaRemision);

            await _emailService.SendEmailAsync(oParametroEmail);

            return affected;
        }

        public async Task<string> RegistrarDevolucion(RegistrarDevolucionGuiaRemisionRequestDTO request)
        {
            GuiaRemisionDevolucion guiaRemision = _Mapper.Map<GuiaRemisionDevolucion>(request);
            guiaRemision.FechaRegistro = DateTime.Now;
            guiaRemision.FechaTraslado = guiaRemision.FechaRegistro;
            guiaRemision.FechaEmision = guiaRemision.FechaRegistro;
            guiaRemision.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.GuiaRemisionDevolucion);

            TransactionResult result = await _contratoCompraContract.AgregarTrazabilidad(request.Contrato, Constants.TrazabilidadBC.ENVIO_CAFE_HACIA_DISTRIBUIDORA, guiaRemision.Correlativo, guiaRemision.FechaRegistro);
            guiaRemision.HashBC = result.TransactionHash;

            string affected = _IGuiaRemisionAcopioRepository.RegistrarDevolucion(guiaRemision);

            ParametroEmail oParametroEmail = new ParametroEmail();
            oParametroEmail.Para = "jjordandt@gmail.com";
            oParametroEmail.Asunto = "Envio de materia procesado";
            oParametroEmail.IsHtml = true;
            oParametroEmail.Mensaje = await _viewRender.RenderAsync(@"Mailing\mail-confirmarEnviCafeProcesado", request);

            await _emailService.SendEmailAsync(oParametroEmail);

            return affected;
        }
    }
}
