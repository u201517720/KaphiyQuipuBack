using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IProveedorRepository
    {
        IEnumerable<ConsultaProveedoresBE> ConsultarProveedores(ConsultaProveedoresRequestDTO request);
    }
}