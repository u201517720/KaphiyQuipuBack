﻿using AutoMapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using KaphiyQuipu.Service.Adjunto;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public partial class OrdenProcesoService : IOrdenProcesoService
    {
        private readonly IMapper _Mapper;
        private IOrdenProcesoRepository _IOrdenProcesoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IMaestroRepository _IMaestroRepository;

        public OrdenProcesoService(IOrdenProcesoRepository ordenProcesoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository)
        {
            _IOrdenProcesoRepository = ordenProcesoRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _IMaestroRepository = maestroRepository;
        }

        public List<ConsultaOrdenProcesoBE> ConsultarOrdenProceso(ConsultaOrdenProcesoRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFinal == null || request.FechaFinal == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFinal - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IOrdenProcesoRepository.ConsultarOrdenProceso(request);
            return list.ToList();
        }

        public int RegistrarOrdenProceso(RegistrarActualizarOrdenProcesoRequestDTO request, IFormFile file)
        {
            OrdenProceso ordenProceso = _Mapper.Map<OrdenProceso>(request);
            ordenProceso.FechaRegistro = DateTime.Now;
            ordenProceso.UsuarioRegistro = request.UsuarioRegistro;
            ordenProceso.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.OrdenProceso);

            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
            byte[] fileBytes = null;

            if (file != null)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                    }

                    ordenProceso.NombreArchivo = file.FileName;
                    //Adjuntos
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.OrdenProceso
                    });
                    ordenProceso.PathArchivo = _fileServerSettings.Value.OrdenProceso + "\\" + response.ficheroReal;
                }
            }

            int ordenProcesoId = _IOrdenProcesoRepository.Insertar(ordenProceso);

            foreach (OrdenProcesoDetalle detalle in request.OrdenProcesoDetalle)
            {
                detalle.OrdenProcesoId = ordenProcesoId;
                _IOrdenProcesoRepository.InsertarProcesoDetalle(detalle);
            }
            return ordenProcesoId;
        }

        public int ActualizarOrdenProceso(RegistrarActualizarOrdenProcesoRequestDTO request, IFormFile file)
        {
            OrdenProceso ordenProceso = _Mapper.Map<OrdenProceso>(request);

            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
            byte[] fileBytes = null;
            if (file != null)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                    }

                    ordenProceso.NombreArchivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                    {
                        filtros = new AdjuntarArchivosDTO()
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.OrdenProceso

                    });

                    ordenProceso.PathArchivo = _fileServerSettings.Value.OrdenProceso + "\\" + response.ficheroReal;
                }
            }

            ordenProceso.FechaUltimaActualizacion = DateTime.Now;
            ordenProceso.UsuarioUltimaActualizacion = request.UsuarioRegistro;
            int affected = _IOrdenProcesoRepository.Actualizar(ordenProceso);

            _IOrdenProcesoRepository.EliminarProcesoDetalle(ordenProceso.OrdenProcesoId);

            foreach (OrdenProcesoDetalle detalle in request.OrdenProcesoDetalle)
            {
                detalle.OrdenProcesoId = ordenProceso.OrdenProcesoId;
                _IOrdenProcesoRepository.InsertarProcesoDetalle(detalle);
            }

            return affected;
        }

        public ConsultaOrdenProcesoPorIdBE ConsultarOrdenProcesoPorId(ConsultaOrdenProcesoPorIdRequestDTO request)
        {
            ConsultaOrdenProcesoPorIdBE consultaOrdenProcesoPorIdBE = _IOrdenProcesoRepository.ConsultarOrdenProcesoPorId(request.OrdenProcesoId);

            string[] certificacionesIds = consultaOrdenProcesoPorIdBE.TipoCertificacionId.Split('|');

            string certificacionLabel = string.Empty;

            if (certificacionesIds.Length > 0)
            {
                List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(consultaOrdenProcesoPorIdBE.EmpresaId, String.Empty).ToList();

                List<ConsultaDetalleTablaBE> certificaciones = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacion")).ToList();

                foreach (string certificacionId in certificacionesIds)
                {

                    ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();

                    if (certificacion != null)
                    {
                        certificacionLabel = certificacionLabel + certificacion.Label + " ";
                    }
                }
            }

            consultaOrdenProcesoPorIdBE.Certificacion = certificacionLabel;
            consultaOrdenProcesoPorIdBE.detalle = _IOrdenProcesoRepository.ConsultarOrdenProcesoDetallePorId(request.OrdenProcesoId).ToList();

            return consultaOrdenProcesoPorIdBE;
        }

        public int AnularOrdenProceso(AnularOrdenProcesoRequestDTO request)
        {
            int result = 0;
            if (request.OrdenProcesoId > 0)
            {
                result = _IOrdenProcesoRepository.Anular(request.OrdenProcesoId, DateTime.Now, request.Usuario, OrdenProcesoEstados.Anulado);
            }
            return result;
        }

        public ConsultarImpresionOrdenProcesoResponseDTO ConsultarImpresionOrdenProceso(ConsultarImpresionOrdenProcesoRequestDTO request)
        {
            ConsultarImpresionOrdenProcesoResponseDTO response = new ConsultarImpresionOrdenProcesoResponseDTO();
            response.listOrdenProceso = _IOrdenProcesoRepository.ConsultarImpresionOrdenProceso(request.OrdenProcesoId);
            response.listDetalleOrdenProceso = _IOrdenProcesoRepository.ConsultarOrdenProcesoDetallePorId(request.OrdenProcesoId);
            return response;
        }

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                string rutaReal = Path.Combine(getRutaFisica(request.PathFile));

                if (File.Exists(rutaReal))
                {
                    byte[] archivoBytes = File.ReadAllBytes(rutaReal);
                    return new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = archivoBytes,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = request.ArchivoVisual
                    };
                }
                else
                {
                    var resp = new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = null,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = ""
                    };
                    resp.errores.Add("Error", "El Archivo solicitado no existe");
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
