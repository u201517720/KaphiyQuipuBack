using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface ITipoCambioDiaService
    {

        int RegistrarTipoCambioDia(RegistrarActualizarTipoCambioDiaRequestDTO request);
        int ActualizarTipoCambioDia(RegistrarActualizarTipoCambioDiaRequestDTO request);


        List<ConsultaTipoCambioDiaBE> ConsultarTipoCambioDia(ConsultaTipoCambioDiaRequestDTO request);
        ConsultaTipoCambioDiaPorIdBE ConsultarTipoCambioDiaPorId(ConsultaTipoCambioDiaPorIdRequestDTO request);

        int AnularTipoCambioDia(AnularTipoCambioDiaRequestDTO request);
    }
}
