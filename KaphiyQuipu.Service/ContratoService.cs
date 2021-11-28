
using AutoMapper;
using Core.Common.Domain.Model;
using Core.Common.Email;
using Core.Common.Razor;
using Core.Common.SMS;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Agricultor;
using KaphiyQuipu.DTO.ContratoCompraVenta;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGYM.Common;

namespace KaphiyQuipu.Service
{
    public partial class ContratoService : IContratoService
    {
        private readonly IMapper _Mapper;
        private IContratoRepository _IContratoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private IContratoCompraContract _contratoCompraContract;

        private IMessageSender _messageSender;
        private IEmailService _emailService;
        private IViewRender _viewRender;


        public ContratoService(IContratoRepository contratoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository, IEmpresaRepository empresaRepository,
                               IContratoCompraContract contratoCompraContract,
                               IMessageSender messageSender,
                               IEmailService emailService,
                               IViewRender viewRender)
        {
            _IContratoRepository = contratoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _contratoCompraContract = contratoCompraContract;

            _messageSender = messageSender;
            _emailService = emailService;
            _viewRender = viewRender;
        }

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public List<ConsultaContratoDTO> Consultar(ConsultaContratoRequestDTO request)
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
            var list = _IContratoRepository.Consultar(request);
            return list.ToList();
        }

        public ConsultaContratoPorIdDTO ConsultarPorId(ConsultaContratoPorIdRequestDTO request)
        {
            ConsultaContratoPorIdDTO response = new ConsultaContratoPorIdDTO();
            response = _IContratoRepository.ConsultarPorId(request.ContratoId);
            var listaControles = _IContratoRepository.ObtenerControlCalidad(request.ContratoId);
            if (listaControles != null)
            {
                response.controles = listaControles.ToList();
            }
            return response;
        }

        public string Registrar(RegistrarActualizarContratoRequestDTO request)
        {
            Contrato contrato = _Mapper.Map<Contrato>(request);
            contrato.FechaRegistro = DateTime.Now;
            contrato.UsuarioRegistro = request.UsuarioRegistro;
            contrato.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.Contrato);

            string affected = _IContratoRepository.Registrar(contrato);

            //new EmailManager().enviarCorreo("","PRUEBA", )

            return affected;
        }

        public async Task<TransactionResponse<string>> Confirmar(ContratoCompraDTO request)
        {
            TransactionResponse<string> response = new TransactionResponse<string>();
            ConsultaContratoPorIdDTO contrato = _IContratoRepository.ConsultarPorId(request.Id);
            request.FechaSolicitud = contrato.FechaRegistro;

            TransactionResult result = await _contratoCompraContract.RegistrarContrato(request);

            if (result != null)
            {
                _IContratoRepository.Confirmar(request.Id, result.TransactionHash, request.Usuario);
                response.Data = result.TransactionHash;
                response.Result.Success = true;
            }

            return response;
        }

        public void AsociarAgricultoresContrato(AsociarAgricultoresContratoRequestDTO request)
        {
            if (request.agricultores.Count > 0)
            {
                request.Fecha = DateTime.Now;
                request.agricultores.ForEach(x => x.Fecha = request.Fecha);

                _IContratoRepository.AsociarAgricultoresContrato(request.agricultores);

                foreach (var item in request.agricultores)
                {
                    SolicitudConfirmacionAgrigultorDTO agrigultorDTO = _IContratoRepository.ObtenerDatosSolicitudConfirmacionAgrigultor(item.SocioFincaId, item.ContratoId);
                    var resultSMS = EnviarSolicitudConfirmacionSMS(agrigultorDTO).Result;
                    var resultEmail = EnviarCorreoSolicitudConfirmacion(agrigultorDTO).Result;
                }
            }
        }

        private async Task<bool> EnviarSolicitudConfirmacionSMS(SolicitudConfirmacionAgrigultorDTO agrigultorDTO)
        {
            string mensaje = $"Hola {agrigultorDTO.Nombre}, la Cooperativa de Servicios Múltiples Aprocassi te ha solicitado {agrigultorDTO.CantidadSolicitada} " +
                $"sacos de café pergamino y cada saco debe pesar {agrigultorDTO.PesoSaco} kilos, por favor ingresar a la pagina web http://kaphiyquipu.azurewebsites.net/ para brindar la confirmación.";
            (bool, string) result = await _messageSender.SendSmsAsync(agrigultorDTO.NumeroTelefonoCelular, mensaje);

            return result.Item1;
        }

        private async Task<bool> EnviarCorreoSolicitudConfirmacion(SolicitudConfirmacionAgrigultorDTO agrigultorDTO)
        {
            ParametroEmail oParametroEmail = new ParametroEmail();
            oParametroEmail.Para = agrigultorDTO.EmailId;
            oParametroEmail.Asunto = "Solicitud Confirmación";
            oParametroEmail.IsHtml = true;
            oParametroEmail.Mensaje = await _viewRender.RenderAsync(@"Mailing\mail-solicitud-confirmacion", agrigultorDTO);

            return await _emailService.SendEmailAsync(oParametroEmail);
        }

        public List<ObtenerAgricultoresPorContratoDTO> ObtenerAgricultoresPorContrato(ObtenerAgricultoresPorContratoRequestDTO request)
        {
            List<ObtenerAgricultoresPorContratoDTO> agricultores = new List<ObtenerAgricultoresPorContratoDTO>();
            var lista = _IContratoRepository.ObtenerAgricultoresPorContrato(request.ContratoId);
            agricultores = lista.ToList();
            agricultores.ForEach(x =>
            {
                x.NombreCompleto = string.Format("{0}, {1}", x.ApellidoSocio, x.NombreSocio);
                x.FechaRegistroString = x.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss");
            });
            return agricultores;
        }

        public void RegistrarControlCalidad(RegistrarControlCalidadRequestDTO request)
        {
            DateTime dt = DateTime.Now;
            request.controles.ForEach(x =>
            {
                TransactionResult result = _contratoCompraContract.AgregarControlCalidad(x).Result;
                x.HashBC = result.TransactionHash;
                x.FechaCreacion = dt;
            });


            _IContratoRepository.RegistrarControlCalidad(request.controles);
        }

        public void ConfirmarRecepcionCafeTerminado(ConfirmarRecepcionCafeTerminadoContratoRequestDTO request)
        {
            _IContratoRepository.ConfirmarRecepcionCafeTerminado(request.Id, request.Usuario, DateTime.Now);
        }
    }
}
