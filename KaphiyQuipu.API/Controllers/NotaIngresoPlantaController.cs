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
    public class NotaIngresoPlantaController : ControllerBase
    {
        private Core.Common.Logger.ILog _log;
        INotaIngresoPlantaService _INotaIngresoPlantaService;

        public NotaIngresoPlantaController(Core.Common.Logger.ILog log, INotaIngresoPlantaService notaIngresoPlantaService)
        {
            _log = log;
            _INotaIngresoPlantaService = notaIngresoPlantaService;
        }

        [Route("Consultar")]
        [HttpPost]
        public IActionResult Consultar(ConsultarNotaIngresoPlantaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            GeneralResponse response = new GeneralResponse();
            try
            {
                response.Result.Data = _INotaIngresoPlantaService.Consultar(request);
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
