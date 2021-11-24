using AutoMapper;
using Core.Common.Domain.Model;
using Core.Common.Email;
using Core.Common.Razor;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaphiyQuipu.Service
{
    public class NotaIngresoPlantaService: INotaIngresoPlantaService
    {
        private readonly IMapper _Mapper;
        INotaIngresoPlantaRepository _INotaIngresoPlantaRepository;
        ICorrelativoRepository _ICorrelativoRepository;
        private IViewRender _viewRender;
        private IEmailService _emailService;

        public NotaIngresoPlantaService(IMapper mapper, INotaIngresoPlantaRepository notaIngresoPlantaRepository, ICorrelativoRepository correlativoRepository, IViewRender viewRender, IEmailService emailService)
        {
            _Mapper = mapper;
            _INotaIngresoPlantaRepository = notaIngresoPlantaRepository;
            _ICorrelativoRepository = correlativoRepository;
            _viewRender = viewRender;
            _emailService = emailService;
        }

        public void AutorizarTransformacion(AutorizarTransformacionNotaIngresoPlantaRequestDTO request)
        {
            _INotaIngresoPlantaRepository.AutorizarTransformacion(request.Id, request.Usuario, DateTime.Now);
        }

        public void ConfirmarRecepcionMateriaPrima(ConfirmarRecepcionMateriaPrimaNotaIngresoPlantaRequestDTO request)
        {
            _INotaIngresoPlantaRepository.ConfirmarRecepcionMateriaPrima(request.Id, request.Usuario, DateTime.Now);
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

        public void FinalizarEtiquetado(FinalizarEtiquetadoNotaIngresoPlantaRequestDTO request)
        {
            _INotaIngresoPlantaRepository.FinalizarEtiquetado(request.Id, request.Usuario, DateTime.Now);
        }

        public async Task<bool> FinalizarTransformacion(FinalizarTransformacionNotaIngresoPlantaRequestDTO request)
        {
            _INotaIngresoPlantaRepository.FinalizarTransformacion(request.Id, request.Usuario, DateTime.Now);

            ParametroEmail oParametroEmail = new ParametroEmail();
            oParametroEmail.Para = "jjordandt@gmail.com";
            oParametroEmail.Asunto = "Finalización de transformación";
            oParametroEmail.IsHtml = true;
            oParametroEmail.Mensaje = await _viewRender.RenderAsync(@"Mailing\mail-finalizar-transformacion", request);

            return await _emailService.SendEmailAsync(oParametroEmail, "Planta Transformadora");
        }

        public string Registrar(RegistrarNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta notaIngreso = _Mapper.Map<NotaIngresoPlanta>(request);
            notaIngreso.FechaRegistro = DateTime.Now;
            notaIngreso.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.NotaIngresoPlanta);

            string affected = _INotaIngresoPlantaRepository.Registrar(notaIngreso);

            return affected;
        }

        public void RegistrarControlCalidad(RegistrarControlCalidadNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta ingresoPlanta = _Mapper.Map<NotaIngresoPlanta>(request);
            ingresoPlanta.FechaActualizacion = DateTime.Now;
            _INotaIngresoPlantaRepository.RegistrarControlCalidad(ingresoPlanta);
        }

        public void RegistrarResultadosTransformacion(RegistrarResultadosTransformacionNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlantaResultadoTransformacion transformacion = _Mapper.Map<NotaIngresoPlantaResultadoTransformacion>(request);
            transformacion.FechaRegistro = DateTime.Now;

            _INotaIngresoPlantaRepository.RegistrarResultadosTransformacion(transformacion);
        }
    }
}
