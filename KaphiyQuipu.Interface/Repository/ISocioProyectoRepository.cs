using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ISocioProyectoRepository
    {
        int Insertar(SocioProyecto socioProyecto);
        int Actualizar(SocioProyecto socioProyecto);
        IEnumerable<ConsultaSocioProyectoPorSocioIdBE> ConsultarSocioProyectoPorSocioId(int socioId);
        ConsultaSocioProyectoPorIdBE ConsultarSocioProyectoPorId(int socioProyectoId);
    }
}
