using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public partial class EmpresaService : IEmpresaService
    {

        private IEmpresaRepository _IEmpresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _IEmpresaRepository = empresaRepository;
        }
        public List<EmpresaBE> ConsultarEmpresa(int empresaId)
        {
            var lista = _IEmpresaRepository.ConsultarEmpresa(empresaId);

            return lista.ToList();
        }
    }
}
