using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface ISocioDocumentoService
    {
        int RegistrarSocioDocumento(RegistrarSocioDocumentoRequestDTO request, IFormFile file);
        int ActualizarSocioDocumento(RegistrarSocioDocumentoRequestDTO request, IFormFile file);
        IEnumerable<ConsultarSocioDocumentoPorSocioId> ConsultarSocioDocumentoPorSocioId(ConsultarSocioDocumentoPorSocioIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int EliminarSocioDocumento(RegistrarSocioDocumentoRequestDTO request);

    }
}
