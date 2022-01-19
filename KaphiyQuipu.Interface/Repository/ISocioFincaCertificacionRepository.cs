using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ISocioFincaCertificacionRepository
    {
        int Insertar(SocioFincaCertificacion socioFincaCertificacion);

        int Actualizar(SocioFincaCertificacion socioFincaCertificacion);

        IEnumerable<ConsultaSocioFincaCertificacionPorSocioFincaId> ConsultarSocioFincaCertificacionPorSocioFincaId(int socioFincaId);

        ConsultaSocioFincaCertificacionPorId ConsultarSocioFincaCertificacionPorId(int socioFincaId);
    }
}