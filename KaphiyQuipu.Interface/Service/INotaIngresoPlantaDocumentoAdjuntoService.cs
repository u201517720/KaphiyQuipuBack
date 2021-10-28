using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface INotaIngresoPlantaDocumentoAdjuntoService
    {
        int RegistrarNotaIngresoPlantaDocumentoAdjunto(RegistrarActualizarNotaIngresoPlantaDocumentoAdjuntoRequestDTO request, IFormFile file);
        int ActualizarNotaIngresoPlantaDocumentoAdjunto(RegistrarActualizarNotaIngresoPlantaDocumentoAdjuntoRequestDTO request, IFormFile file);
        IEnumerable<ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId> ConsultarNotaIngresoPlantaDocumentoAdjuntoPorNotaIngresoPlantaId(ConsultaNotaIngresoPlantaDocumentoAdjuntoPorNotaIngresoPlantaIdRequestDTO request);
        ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId ConsultarNotaIngresoPlantaDocumentoAdjuntoPorId(ConsultaNotaIngresoPlantaDocumentoAdjuntoPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int EliminarNotaIngresoPlantaDocumentoAdjunto(RegistrarActualizarNotaIngresoPlantaDocumentoAdjuntoRequestDTO request);
    }
}
