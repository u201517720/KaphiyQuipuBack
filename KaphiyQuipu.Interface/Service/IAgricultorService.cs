using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface IAgricultorService
    {
        List<ConsultaAgricultorDTO> Consultar(ConsultaAgricultorRequestDTO request);
        List<ConsultaMateriaPrimaSolicitadaDTO> ConsultarMateriaPrimaSolicitada(ConsultaMateriaPrimaSolicitadaRequestDTO request);
        ConsultaMateriaPrimaSolicitadaDTO ConsultarDetalleMateriaPrimaSolicitada(ConsultarDetalleMateriaPrimaSolicitadaRequestDTO request);
        void ConfirmarDisponibilidad(ConfirmarDisponibilidadRequestDTO request);
        void ConfirmarEnvio(ConfirmarEnvioRequestDTO request);
        List<ListarCosechasPorAgricultorDTO> ListarCosechasPorAgricultor(ListarCosechasPorAgricultorRequestDTO request);
        List<ListarFincasPorAgricultorDTO> ListarFincasPorAgricultor(ListarFincasPorAgricultorRequestDTO request);
        void RegistrarCosechaPorFinca(RegistrarCosechaPorFincaRequestDTO request);
    }
}
