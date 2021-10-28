using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IOrganizacionService
    {
        List<ConsultaOrganizacionBE> ConsultarOrganizacion(ConsultaOrganizacionRequestDTO request);

    }
}
