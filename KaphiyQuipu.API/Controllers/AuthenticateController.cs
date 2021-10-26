﻿using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Core.Common.Encryption;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoffeeConnect.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IUsersService _usersService;
        private Core.Common.Logger.ILog _log;
        public AuthenticateController(IUsersService usersService, Core.Common.Logger.ILog log)
        {
            _usersService = usersService;
            _log = log;
        }

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Authenticate Service. version: 1.20.01.03");
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDTO request)
        {
            Guid guid = Guid.NewGuid();
            _log.RegistrarEvento($"{guid}{Environment.NewLine}{Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            LoginResponseDTO response = new LoginResponseDTO();
            try
            {
                response.Result.Data = _usersService.AuthenticateUsers(request.UserName, EncryptionLibrary.EncryptText(request.Password));
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
