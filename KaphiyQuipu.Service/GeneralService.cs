using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public class GeneralService : IGeneralService
    {
        private IGeneralRepository _generalRepository;
        public GeneralService(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public List<ConsultarDocumentoPagoDTO> ConsultarDocumentoPago(ConsultarDocumentoPagoRequestDTO request)
        {
            List<ConsultarDocumentoPagoDTO> response = new List<ConsultarDocumentoPagoDTO>();
            var lista = _generalRepository.ConsultarDocumentoPago(request.CorrelativoDPA, request.CorrelativoCC);
            if (lista.Any())
            {
                response = lista.ToList();
            }
            return response;
        }

        public ConsultarDocumentoPagoPorIdDTO ConsultarDocumentoPagoPorId(ConsultarDocumentoPagoPorIdRequestDTO request)
        {
            ConsultarDocumentoPagoPorIdDTO response = new ConsultarDocumentoPagoPorIdDTO();
            var lista = _generalRepository.ConsultarDocumentoPagoPorId(request.Id);
            if (lista.Any())
            {
                response = lista.FirstOrDefault();
            }
            return response;
        }
    }
}
