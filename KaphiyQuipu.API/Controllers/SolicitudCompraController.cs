using KaphiyQuipu.DTO.SolicitudCompra;
using KaphiyQuipu.Interface.Service;
using Microsoft.AspNetCore.Http;
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
        private readonly ISolicitudCompraService _solicitudCompraService;
        public SolicitudCompraController(ISolicitudCompraService solicitudCompraService)
        {
            _solicitudCompraService = solicitudCompraService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] SolicitudCompraDTO request)
        {
            return Ok(await _solicitudCompraService.Registrar(request));
        }

        [Route("{correlativo}")]
        [HttpGet]
        public async Task<IActionResult> Obtener(string correlativo)
        {
            return Ok(await _solicitudCompraService.ObtenerSolicitud(correlativo));
        }
    }
}
