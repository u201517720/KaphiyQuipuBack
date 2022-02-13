using AutoMapper;
using Core.Common;
using Core.Common.Domain.Model;
using Core.Common.Email;
using Core.Common.Razor;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Contracts.Interface;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
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
        private readonly INotaIngresoPlantaContract _notaIngresoContract;
        private readonly IContratoCompraContract _contratoCompraContract;

        public NotaIngresoPlantaService(IMapper mapper, INotaIngresoPlantaRepository notaIngresoPlantaRepository, ICorrelativoRepository correlativoRepository, IViewRender viewRender, IEmailService emailService,
                                        INotaIngresoPlantaContract notaIngresoContract, IContratoCompraContract contratoCompraContract)
        {
            _Mapper = mapper;
            _INotaIngresoPlantaRepository = notaIngresoPlantaRepository;
            _ICorrelativoRepository = correlativoRepository;
            _viewRender = viewRender;
            _emailService = emailService;
            _notaIngresoContract = notaIngresoContract;
            _contratoCompraContract = contratoCompraContract;
        }

        public void AutorizarTransformacion(AutorizarTransformacionNotaIngresoPlantaRequestDTO request)
        {
            DateTime fechaActual = DateTime.Now;
            TransactionResult result = _contratoCompraContract.AgregarTrazabilidad(request.Contrato, Constants.TrazabilidadBC.AUTORIZAR_TRANSFORMACION, request.Id.ToString(), fechaActual).Result;
            _INotaIngresoPlantaRepository.AutorizarTransformacion(request.Id, request.Usuario, fechaActual, result.TransactionHash);
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

        public GenerarEtiquetasPlantaResponseDTO GenerarEtiquetasPlanta(int id)
        {
            GenerarEtiquetasPlantaResponseDTO response = new GenerarEtiquetasPlantaResponseDTO();
            response.listaEtiquetas = _INotaIngresoPlantaRepository.GenerarEtiquetasPlanta(id).ToList();
            return response;
        }

        public string Registrar(RegistrarNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta notaIngreso = _Mapper.Map<NotaIngresoPlanta>(request);
            notaIngreso.FechaRegistro = DateTime.Now;
            notaIngreso.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.NotaIngresoPlanta);

            TransactionResult result = _contratoCompraContract.AgregarTrazabilidad(request.Contrato, Constants.TrazabilidadBC.RECEPCION_MATERIA_PRIMA_PLANTA, notaIngreso.Correlativo, notaIngreso.FechaRegistro).Result;
            notaIngreso.HashBC = result.TransactionHash;

            string affected = _INotaIngresoPlantaRepository.Registrar(notaIngreso);

            return affected;
        }

        public void RegistrarControlCalidad(RegistrarControlCalidadNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlanta ingresoPlanta = _Mapper.Map<NotaIngresoPlanta>(request);
            ingresoPlanta.FechaActualizacion = DateTime.Now;

            TransactionResult result = _notaIngresoContract.RegistrarControlCalidad(request, request.CorrelativoNIP, ingresoPlanta.FechaActualizacion.Value).Result;
            ingresoPlanta.HashBC = result.TransactionHash;
            
            _INotaIngresoPlantaRepository.RegistrarControlCalidad(ingresoPlanta);
        }

        public async Task<bool> RegistrarResultadosTransformacion(RegistrarResultadosTransformacionNotaIngresoPlantaRequestDTO request)
        {
            NotaIngresoPlantaResultadoTransformacion transformacion = _Mapper.Map<NotaIngresoPlantaResultadoTransformacion>(request);
            transformacion.FechaRegistro = DateTime.Now;

            TransactionResult result = _notaIngresoContract.RegistrarResultadoTransformacion(request, request.CorrelativoNIP, transformacion.FechaRegistro).Result;
            transformacion.HashBC = result.TransactionHash;
            
            _INotaIngresoPlantaRepository.RegistrarResultadosTransformacion(transformacion);

            ParametroEmail oParametroEmail = new ParametroEmail();
            oParametroEmail.Para = "jjordandt@gmail.com";
            oParametroEmail.Asunto = "Finalización de transformación";
            oParametroEmail.IsHtml = true;
            oParametroEmail.Mensaje = await _viewRender.RenderAsync(@"Mailing\mail-finalizar-transformacion", request);

            return await _emailService.SendEmailAsync(oParametroEmail, Empresas.Transformadora);
        }
    }
}
