using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adelanto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface IAdelantoService
    {
        List<ConsultaAdelantoBE> ConsultarAdelanto(ConsultaAdelantoRequestDTO request);
        GenerarPDFAdelantoResponseDTO GenerarPDF(int id);

        int RegistrarAdelanto(RegistrarActualizarAdelantoRequestDTO request);
        int ActualizarAdelanto(RegistrarActualizarAdelantoRequestDTO request);
        ConsultaAdelantoPorIdBE ConsultarAdelantoPorId(ConsultaAdelantoPorIdRequestDTO request);


        int AnularAdelanto(AnularAdelantoRequestDTO request);

        int AsociarAdelanto(AsociarAdelantoRequestDTO request);


    }
}
