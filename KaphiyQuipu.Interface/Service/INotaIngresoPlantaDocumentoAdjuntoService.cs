using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface INotaIngresoPlantaDocumentoAdjuntoService
    {
        
        
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

    }
}
