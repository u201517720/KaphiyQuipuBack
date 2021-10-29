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
    public partial class LiquidacionProcesoPlantaService : ILiquidacionProcesoPlantaService
    {
        private readonly IMapper _Mapper;
        private ILiquidacionProcesoPlantaRepository _ILiquidacionProcesoPlantaRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IMaestroRepository _IMaestroRepository;


        public LiquidacionProcesoPlantaService(ILiquidacionProcesoPlantaRepository LiquidacionProcesoPlantaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository)
        {
            _ILiquidacionProcesoPlantaRepository = LiquidacionProcesoPlantaRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _IMaestroRepository = maestroRepository;
        }

        public List<ConsultaLiquidacionProcesoPlantaBE> ConsultarLiquidacionProcesoPlanta(ConsultaLiquidacionProcesoPlantaRequestDTO request)
        {
            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });

            var list = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlanta(request);
            return list.ToList();
        }

        public int RegistrarLiquidacionProcesoPlanta(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request)
        {
            LiquidacionProcesoPlanta liquidacionProcesoPlanta = _Mapper.Map<LiquidacionProcesoPlanta>(request);
            liquidacionProcesoPlanta.FechaRegistro = DateTime.Now;
            liquidacionProcesoPlanta.UsuarioRegistro = request.Usuario;
            liquidacionProcesoPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.LiquidacionProcesoPlanta);


            int LiquidacionProcesoPlantaId = _ILiquidacionProcesoPlantaRepository.Insertar(liquidacionProcesoPlanta);

            foreach (LiquidacionProcesoPlantaDetalle detalle in request.LiquidacionProcesoPlantaDetalle)
            {
                detalle.LiquidacionProcesoPlantaId = LiquidacionProcesoPlantaId;
                _ILiquidacionProcesoPlantaRepository.InsertarLiquidacionProcesoPlantaDetalle(detalle);
            }

            foreach (LiquidacionProcesoPlantaResultado detalle in request.LiquidacionProcesoPlantaResultado)
            {
                detalle.LiquidacionProcesoPlantaId = LiquidacionProcesoPlantaId;
                _ILiquidacionProcesoPlantaRepository.InsertarLiquidacionProcesoPlantaResultado(detalle);
            }
            return LiquidacionProcesoPlantaId;
        }

        public int ActualizarLiquidacionProcesoPlanta(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request)
        {
            LiquidacionProcesoPlanta liquidacionProcesoPlanta = _Mapper.Map<LiquidacionProcesoPlanta>(request);



            liquidacionProcesoPlanta.FechaUltimaActualizacion = DateTime.Now;
            liquidacionProcesoPlanta.UsuarioUltimaActualizacion = request.Usuario;
            int affected = _ILiquidacionProcesoPlantaRepository.Actualizar(liquidacionProcesoPlanta);

            _ILiquidacionProcesoPlantaRepository.EliminarLiquidacionProcesoPlantaDetalle(liquidacionProcesoPlanta.LiquidacionProcesoPlantaId);


            foreach (LiquidacionProcesoPlantaDetalle detalle in request.LiquidacionProcesoPlantaDetalle)
            {
                detalle.LiquidacionProcesoPlantaId = request.LiquidacionProcesoPlantaId;
                _ILiquidacionProcesoPlantaRepository.InsertarLiquidacionProcesoPlantaDetalle(detalle);
            }

            _ILiquidacionProcesoPlantaRepository.EliminarLiquidacionProcesoPlantaResultado(liquidacionProcesoPlanta.LiquidacionProcesoPlantaId);


            foreach (LiquidacionProcesoPlantaResultado detalle in request.LiquidacionProcesoPlantaResultado)
            {
                detalle.LiquidacionProcesoPlantaId = request.LiquidacionProcesoPlantaId;
                _ILiquidacionProcesoPlantaRepository.InsertarLiquidacionProcesoPlantaResultado(detalle);
            }

            return affected;
        }

        public ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaPorId(ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request)
        {
            ConsultaLiquidacionProcesoPlantaPorIdBE consultaLiquidacionProcesoPlantaPorIdBE = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaPorId(request.LiquidacionProcesoPlantaId);

            if (consultaLiquidacionProcesoPlantaPorIdBE != null)
            {
                consultaLiquidacionProcesoPlantaPorIdBE.Detalle = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaDetallePorId(request.LiquidacionProcesoPlantaId).ToList();
                consultaLiquidacionProcesoPlantaPorIdBE.Resultado = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaResultadoPorId(request.LiquidacionProcesoPlantaId).ToList();


                List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(consultaLiquidacionProcesoPlantaPorIdBE.EmpresaId, String.Empty).ToList();


                string[] certificacionesIds = consultaLiquidacionProcesoPlantaPorIdBE.TipoCertificacionId.Split('|');

                string certificacionLabel = string.Empty;


                if (certificacionesIds.Length > 0)
                {

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

                consultaLiquidacionProcesoPlantaPorIdBE.TipoCertificacion = certificacionLabel;
            }

            return consultaLiquidacionProcesoPlantaPorIdBE;
        }

        //public ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaDetallePorId(ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request)
        //{
        //    ConsultaLiquidacionProcesoPlantaPorIdBE consultaLiquidacionProcesoPlantaPorIdBE = new ConsultaLiquidacionProcesoPlantaPorIdBE();


        //     consultaLiquidacionProcesoPlantaPorIdBE.detalle = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaDetallePorId(request.LiquidacionProcesoPlantaId).ToList();


        //    return consultaLiquidacionProcesoPlantaPorIdBE;
        //}

        ////public int AnularLiquidacionProcesoPlanta(AnularLiquidacionProcesoPlantaRequestDTO request)
        ////{
        ////    int result = 0;
        ////    if(request.LiquidacionProcesoPlantaId > 0)
        ////    {
        ////        result = _ILiquidacionProcesoPlantaRepository.Anular(request.LiquidacionProcesoPlantaId, DateTime.Now, request.Usuario, LiquidacionProcesoPlantaEstados.Anulado);
        ////    }
        ////    return result;
        ////}

        ////public ConsultarImpresionLiquidacionProcesoPlantaResponseDTO ConsultarImpresionLiquidacionProcesoPlanta(ConsultarImpresionLiquidacionProcesoPlantaRequestDTO request)
        ////{
        ////    ConsultarImpresionLiquidacionProcesoPlantaResponseDTO response = new ConsultarImpresionLiquidacionProcesoPlantaResponseDTO();
        ////    response.listLiquidacionProcesoPlanta = _ILiquidacionProcesoPlantaRepository.ConsultarImpresionLiquidacionProcesoPlanta(request.LiquidacionProcesoPlantaId);
        ////    response.listDetalleLiquidacionProcesoPlanta = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaDetallePorId(request.LiquidacionProcesoPlantaId);
        ////    return response;
        ////}

        //private String getRutaFisica(string pathFile)
        //{
        //    return _fileServerSettings.Value.RutaPrincipal + pathFile;
        //}

        //public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        //{
        //    try
        //    {
        //        string rutaReal = Path.Combine(getRutaFisica(request.PathFile));

        //        if (File.Exists(rutaReal))
        //        {
        //            byte[] archivoBytes = File.ReadAllBytes(rutaReal);
        //            return new ResponseDescargarArchivoDTO()
        //            {
        //                archivoBytes = archivoBytes,
        //                errores = new Dictionary<string, string>(),
        //                ficheroVisual = request.ArchivoVisual
        //            };
        //        }
        //        else
        //        {
        //            var resp = new ResponseDescargarArchivoDTO()
        //            {
        //                archivoBytes = null,
        //                errores = new Dictionary<string, string>(),
        //                ficheroVisual = ""
        //            };
        //            resp.errores.Add("Error", "El Archivo solicitado no existe");
        //            return resp;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
