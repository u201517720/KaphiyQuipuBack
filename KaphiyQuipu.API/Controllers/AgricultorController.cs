using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracion.Deuda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgricultorController : ControllerBase
    {
        private Core.Common.Logger.ILog _log;
        private IAgricultorService _agricultorService;

        public AgricultorController(Core.Common.Logger.ILog log, IAgricultorService agricultorService)
        {
            _log = log;
            _agricultorService = agricultorService;
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar([FromBody] ConsultaAgricultorRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaAgricultorResponseDTO response = new ConsultaAgricultorResponseDTO();
            try
            {
                response.Result.Data = _agricultorService.Consultar(request);
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

        [Route("MateriaPrimaSolicitada")]
        [HttpPost]
        public IActionResult ConsultarMateriaPrimaSolicitada([FromBody] ConsultaMateriaPrimaSolicitadaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultaMateriaPrimaSolicitadaResponseDTO response = new ConsultaMateriaPrimaSolicitadaResponseDTO();
            try
            {
                response.Result.Data = _agricultorService.ConsultarMateriaPrimaSolicitada(request);
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

        [Route("DetalleMateriaPrimaSolicitada")]
        [HttpPost]
        public IActionResult ConsultarDetalleMateriaPrimaSolicitada([FromBody] ConsultarDetalleMateriaPrimaSolicitadaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            ConsultarDetalleMateriaPrimaSolicitadaResponseDTO response = new ConsultarDetalleMateriaPrimaSolicitadaResponseDTO();
            try
            {
                response.Result.Data = _agricultorService.ConsultarDetalleMateriaPrimaSolicitada(request);
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
