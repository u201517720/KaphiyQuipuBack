using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IAgricultorRepository
    {
        IEnumerable<ConsultaAgricultorDTO> Consultar(ConsultaAgricultorRequestDTO request);
        IEnumerable<ConsultaMateriaPrimaSolicitadaDTO> ConsultarMateriaPrimaSolicitada(ConsultaMateriaPrimaSolicitadaRequestDTO request);
        ConsultaMateriaPrimaSolicitadaDTO ConsultarDetalleMateriaPrimaSolicitada(int contratoSocioFincaId);
        void ConfirmarDisponibilidad(int ContratoSocioFincaId, string usuario);
        void ConfirmarEnvio(int ContratoSocioFincaId, string usuario, string hash);
        ConfirmacionEnvioAgricultorDTO ObtenerDatosConfirmacionEnvio(int contratoSocioFincaId);
        IEnumerable<ListarCosechasPorAgricultorDTO> ListarCosechasPorAgricultor(ListarCosechasPorAgricultorRequestDTO request);
    }
}
