using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaIngresoAcopioController : ControllerBase
    {
        private Core.Common.Logger.ILog _log;
        private INotaIngresoAcopioService _notaIngresoAcopioService;

        public NotaIngresoAcopioController(Core.Common.Logger.ILog log, INotaIngresoAcopioService notaIngresoAcopioService)
        {
            _log = log;
            _notaIngresoAcopioService = notaIngresoAcopioService;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("NotaIngresoPlanta Service. version: 1.20.01.03");
        }

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar(RegistrarNotaIngresoAcopioRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarNotaIngresoAcopioResponseDTO response = new RegistrarNotaIngresoAcopioResponseDTO();
            try
            {
                response.Result.Data = _notaIngresoAcopioService.Registrar(request);
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

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaNotaIngresoAcopioRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaNotaIngresoAcopioResponseDTO response = new ConsultaNotaIngresoAcopioResponseDTO();
            try
            {
                response.Result.Data = _notaIngresoAcopioService.Consultar(request);
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

        [Route("ConsultarPorId")]
        [HttpPost]
        public IActionResult ConsultarPorId([FromBody] ConsultaPorIdNotaIngresoAcopioRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaPorIdNotaIngresoAcopioResponseDTO response = new ConsultaPorIdNotaIngresoAcopioResponseDTO();
            try
            {
                response.Result.Data = _notaIngresoAcopioService.ConsultarPorId(request);
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

        [Route("UbicarAlmacen")]
        [HttpPost]
        public IActionResult UbicarMateriaPrimaAlmacen(UbicarMateriaPrimaAlmacenRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            UbicarMateriaPrimaAlmacenResponseDTO response = new UbicarMateriaPrimaAlmacenResponseDTO();

            try
            {
                _notaIngresoAcopioService.UbicarMateriaPrimaAlmacen(request);
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

        [Route("ConfirmarEtiquetado")]
        [HttpPost]
        public IActionResult ConfirmarEtiquetado(ConfirmarEtiquetadoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConfirmarEtiquetadoResponseDTO response = new ConfirmarEtiquetadoResponseDTO();

            try
            {
                _notaIngresoAcopioService.ConfirmarEtiquetado(request);
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
    }
}
