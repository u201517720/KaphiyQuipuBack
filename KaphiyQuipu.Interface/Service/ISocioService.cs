using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface ISocioService
    {
        int RegistrarSocio(RegistrarActualizarSocioRequestDTO request);
        int ActualizarSocio(RegistrarActualizarSocioRequestDTO request);
        List<ConsultaSocioBE> ConsultarSocio(ConsultaSocioRequestDTO request);
        ConsultaSocioPorIdBE ConsultarSocioPorId(ConsultaSocioPorIdRequestDTO request);
    }
}
