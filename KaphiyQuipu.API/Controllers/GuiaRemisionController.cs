﻿using Core.Common.Domain.Model;
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
    public class GuiaRemisionController : ControllerBase
    {
        private Core.Common.Logger.ILog _log;
        IGuiaRemisionAcopioService _IGuiaRemisionAcopioService;

        public GuiaRemisionController(Core.Common.Logger.ILog log, IGuiaRemisionAcopioService guiaRemisionAcopioService)
        {
            _IGuiaRemisionAcopioService = guiaRemisionAcopioService;
            _log = log;
        }

        [Route("Registrar")]
        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarGuiaRemisionAcopioRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            RegistrarGuiaRemisionAcopioResponseDTO response = new RegistrarGuiaRemisionAcopioResponseDTO();
            try
            {
                response.Result.Data = await _IGuiaRemisionAcopioService.Registrar(request);
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