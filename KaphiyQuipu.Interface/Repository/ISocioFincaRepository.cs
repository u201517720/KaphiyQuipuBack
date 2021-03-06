using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ISocioFincaRepository
    {
        int Insertar(SocioFinca productorFinca);
        int Actualizar(SocioFinca productorFinca);
        IEnumerable<ConsultaSocioFincaPorSocioIdBE> ConsultarSocioFincaPorSocioId(int socioId);
        ConsultaSocioFincaPorIdBE ConsultarSocioFincaPorId(int socioFincaId);
        IEnumerable<ConsultaSocioFincaEstimadoPorSocioFincaIdBE> ConsultarSocioFincaEstimadoPorSocioFincaId(int socioId);
        int ActualizarSocioFincaEstimado(List<SocioFincaEstimadoTipo> request, int socioFincaId);
        int ActualizarSocioFincaEstimadoConsumido(int socioFincaEstimadoId, decimal consumido);
    }
}