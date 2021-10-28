using Core.Common.Domain.Model;
using Core.Common.Logger;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaphiyQuipu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudCompraController : ControllerBase
    {
        private ILog _log;
        private ISolicitudCompraService _solicitudCompraService;

        public SolicitudCompraController(ILog log, ISolicitudCompraService solicitudCompraService)
        {
            _log = log;
            _solicitudCompraService = solicitudCompraService;
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
    }
}
