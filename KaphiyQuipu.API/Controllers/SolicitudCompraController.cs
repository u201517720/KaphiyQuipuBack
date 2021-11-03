﻿using Core.Common.Domain.Model;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KaphiyQuipu.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudCompraController : ControllerBase
    {
        private Core.Common.Logger.ILog _log;
        private ISolicitudCompraService _solicitudCompraService;
        private IContratoCompraContract _contratoCompraContract;

        public SolicitudCompraController(ILog log, ISolicitudCompraService solicitudCompraService, IContratoCompraContract contratoCompraContract)
        {
            _log = log;
            _solicitudCompraService = solicitudCompraService;
            _contratoCompraContract = contratoCompraContract;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Authenticate Service. version: 1.0.0.0");
        }

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar([FromBody] RegistrarActualizarSolicitudCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            RegistrarActualizarSolicitudCompraResponseDTO response = new RegistrarActualizarSolicitudCompraResponseDTO();
            try
            {
                response.Result.Data = _solicitudCompraService.Registrar(request);
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

            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaSolicitudCompraRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaSolicitudCompraResponseDTO response = new ConsultaSolicitudCompraResponseDTO();
            try
            {
                response.Result.Data = _solicitudCompraService.Consultar(request);
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

            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("ConsultarPorId")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] ConsultaSolicitudCompraPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaSolicitudCompraPorIdResponseDTO response = new ConsultaSolicitudCompraPorIdResponseDTO();
            try
            {
                response.Result.Data = _solicitudCompraService.ConsultarPorId(request);
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

            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        //[Route("")]
        //[HttpPost]
        //public async Task<IActionResult> Registrar([FromBody] SolicitudCompraDTO request)
        //{
        //    return Ok(await _solicitudCompraService.Registrar(request));
        //}

        //[Route("{correlativo}")]
        //[HttpGet]
        //public async Task<IActionResult> Obtener(string correlativo)
        //{
        //    return Ok(await _solicitudCompraService.ObtenerSolicitud(correlativo));
        //}

        [Route("Contrato")]
        [HttpPost]
        public async Task<IActionResult> RegistrarContrato([FromBody] ContratoCompraDTO request)
        {
            return Ok(await _contratoCompraContract.RegistrarContrato(request));
        }

        [Route("Contrato/{nroContrato}")]
        [HttpGet]
        public async Task<IActionResult> ObtenerContrato(string nroContrato)
        {
            return Ok(await _contratoCompraContract.ObtenerContrato(nroContrato));
        }

        [Route("Agricultores")]
        [HttpPost]
        public async Task<IActionResult> AgregarAgricultor([FromBody] AgricultorContratoDTO request)
        {
            return Ok(await _contratoCompraContract.AgregarAgricultor(request));
        }


        [Route("Contrato/{nroContrato}/agricultores")]
        [HttpGet]
        public async Task<IActionResult> ObtenerAgricultores(string nroContrato)
        {
            return Ok(await _contratoCompraContract.ObtenerAgricultoresPorContrato(nroContrato));
    }
}
