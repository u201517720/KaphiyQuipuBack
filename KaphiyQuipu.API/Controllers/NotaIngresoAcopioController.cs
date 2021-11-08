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
    }
}
