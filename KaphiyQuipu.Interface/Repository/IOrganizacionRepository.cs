using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IOrganizacionRepository
    {   
        IEnumerable<ConsultaOrganizacionBE> ConsultarOrganizacion(ConsultaOrganizacionRequestDTO request);
    }
}
