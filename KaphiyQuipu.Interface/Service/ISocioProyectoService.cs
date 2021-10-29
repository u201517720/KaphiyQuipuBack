using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface ISocioProyectoService
    {

        int RegistrarSocioProyecto(RegistrarActualizarSocioProyectoRequestDTO request);
        int ActualizarSocioProyecto(RegistrarActualizarSocioProyectoRequestDTO request);

        IEnumerable<ConsultaSocioProyectoPorSocioIdBE> ConsultarSocioProyectoPorSocioId(ConsultaSocioProyectoPorSocioIdRequestDTO request);

        ConsultaSocioProyectoPorIdBE ConsultarSocioProyectoPorId(ConsultaSocioProyectoPorIdRequestDTO request);

       
    }
}
