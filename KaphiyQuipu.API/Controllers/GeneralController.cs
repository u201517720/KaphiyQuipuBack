using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaphiyQuipu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private Core.Common.Logger.ILog _log;
        private IGeneralService _generalService;

        public GeneralController(IGeneralService generalService, Core.Common.Logger.ILog log)
        {
            _log = log;
            _generalService = generalService;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("General Service. version: 1.1.1.0");
        }

        [Route("ConsultPaymentDocument")]
        [HttpPost]
        public IActionResult ConsultarDocumentoPago([FromBody] ConsultarDocumentoPagoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            GeneralResponse response = new GeneralResponse();

            try
            {
                response.Result.Data = _generalService.ConsultarDocumentoPago(request);
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
