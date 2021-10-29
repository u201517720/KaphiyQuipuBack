using KaphiyQuipu.DTO;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Service
{
    public interface IEmpresaService
    {
        List<EmpresaBE> ConsultarEmpresa(int empresaId);

    }
}
