using KaphiyQuipu.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface IGeneralService
    {
        List<ConsultarDocumentoPagoDTO> ConsultarDocumentoPago(ConsultarDocumentoPagoRequestDTO request);
        ConsultarDocumentoPagoPorIdDTO ConsultarDocumentoPagoPorId(ConsultarDocumentoPagoPorIdRequestDTO request);
        void GuardarVoucher(GuardarVoucherRequestDTO request, IFormFile file);
        void ConfirmarVoucherPago(ConfirmarVoucherPagoRequestDTO request);
    }
}
