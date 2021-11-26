using AutoMapper;
using Core.Common.Email;
using Core.Common.Razor;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Service
{
    public class GuiaRemisionPlantaService : IGuiaRemisionPlantaService
    {
        private readonly IMapper _Mapper;
        ICorrelativoRepository _ICorrelativoRepository;
        IGuiaRemisionPlantaRepository _IGuiaRemisionPlantaRepository;
        private IViewRender _viewRender;
        private IEmailService _emailService;

        public GuiaRemisionPlantaService(IMapper mapper, ICorrelativoRepository correlativoRepository, IGuiaRemisionPlantaRepository guiaRemisionPlantaRepository, IViewRender viewRender, IEmailService emailService)
        {
            _Mapper = mapper;
            _ICorrelativoRepository = correlativoRepository;
            _IGuiaRemisionPlantaRepository = guiaRemisionPlantaRepository;
            _viewRender = viewRender;
            _emailService = emailService;
        }

        public ConsultarCorrelativoGuiaRemisionPlantaDTO ConsultarCorrelativo(ConsultarCorrelativoGuiaRemisionPlantaRequestDTO request)
        {
            ConsultarCorrelativoGuiaRemisionPlantaDTO response = null;
            var guiaRecepcion = _IGuiaRemisionPlantaRepository.ConsultarCorrelativo(request.Correlativo);
            if (guiaRecepcion.Any())
            {
                response = guiaRecepcion.ToList().FirstOrDefault();
            }

            return response;
        }

        public async Task<string> Registrar(GenerarGuiaRemisionPlantaRequestDTO request)
        {
            GuiaRemisionPlanta guiaSalida = _Mapper.Map<GuiaRemisionPlanta>(request);
            guiaSalida.FechaRegistro = DateTime.Now;
            guiaSalida.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.GuiaRemisionPlanta);

            string affected = _IGuiaRemisionPlantaRepository.Registrar(guiaSalida);
            request.Correlativo = affected;

            ParametroEmail oParametroEmail = new ParametroEmail();
            oParametroEmail.Para = "jjordandt@gmail.com";
            oParametroEmail.Asunto = "Transformación terminada";
            oParametroEmail.IsHtml = true;
            oParametroEmail.Mensaje = await _viewRender.RenderAsync(@"Mailing\mail-EnvioCafeTransformado", request);

            await _emailService.SendEmailAsync(oParametroEmail, request.Empresa);

            return affected;
        }
    }
}
