using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IProveedorService
    {
        List<ConsultaProveedoresBE> ConsultarProveedores(ConsultaProveedoresRequestDTO consultaProveedoresRequestDTO);

    }
}
