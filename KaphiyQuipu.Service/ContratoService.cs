
using AutoMapper;
using Core.Common;
using Core.Common.Domain.Model;
using Core.Common.Email;
using Core.Common.Razor;
using Core.Common.SMS;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Contracts.Interface;
using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.ContratoCompraVenta;
using KaphiyQuipu.DTO.Reporte;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaphiyQuipu.Service
{
    public partial class ContratoService : IContratoService
    {
        private readonly IMapper _Mapper;
        private IContratoRepository _IContratoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private IContratoCompraContract _contratoCompraContract;
        private INotaIngresoPlantaContract _notaIngresoPlantaContract;

        private IMessageSender _messageSender;
        private IEmailService _emailService;
        private IViewRender _viewRender;


        public ContratoService(IContratoRepository contratoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository, IEmpresaRepository empresaRepository,
                               IContratoCompraContract contratoCompraContract,
                               INotaIngresoPlantaContract notaIngresoPlantaContract,
                               IMessageSender messageSender,
                               IEmailService emailService,
                               IViewRender viewRender)
        {
            _IContratoRepository = contratoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _contratoCompraContract = contratoCompraContract;
            _notaIngresoPlantaContract = notaIngresoPlantaContract;

            _messageSender = messageSender;
            _emailService = emailService;
            _viewRender = viewRender;
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
                TransactionResult result = _contratoCompraContract.AgregarControlCalidad(x, dt).Result;
                x.HashBC = result.TransactionHash;
                x.FechaCreacion = dt;
            });

            List<RegistrarControlCalidadDTO> listaControles = _Mapper.Map<List<RegistrarControlCalidadDTO>>(request.controles);

            _IContratoRepository.RegistrarControlCalidad(listaControles);
        }

        public void ConfirmarRecepcionCafeTerminado(ConfirmarRecepcionCafeTerminadoContratoRequestDTO request)
        {
            DateTime fechaActual = DateTime.Now;
            TransactionResult result = _contratoCompraContract.AgregarTrazabilidad(request.Contrato, Constants.TrazabilidadBC.CONFIRMAR_RECEPCION_MATERIA_PROCESADA, request.Contrato, fechaActual).Result;
            _IContratoRepository.ConfirmarRecepcionCafeTerminado(request.Id, request.Usuario, fechaActual, result.TransactionHash);
        }

        public async Task<List<(string, List<object>)>> ObtenerDatosTrazabilidad(string nroContrato)
        {
            List<(string, List<object>)> datasets = new List<(string, List<object>)>();
            ReporteContratoDTO reporte = await ObtenerDataReporte(nroContrato);

            datasets.Add(("DS_Contrato", new List<object> { reporte.ContratoCompra }));
            datasets.Add(("DS_Calidad_Cafe_Agricultor", reporte.ListaCalidadCafeAgricultor.ToList<object>()));
            datasets.Add(("DS_Analisis_Cafe", reporte.ListaAnalisisCafe.ToList<object>()));
            datasets.Add(("DS_Resultado_Transformacion", reporte.ListaResultadoTransformacion.ToList<object>()));
            datasets.Add(("DS_Control_Planta_Transformadora", new List<object> { reporte.ControlPlantaTransformadora }));
            datasets.Add(("DS_Control_Planta_Transformadora_Detalle", reporte.ListaControlPlantaTransformadora.ToList<object>()));
            datasets.Add(("DS_Trazabilidad_Contrato", new List<object> { reporte.TrazabilidadContrato }));

            return datasets;
        }

        #region Private methods

        private async Task<ReporteContratoDTO> ObtenerDataReporte(string nroContrato)
        {
            ReporteContratoDTO reporte = new ReporteContratoDTO();

            CorrelativoTrazabilidadContratoDTO trazabilidad = _IContratoRepository.ObtenerCorrelativosTrazabilidadPorNroContrato(nroContrato).FirstOrDefault();

            #region TRAZABILIDAD BLOCKCHAIN CONTRATO

            List<TrazabilidadContratoOutput>  listaTrazabilidad = await _contratoCompraContract.ObtenerTrazabilidad(nroContrato);

            #endregion

            #region Contrato

            ContratoCompraOutputDTO contratoDTO = await _contratoCompraContract.ObtenerContrato(nroContrato);
            reporte.ContratoCompra.FechaSolicitud = (new DateTime(contratoDTO.FechaSolicitud)).ToString("dd/MM/yyyy");
            reporte.ContratoCompra.Producto = contratoDTO.Producto;
            reporte.ContratoCompra.TipoProduccion = contratoDTO.TipoProduccion;
            reporte.ContratoCompra.Calidad = contratoDTO.Calidad;
            reporte.ContratoCompra.GradoPreparacion = contratoDTO.GradoPrepracion;
            reporte.ContratoCompra.Distribuidor = contratoDTO.Distribuidor;
            reporte.ContratoCompra.Cooperativa = "Cooperativa de Servicios Múltiples Aprocassi";
            reporte.ContratoCompra.HashBC = trazabilidad.HashBCContrato;

            #endregion

            #region Control Calidad Cafe Agricultor

            List<AgricultorContratoOutputDTO> listaAgricultor = await _contratoCompraContract.ObtenerAgricultoresPorContrato(nroContrato);
            var listaAgricultoresContrato = _IContratoRepository.ObtenerAgricultoresPorContrato(trazabilidad.IdContrato);
            DateTime fechaCalidad = DateTime.Now;

            foreach (var item in listaAgricultor)
            {
                CalidadCafeAgricultor calidadCafeAgricultor = new CalidadCafeAgricultor();
                calidadCafeAgricultor.Agricultor = item.Nombre;
                calidadCafeAgricultor.Documento = item.NroDocumento;
                calidadCafeAgricultor.Finca = item.Finca;
                calidadCafeAgricultor.Certificacion = item.Certificacion;

                var agricultor = listaAgricultoresContrato.FirstOrDefault(x => x.NumeroDocumento == item.NroDocumento && x.Finca == item.Finca);

                if (agricultor != null)
                {
                    ControlCalidadAgricultorOutputDTO controlCalidad = await _contratoCompraContract.ObtenerControlCalidadPorSocio(agricultor.ContratoSocioFincaId);
                    calidadCafeAgricultor.PorcentajeHumedad = controlCalidad.PorcentajeHumedad;
                    calidadCafeAgricultor.Olores = controlCalidad.Olor;
                    calidadCafeAgricultor.Colores = controlCalidad.Color;
                    calidadCafeAgricultor.Responsable = controlCalidad.Responsable;

                    fechaCalidad = new DateTime(controlCalidad.Fecha);
                }

                reporte.ListaCalidadCafeAgricultor.Add(calidadCafeAgricultor);
            }


            #endregion

            #region Analisis Cafe en la distribuidora
            
            AnalisisFisicoCafeOutputDTO analisisFisico = await _contratoCompraContract.ObtenerAnalisisFisicoCafePorNroGuia(trazabilidad.NroGuiaRecepcion);

            reporte.ListaAnalisisCafe = new List<AnalisisCalidadCafe>
            {
                new AnalisisCalidadCafe("Exportación", analisisFisico.CafeGramos, analisisFisico.CafePorcentaje),
                new AnalisisCalidadCafe("Descarte", analisisFisico.DescarteGramos, analisisFisico.DescartePorcentaje),
                new AnalisisCalidadCafe("Cáscara", analisisFisico.CascaraGramos, analisisFisico.CascaraPorcentaje),
                new AnalisisCalidadCafe("Total", analisisFisico.TotalGramos, analisisFisico.TotalPorcentaje)
            };

            #endregion

            NotaIngresoAlmacenAcopioOutputDTO notaIngresoAlmacenAcopio = await _contratoCompraContract.ObtenerNotaIngresoAlmacenAcopio(trazabilidad.NroNotaIngresoAlmacenAcopio);

            #region Control Calidad Planta Transformadora

            NotaIngresoPlantaCalidadOutputDTO notaIngresoPlanta = await _notaIngresoPlantaContract.ObtenerControlCalidadPorCorrelativo(trazabilidad.NroNotaIngresoPlanta);

            reporte.ControlPlantaTransformadora.Olores = notaIngresoPlanta.Olores;
            reporte.ControlPlantaTransformadora.Colores = notaIngresoPlanta.Colores;
            reporte.ControlPlantaTransformadora.Humedad = notaIngresoPlanta.HumedadPorcentaje + " %";

            reporte.ListaControlPlantaTransformadora = new List<AnalisisCalidadCafe>
            {
                new AnalisisCalidadCafe("Exportación", notaIngresoPlanta.ExportableGramos, notaIngresoPlanta.ExportablePorcentaje),
                new AnalisisCalidadCafe("Descarte", notaIngresoPlanta.DescarteGramos, notaIngresoPlanta.DescartePorcentaje),
                new AnalisisCalidadCafe("Cáscara", notaIngresoPlanta.CascarillaGramos, notaIngresoPlanta.CascarillaPorcentaje),
                new AnalisisCalidadCafe("Total", notaIngresoPlanta.TotalGramos, notaIngresoPlanta.TotalPorcentaje)
            };

            #endregion

            #region Resultado Transformación

            NotaIngresoPlantaResultadoTransfOutputDTO notaIngresoPlantaResultado = await _notaIngresoPlantaContract.ObtenerResultadoTransformacionPorCorrelativo(trazabilidad.NroNotaIngresoPlanta);
            ResultadoTransformacion resultadoTransformacion = new ResultadoTransformacion();
            
            reporte.ListaResultadoTransformacion = new List<ResultadoTransformacion> {
                new ResultadoTransformacion("Café exportación", notaIngresoPlantaResultado.CafeExportacionSacos, notaIngresoPlantaResultado.CafeExportacionKilos),
                new ResultadoTransformacion("Café exportación MC", notaIngresoPlantaResultado.CafeExportacionMCSacos, notaIngresoPlantaResultado.CafeExportacionMCKilos),
                new ResultadoTransformacion("Café segunda", notaIngresoPlantaResultado.CafeSegundaSacos, notaIngresoPlantaResultado.CafeSegundaKilos),
                new ResultadoTransformacion("Café descarte máquina", notaIngresoPlantaResultado.CafeDescarteMaquinaSacos, notaIngresoPlantaResultado.CafeDescarteMaquinaKilos),
                new ResultadoTransformacion("Café descarte de escojo", notaIngresoPlantaResultado.CafeDescarteEscojoSacos, notaIngresoPlantaResultado.CafeDescarteEscojoKilos),
                new ResultadoTransformacion("Café bola", notaIngresoPlantaResultado.CafeBolaSacos, notaIngresoPlantaResultado.CafeBolaKilos),
                new ResultadoTransformacion("Café cisco", notaIngresoPlantaResultado.CafeCiscoSacos, notaIngresoPlantaResultado.CafeCiscoKilos),
                new ResultadoTransformacion("TOTAL EN CAFÉ", notaIngresoPlantaResultado.TotalCafeSacos, notaIngresoPlantaResultado.TotalCafeKgNetos),
                new ResultadoTransformacion("Piedras y otros", string.Empty, notaIngresoPlantaResultado.PiedraOtrosKgNetos),
                new ResultadoTransformacion("Cascara y otros", string.Empty, notaIngresoPlantaResultado.CascaraOtrosKgNetos)
            };

            reporte.TrazabilidadContrato.FechaControlCalidad = fechaCalidad.ToString("dd/MM/yyyy");
            reporte.TrazabilidadContrato.FechaAnalisisCafe = (new DateTime(analisisFisico.Fecha)).ToString("dd/MM/yyyy");
            reporte.TrazabilidadContrato.FechaIngresoPlantaAcopio = (new DateTime(notaIngresoAlmacenAcopio.Fecha)).ToString("dd/MM/yyyy");
            reporte.TrazabilidadContrato.FechaEnvioPlantaTransformadora = (new DateTime(listaTrazabilidad.FirstOrDefault(x => x.Proceso == Constants.TrazabilidadBC.ENVIO_PLANTA_TRANSFORMADORA).fecha)).ToString("dd/MM/yyyy");
            reporte.TrazabilidadContrato.FechaRecepcionPlantaTransformadora = (new DateTime(listaTrazabilidad.FirstOrDefault(x => x.Proceso == Constants.TrazabilidadBC.RECEPCION_MATERIA_PRIMA_PLANTA).fecha)).ToString("dd/MM/yyyy");

            reporte.TrazabilidadContrato.FechaControlCalidadPlantaTransformadora = (new DateTime(notaIngresoPlanta.FechaRegistro)).ToString("dd/MM/yyyy");
            reporte.TrazabilidadContrato.FechaIngresoTransformacionPlanta = (new DateTime(listaTrazabilidad.FirstOrDefault(x => x.Proceso == Constants.TrazabilidadBC.INICIAR_TRANSFORMACION).fecha)).ToString("dd/MM/yyyy");
            reporte.TrazabilidadContrato.FechaResultadoTransformacion = (new DateTime(notaIngresoPlantaResultado.FechaRegistro)).ToString("dd/MM/yyyy");
            reporte.TrazabilidadContrato.FechaTransformacionMateriaPrima = reporte.TrazabilidadContrato.FechaResultadoTransformacion;
            reporte.TrazabilidadContrato.FechaEnvioACooperativa = (new DateTime(listaTrazabilidad.FirstOrDefault(x => x.Proceso == Constants.TrazabilidadBC.ENVIO_CAFE_HACIA_COOPERATIVA).fecha)).ToString("dd/MM/yyyy");
            reporte.TrazabilidadContrato.FechaRecepcionCooperativa = (new DateTime(listaTrazabilidad.FirstOrDefault(x => x.Proceso == Constants.TrazabilidadBC.RECEPCION_CAFE_PROCESADO_POR_COOPERATIVA).fecha)).ToString("dd/MM/yyyy");
            reporte.TrazabilidadContrato.FechaEnvioADistribuidora = (new DateTime(listaTrazabilidad.FirstOrDefault(x => x.Proceso == Constants.TrazabilidadBC.ENVIO_CAFE_HACIA_DISTRIBUIDORA).fecha)).ToString("dd/MM/yyyy");

            #endregion

            return reporte;
        }

        public void AsignarTransportistas(AsignarTransportistasRequestDTO request)
        {
            if (request.transportistas.Count > 0)
            {
                request.Fecha = DateTime.Now;
                request.transportistas.ForEach(x => x.Fecha = request.Fecha);

                _IContratoRepository.AsignarTransportistas(request.transportistas);
            }
        }

        #endregion
    }
}
