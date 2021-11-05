﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Core.Common.Domain.Model;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private ILoteService _loteService;
        private Core.Common.Logger.ILog _log;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConverter _converter;


        public LoteController(ILoteService loteService, Core.Common.Logger.ILog log, IWebHostEnvironment webHostEnvironment, IConverter converter)
        {
            _loteService = loteService;
            _log = log;
            _webHostEnvironment = webHostEnvironment;
            _converter = converter;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Lote Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Generar")]
        [HttpPost]
        public IActionResult Generar([FromBody] GenerarLoteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            GenerarLoteResponseDTO response = new GenerarLoteResponseDTO();
            try
            {
                response.Result.Data = _loteService.GenerarLote(request);

                response.Result.Success = true;

            }
            catch (ResultException ex)
            {
                response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
            }
            catch (Exception ex)
            {
                response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
                _log.RegistrarEvento(ex, guid.ToString());
            }

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaLoteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaLoteResponseDTO response = new ConsultaLoteResponseDTO();
            try
            {
                response.Result.Data = _loteService.ConsultarLote(request);

                response.Result.Success = true;

            }
            catch (ResultException ex)
            {
                response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
            }
            catch (Exception ex)
            {
                response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
                _log.RegistrarEvento(ex, guid.ToString());
            }

            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }


        [Route("Anular")]
        [HttpPost]
        public IActionResult Anular([FromBody] AnularLoteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            AnularLoteResponseDTO response = new AnularLoteResponseDTO();
            try
            {
                response.Result.Data = _loteService.AnularLote(request);

                response.Result.Success = true;

            }
            catch (ResultException ex)
            {
                response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
            }
            catch (Exception ex)
            {
                response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
                _log.RegistrarEvento(ex, guid.ToString());
            }

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("Actualizar")]
        [HttpPost]
        public IActionResult Actualizar([FromBody] ActualizarLoteRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ActualizarLoteResponseDTO response = new ActualizarLoteResponseDTO();
            try
            {
                response.Result.Data = _loteService.ActualizarLote(request);

                response.Result.Success = true;

            }
            catch (ResultException ex)
            {
                response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
            }
            catch (Exception ex)
            {
                response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
                _log.RegistrarEvento(ex, guid.ToString());
            }

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("ConsultarDetallePorId")]
        [HttpPost]
        public IActionResult ConsultarDetallePorId([FromBody] ConsultaLoteDetallePorLoteIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaLoteDetallePorLoteIdResponseDTO response = new ConsultaLoteDetallePorLoteIdResponseDTO();
            try
            {
                //var resultado = _loteService.ConsultarLotePorId(request);
                response.Result.Data = _loteService.ConsultarLotePorId(request);
                //response.LoteId = resultado.LoteId;
                //response.Numero = resultado.Numero;
                //response.EmpresaId = resultado.EmpresaId;
                //response.RazonSocial = resultado.RazonSocial;
                //response.Ruc = resultado.Ruc;
                //response.Direccion = resultado.Direccion;
                //response.Logo = resultado.Logo;
                //response.DepartamentoId = resultado.DepartamentoId;
                //response.Departamento = resultado.Departamento;
                //response.ProvinciaId = resultado.ProvinciaId;
                //response.Provincia = resultado.Provincia;
                //response.DistritoId = resultado.DistritoId;
                //response.Distrito = resultado.Distrito;
                //response.EstadoId = resultado.EstadoId;
                //response.Estado = resultado.Estado;
                //response.AlmacenId = resultado.AlmacenId;
                //response.Almacen = resultado.Almacen;
                //response.UnidadMedidaId = resultado.UnidadMedidaId;
                //response.UnidadMedida = resultado.UnidadMedida;

                //response.ProductoId = resultado.ProductoId;
                //response.Producto = resultado.Producto;

                //response.SubProductoId = resultado.SubProductoId;
                //response.SubProducto = resultado.SubProducto;


                //response.TipoCertificacionId = resultado.TipoCertificacionId;
                //response.Certificacion = resultado.TipoCertificacion;

                //response.Cantidad = resultado.Cantidad;
                //response.Total
                //
                //NetosPesado = resultado.TotalKilosNetosPesado;
                //response.TotalKilosBrutosPesado = resultado.TotalKilosBrutosPesado;
                //response.PromedioRendimientoPorcentaje = resultado.PromedioRendimientoPorcentaje;
                //response.PromedioRendimientoPorcentaje = resultado.PromedioRendimientoPorcentaje;
                //response.PromedioHumedadPorcentaje = resultado.PromedioHumedadPorcentaje;
                //response.PromedioTotalAnalisisSensorial = resultado.PromedioTotalAnalisisSensorial;

                //response.FechaRegistro = resultado.FechaRegistro;
                //response.UsuarioRegistro = resultado.UsuarioRegistro;
                //response.FechaUltimaActualizacion = resultado.FechaUltimaActualizacion;
                //response.UsuarioUltimaActualizacion = resultado.UsuarioUltimaActualizacion;
                //response.Activo = resultado.Activo;
                response.Result.Success = true;

            }
            catch (ResultException ex)
            {
                response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
            }
            catch (Exception ex)
            {
                response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
                _log.RegistrarEvento(ex, guid.ToString());
            }

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("ConsultarLoteDetallePorLoteId")]
        [HttpPost]
        public IActionResult ConsultarLoteDetalle([FromBody] ConsultaLoteDetalleBusquedaPorLoteIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaLoteDetalleBusquedaPorLoteIdResponseDTO response = new ConsultaLoteDetalleBusquedaPorLoteIdResponseDTO();
            try
            {
                response.Result.Data = _loteService.ConsultaLoteDetalleBusquedaPorLoteId(request);

                response.Result.Success = true;

            }
            catch (ResultException ex)
            {
                response.Result = new Result() { Success = true, ErrCode = ex.Result.ErrCode, Message = ex.Result.Message };
            }
            catch (Exception ex)
            {
                response.Result = new Result() { Success = false, Message = "Ocurrio un problema en el servicio, intentelo nuevamente." };
                _log.RegistrarEvento(ex, guid.ToString());
            }

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }


    }
}
