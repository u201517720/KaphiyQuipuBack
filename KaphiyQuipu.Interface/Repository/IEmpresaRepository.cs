using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IEmpresaRepository
    {     
        Empresa ObtenerEmpresaPorId(int empresaId);
        IEnumerable<EmpresaBE> ConsultarEmpresa(int empresaId);
    }
}
