using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface ISocioFincaService
    {

        int RegistrarSocioFinca(RegistrarActualizarSocioFincaRequestDTO request);
        int ActualizarSocioFinca(RegistrarActualizarSocioFincaRequestDTO request);

        IEnumerable<ConsultaSocioFincaPorSocioIdBE> ConsultarSocioFincaPorSocioId(ConsultaSocioFincaPorSocioIdRequestDTO request);

        ConsultaSocioFincaPorIdBE ConsultarSocioFincaPorId(ConsultaSocioFincaPorIdRequestDTO request);

        ConsultarSocioProductorPorSocioFincaId ConsultarSocioProductorPorSocioFincaId(ConsultaSocioFincaPorIdRequestDTO request);

        public ConsultaSocioFincaEstimadoPorSocioFincaIdBE ConsultarSocioFincaEstimadoPorSocioFincaId(ConsultaSocioFincaEstimadoPorSocioFincaIdRequest request);
    }
}
