using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGeneralRepository
    {
        IEnumerable<ConsultarDocumentoPagoDTO> ConsultarDocumentoPago(string correlativoDPA, string correlativoCC);
        IEnumerable<ConsultarDocumentoPagoPorIdDTO> ConsultarDocumentoPagoPorId(int id);
    }
}
