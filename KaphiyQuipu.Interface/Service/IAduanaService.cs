using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IAduanaService
    {
        int RegistrarAduana(RegistrarActualizarAduanaRequestDTO request);
        int ActualizarAduana(RegistrarActualizarAduanaRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int AnularAduana(AnularAduanaRequestDTO request);
    }
}
