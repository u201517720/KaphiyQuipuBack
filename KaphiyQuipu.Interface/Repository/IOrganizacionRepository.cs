using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IOrganizacionRepository
    {   
        IEnumerable<ConsultaOrganizacionBE> ConsultarOrganizacion(ConsultaOrganizacionRequestDTO request);
    }
}
