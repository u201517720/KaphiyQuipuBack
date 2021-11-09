using Core.Common.Email;
using Core.Common.Razor;
using Core.Common.SMS;
using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.ERC20;
using KaphiyQuipu.Blockchain.Facade;
using KaphiyQuipu.Blockchain.Services;
using KaphiyQuipu.DTO.ContratoCompraVenta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace KaphiyQuipu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartContractController : ControllerBase
    {
        private IContractFacade _contractFacade;
        private IContractOperation _operation;

        private Web3 _web3;
        private IAccount _account;
        private ContractService _contractService;
        private IAccountService _accountService;
        private IMessageSender _messageSender;
        private IEmailService _emailService;
        private IViewRender _viewRender;

        public SmartContractController(
            IContractFacade contractFacade,
            IContractOperation operation,
            ContractService contractService,
            IAccountService accountService,
            IMessageSender messageSender,
             IEmailService emailService,
             IViewRender viewRender)
        {
            _contractFacade = contractFacade;
            _operation = operation;
            _contractService = contractService;
            _accountService = accountService;
            _web3 = _accountService.GetWeb3();
            _account = _accountService.GetAccount();
            _messageSender = messageSender;
            _emailService = emailService;
            _viewRender = viewRender;
        }

        [HttpGet("sms")]
        public async Task<IActionResult> SendSMS(string mensaje)
        {
            var response = await _messageSender.SendSmsAsync("988863908", mensaje);

            return Ok(new { response.Item1, response.Item2 });
        }

        [HttpPost("email")]
        public async Task<IActionResult> SendEmail(SolicitudConfirmacionAgrigultorDTO solicitudConfirmacion)
        {
            ParametroEmail oParametroEmail = new ParametroEmail();
            oParametroEmail.Para = "crisvelasquez02@gmail.com";
            oParametroEmail.Asunto = "Solicitud Confirmación";
            oParametroEmail.IsHtml = true;
            oParametroEmail.Mensaje = await _viewRender.RenderAsync(@"Mailing\mail-solicitud-confirmacion", solicitudConfirmacion);

            var response = await _emailService.SendEmailAsync(oParametroEmail);

            return Ok(new { response });
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var contract = await _contractFacade.GetContract("UserContract", true, "0x89D46B6CAaf575CF878fc18209F357f2B320a5Bb");
            //var contract = await _contractFacade.GetContract("UserContract", true, "0x7Ed22e76E47dE32cD0CE4E3D6E136e5340192891");

            var totalUsers = contract.Contract.GetFunction("totalUsers").CallAsync<long>();

            var autenticate = await contract.Contract.GetFunction("validateUser").CallAsync<bool>("admin@gmail.com", "5JKIrQpthKxsTzF4kTDryw==");
 
            var user = await contract.Contract.GetFunction("getUser").CallDeserializingToObjectAsync<GenericOutputDTO<UserDTO>>("admin@gmail.com");


            //var total = await contract.Contract.GetFunction("totalUsers").CallAsync<long>();
            var userfunction = contract.Contract.GetFunction("users");
            var data = await userfunction.CallDeserializingToObjectAsync<UserDTO>(1L).ConfigureAwait(false);
            return Ok(user.Data);
        }
    }
}
