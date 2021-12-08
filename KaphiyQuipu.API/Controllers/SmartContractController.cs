using Core.Common.Email;
using Core.Common.Razor;
using Core.Common.SMS;
using KaphiyQuipu.API.Helper;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Contracts.Interface;
using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.ERC20;
using KaphiyQuipu.Blockchain.Facade;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
using KaphiyQuipu.Blockchain.Services;
using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.ContratoCompraVenta;
using KaphiyQuipu.DTO.Seguridad;
using KaphiyQuipu.Interface.Service;
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
        private IContratoService _contratoService;
        private ReportService _reportService;
        private IViewRender _viewRender;
        private IUserContract _userContract;
        private INotaIngresoPlantaContract _notaIngresoPlantaContract;

        public SmartContractController(
            IContractFacade contractFacade,
            IContractOperation operation,
            ContractService contractService,
            IAccountService accountService,
            IMessageSender messageSender,
             IEmailService emailService,
             IContratoService contratoService,
             ReportService reportService,
             IViewRender viewRender,
             IUserContract userContract,
             INotaIngresoPlantaContract notaIngresoPlantaContract)
        {
            _contractFacade = contractFacade;
            _operation = operation;
            _contractService = contractService;
            _accountService = accountService;
            _web3 = _accountService.GetWeb3();
            _account = _accountService.GetAccount();
            _messageSender = messageSender;
            _emailService = emailService;
            _contratoService = contratoService;
            _reportService = reportService;
            _viewRender = viewRender;
            _userContract = userContract;
            _notaIngresoPlantaContract = notaIngresoPlantaContract;
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
            return Ok(await _userContract.ListarUsuarios());
        }

        [HttpPost("users")]
        public async Task<IActionResult> AddUser(UsuarioDTO usuario)
        {
            return Ok(await _userContract.AgregarUsuario(usuario));
        }

        [HttpGet("v2/users")]
        public async Task<IActionResult> GetV2Users()
        {
            var contract = await _contractFacade.GetContract("UserContract", true, "0xd525DEf1Df2E0C3a29143D9FCEeD821a82C6f516");

            var totalUsers = (int)(await contract.Contract.GetFunction("totalUsers").CallAsync<long>());
            var userfunction = contract.Contract.GetFunction("users");

            List<UserResponseDTO> users = new List<UserResponseDTO>();
            for (int i = 0; i < totalUsers; i++)
            {
                var user = await userfunction.CallDeserializingToObjectAsync<UserResponseDTO>(i);
                users.Add(user);
            }

            return Ok(users);
        }

        [HttpGet("trazabilidad/{nroContrato}")]
        public async Task<IActionResult> ObtenerTrazabilidad([FromRoute]string nroContrato)
        {
            List<(string, List<object>)> datasets = await _contratoService.ObtenerDatosTrazabilidad(nroContrato);
            byte[] reportData = _reportService.Procesar("SolicitudCompra", null, datasets);
            return File(reportData, System.Net.Mime.MediaTypeNames.Application.Pdf, $"{nroContrato}.pdf");
        }

        [HttpPost("nota-ingreso/control-calidad")]
        public async Task<IActionResult> RegistrarNotaIngresoControlCalidad([FromBody] RegistrarControlCalidadNotaIngresoPlantaRequestDTO request)
        {
            TransactionResult result = await _notaIngresoPlantaContract.RegistrarControlCalidad(request, "C000" + request.Id.ToString(), DateTime.Now);
            return Ok(result);
        }

        [HttpGet("nota-ingreso/control-calidad")]
        public async Task<IActionResult> ObtenerNotaIngresoControlCalidad([FromQuery] string correlativo)
        {
            return Ok(await _notaIngresoPlantaContract.ObtenerControlCalidadPorCorrelativo(correlativo));
        }

        [HttpPost("nota-ingreso/resultado-transformacion")]
        public async Task<IActionResult> RegistrarNotaIngresoResultadoTransformacion([FromBody] RegistrarResultadosTransformacionNotaIngresoPlantaRequestDTO request)
        {
            TransactionResult result = await _notaIngresoPlantaContract.RegistrarResultadoTransformacion(request, "NIP0000016", DateTime.Now);
            return Ok(result);
        }


        [HttpGet("nota-ingreso/resultado-transformacion")]
        public async Task<IActionResult> ObtenerNotaIngresoResultadoTransformacionPorCorrelativo([FromQuery] string correlativo)
        {
            return Ok(await _notaIngresoPlantaContract.ObtenerResultadoTransformacionPorCorrelativo(correlativo));
        }
    }
}
