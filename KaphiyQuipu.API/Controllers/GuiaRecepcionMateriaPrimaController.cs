using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiaRecepcionMateriaPrimaController : ControllerBase
    {
        private Core.Common.Logger.ILog _log;

        public GuiaRecepcionMateriaPrimaController(Core.Common.Logger.ILog log)
        {
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("GuiaRecepcionMateriaPrima Service. version: 1.20.01.03");
        }

    

        
    }
}
