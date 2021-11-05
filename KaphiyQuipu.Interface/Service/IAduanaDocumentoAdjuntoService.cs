using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IAduanaDocumentoAdjuntoService
    {
        
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

    }
}
