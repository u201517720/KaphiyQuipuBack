using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface IProductorDocumentoService
    {
        int RegistrarProductorDocumento(RegistrarProductorDocumentoRequestDTO request, IFormFile file);
        int ActualizarProductorDocumento(RegistrarProductorDocumentoRequestDTO request, IFormFile file);
        IEnumerable<ConsultarProductorDocumentoPorProductorId> ConsultarProductorDocumentoPorProductorId(ConsultarProductorDocumentoPorProductorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int EliminarProductorDocumento(RegistrarProductorDocumentoRequestDTO request);

    }
}
