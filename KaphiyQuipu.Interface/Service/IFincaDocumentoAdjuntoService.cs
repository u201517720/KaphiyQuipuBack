﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IFincaDocumentoAdjuntoService
    {
        int RegistrarFincaDocumentoAdjunto(RegistrarActualizarFincaDocumentoAdjuntoRequestDTO request, IFormFile file);
        int ActualizarFincaDocumentoAdjunto(RegistrarActualizarFincaDocumentoAdjuntoRequestDTO request, IFormFile file);
        IEnumerable<ConsultaFincaDocumentoAdjuntoPorId> ConsultarFincaDocumentoAdjuntoPorFincaId(ConsultaFincaDocumentoAdjuntoPorFincaIdRequestDTO request);
        ConsultaFincaDocumentoAdjuntoPorId ConsultarFincaDocumentoAdjuntoPorId(ConsultaFincaDocumentoAdjuntoPorIdRequestDTO request);
        ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request);

        int EliminarFincaDocumentoAdjunto(RegistrarActualizarFincaDocumentoAdjuntoRequestDTO request);
    }
}
