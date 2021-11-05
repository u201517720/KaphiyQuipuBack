using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KaphiyQuipu.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private IContratoService _contratoService;

        private Core.Common.Logger.ILog _log;
        public ContratoController(IContratoService contratoService, Core.Common.Logger.ILog log)
        {
            _contratoService = contratoService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Contrato Service. version: 1.20.01.03");
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaContratoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaContratoResponseDTO response = new ConsultaContratoResponseDTO();
            try
            {
                response.Result.Data = _contratoService.Consultar(request);
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
        public IActionResult ConsultarPorId([FromBody] ConsultaContratoPorIdRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaContratoPorIdResponseDTO response = new ConsultaContratoPorIdResponseDTO();
            try
            {
                response.Result.Data = _contratoService.ConsultarPorId(request);
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
        public IActionResult Registrar(RegistrarActualizarContratoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarActualizarContratoResponseDTO response = new RegistrarActualizarContratoResponseDTO();
            try
            {
                response.Result.Data = _contratoService.Registrar(request);
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

        [Route("Confirmar")]
        [HttpPost]
        public async Task<IActionResult> Confirmar(ContratoCompraDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            TransactionResponse<string> response = new TransactionResponse<string>();
            try
            {
                response = await _contratoService.Confirmar(request);
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

        [Route("RegistrarAgricultores")]
        [HttpPost]
        public IActionResult AsociarAgricultoresContrato(AsociarAgricultoresContratoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            AsociarAgricultoresContratoResponseDTO response = new AsociarAgricultoresContratoResponseDTO();

            try
            {
                if (request.agricultores.Count > 0)
                {
                    _contratoService.AsociarAgricultoresContrato(request);
                    response.Result.Success = true;
                }
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

        [Route("Agricultores")]
        [HttpPost]
        public IActionResult ObtenerAgricultoresPorContrato([FromBody] ObtenerAgricultoresPorContratoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ObtenerAgricultoresPorContratoResponseDTO response = new ObtenerAgricultoresPorContratoResponseDTO();
            try
            {
                response.Result.Data = _contratoService.ObtenerAgricultoresPorContrato(request);
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
