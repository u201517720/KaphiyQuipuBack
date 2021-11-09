using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace KaphiyQuipu.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiaRecepcionMateriaPrimaController : ControllerBase
    {
        private Core.Common.Logger.ILog _log;
        private IGuiaRecepionMateriaPrimaService _guiaRecepionMateriaPrimaService;

        public GuiaRecepcionMateriaPrimaController(Core.Common.Logger.ILog log, IGuiaRecepionMateriaPrimaService guiaRecepionMateriaPrimaService)
        {
            _log = log;
            _guiaRecepionMateriaPrimaService = guiaRecepionMateriaPrimaService;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("GuiaRecepcionMateriaPrima Service. version: 1.20.01.03");
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultarGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultarGuiaRecepcionMateriaPrimaResponseDTO response = new ConsultarGuiaRecepcionMateriaPrimaResponseDTO();
            try
            {
                response.Result.Data = _guiaRecepionMateriaPrimaService.Consultar(request);
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

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar(RegistrarActualizarGuiaRecepcionRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarGuiaRecepcionResponseDTO response = new RegistrarActualizarGuiaRecepcionResponseDTO();

            try
            {
                response.Result.Data = _guiaRecepionMateriaPrimaService.Registrar(request);
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
        public IActionResult ConsultarPorId([FromBody] ConsultarPorIdGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultarPorIdGuiaRecepcionMateriaPrimaResponseDTO response = new ConsultarPorIdGuiaRecepcionMateriaPrimaResponseDTO();
            try
            {
                response.Result.Data = _guiaRecepionMateriaPrimaService.ConsultarPorId(request);
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
