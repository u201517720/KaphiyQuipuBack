﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Integracion.Deuda.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        private IMaestroService _maestroService;
        private Core.Common.Logger.ILog _log;
        public MaestroController(IMaestroService maestroService, Core.Common.Logger.ILog log)
        {
            _maestroService = maestroService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Maestro Service. version: 1.20.01.03");
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Consultar")]
        [HttpPost]
        public IActionResult ConsultarTablaDeTablas([FromBody] ConsultaTablaDeTablasRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<ConsultaDetalleTablaBE> lista = _maestroService.ConsultarDetalleTablaDeTablas(request.EmpresaId, request.Idioma);

                lista = lista.Where(a => a.CodigoTabla.Trim().Equals(request.CodigoTabla.Trim())).ToList();

                if (request.CodigoTabla.Equals("SensorialAtributos"))
                {
                    response.Result.Data = lista;
                }
                else if (request.CodigoTabla.Equals("IndicadorTostado"))
                {
                    response.Result.Data = lista;
                }
                else
                {
                    response.Result.Data = lista.OrderBy(x => x.Label).ToList();
                }
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

            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("ConsultarDepartamento")]
        [HttpPost]
        public IActionResult ConsultarDepartamento([FromBody] ConsultaDepartamentoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<ConsultaUbigeoBE> lista = _maestroService.ConsultaUbibeo();

                if (request.CodigoPais == "PE")
                {
                    lista = lista.Where(a => a.CodigoPais == request.CodigoPais && a.Codigo.EndsWith("0000")).ToList();
                    response.Result.Data = lista.OrderBy(x => x.DescripcionPais).ToList();

                }
                else
                {
                    lista = lista.Where(a => a.CodigoPais == request.CodigoPais && a.Codigo.StartsWith("C"))
                                        .ToList();
                    response.Result.Data = lista.OrderBy(x => x.DescripcionPais).ToList();
                }


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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("ConsultarProvincia")]
        [HttpPost]
        public IActionResult ConsultarProvincia([FromBody] ConsultaProvinciaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<ConsultaUbigeoBE> lista = _maestroService.ConsultaUbibeo();
                string prefijoDepartamento = !String.IsNullOrEmpty(request.CodigoDepartamento.ToString())
                                                && request.CodigoDepartamento.Length >= 2 ? request.CodigoDepartamento.Substring(0, 2) : "-";

                lista = lista.Where(a => a.CodigoPais == request.CodigoPais && a.Codigo.EndsWith("00")
                                                && a.Codigo.StartsWith(prefijoDepartamento)
                                                && !a.Codigo.EndsWith("0000"))
                                        .ToList();

                response.Result.Data = lista.OrderBy(x => x.DescripcionPais).ToList();

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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("ConsultarDistrito")]
        [HttpPost]
        public IActionResult ConsultarDistrito([FromBody] ConsultaDistritoRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<ConsultaUbigeoBE> lista = _maestroService.ConsultaUbibeo();
                string prefijoDepartamento = !String.IsNullOrEmpty(request.CodigoDepartamento.ToString())
                                                && request.CodigoDepartamento.Length >= 2 ? request.CodigoDepartamento.Substring(0, 2) : "-";

                string prefijoProvincia = !String.IsNullOrEmpty(request.CodigoProvincia.ToString())
                                                && request.CodigoProvincia.Length >= 4 ? request.CodigoProvincia.Substring(0, 4) : "-";

                lista = lista.Where(a => a.CodigoPais == request.CodigoPais
                                                        && !a.Codigo.EndsWith("00")
                                                        && a.Codigo.StartsWith(prefijoProvincia))
                                        .ToList();

                response.Result.Data = lista.OrderBy(x => x.DescripcionPais).ToList();

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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("ConsultarZona")]
        [HttpPost]
        public IActionResult ConsultarZona([FromBody] ConsultaZonaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<Zona> lista = _maestroService.ConsultarZona(request.CodigoDistrito);

                response.Result.Data = lista.OrderBy(x => x.Nombre).ToList();

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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("ConsultarPais")]
        [HttpPost]
        public IActionResult ConsultarPais()
        {
            Guid guid = Guid.NewGuid();
            // _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(Str)}");

            ConsultaTablaDeTablasResponseDTO response = new ConsultaTablaDeTablasResponseDTO();
            try
            {
                List<ConsultaPaisBE> lista = _maestroService.ConsultarPais();

                response.Result.Data = lista.OrderBy(x => x.Descripcion).ToList(); ;

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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("ConsultarProductoPrecioDia")]
        [HttpPost]
        public IActionResult ConsultarProductoPrecioDia([FromBody] ConsultaProductoPrecioDiaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            ConsultaProductoPrecioDiaResponseDTO response = new ConsultaProductoPrecioDiaResponseDTO();
            try
            {
                response.Result.Data = _maestroService.ConsultarProductoPrecioDiaPorSubProductoIdPorEmpresaId(request.SubProductoId, request.EmpresaId);

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

            //_log.RegistrarEvento($"{guid.ToString()}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(response)}");

            return Ok(response);
        }

        [Route("ConsultCarrier")]
        [HttpPost]
        public IActionResult ConsultarTransportista([FromBody] ConsultarTransportistaRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            GeneralResponse response = new GeneralResponse();
            try
            {
                response.Result.Data = _maestroService.ConsultarTransportista(request);
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

        [Route("ConsultResponsible")]
        [HttpPost]
        public IActionResult ConsultarResponsable([FromBody] ConsultarResponsableRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{JsonConvert.SerializeObject(request)}");

            GeneralResponse response = new GeneralResponse();
            try
            {
                response.Result.Data = _maestroService.ConsultarResponsable(request);
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
