using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaphiyQuipu.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiaRemisionPlantaController : ControllerBase
    {
        Core.Common.Logger.ILog _log;
        IGuiaRemisionPlantaService _IGuiaRemisionPlantaService;

        public GuiaRemisionPlantaController(Core.Common.Logger.ILog log, IGuiaRemisionPlantaService guiaRemisionPlantaService)
        {
            _log = log;
            _IGuiaRemisionPlantaService = guiaRemisionPlantaService;
        }

        [Route("Registrar")]
        [HttpPost]
        public IActionResult Registrar(GenerarGuiaRemisionPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            GeneralResponse response = new GeneralResponse();
            try
            {
                response.Result.Data = _IGuiaRemisionPlantaService.Registrar(request);
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
