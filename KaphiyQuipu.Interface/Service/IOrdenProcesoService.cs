using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IOrdenProcesoService
    {
        List<ConsultaOrdenProcesoBE> ConsultarOrdenProceso(ConsultaOrdenProcesoRequestDTO request);
        int RegistrarOrdenProceso(RegistrarActualizarOrdenProcesoRequestDTO request, IFormFile file);
        int ActualizarOrdenProceso(RegistrarActualizarOrdenProcesoRequestDTO request, IFormFile file);
        ConsultaOrdenProcesoPorIdBE ConsultarOrdenProcesoPorId(ConsultaOrdenProcesoPorIdRequestDTO request);
        int AnularOrdenProceso(AnularOrdenProcesoRequestDTO request);
        ConsultarImpresionOrdenProcesoResponseDTO ConsultarImpresionOrdenProceso(ConsultarImpresionOrdenProcesoRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);
    }
}
