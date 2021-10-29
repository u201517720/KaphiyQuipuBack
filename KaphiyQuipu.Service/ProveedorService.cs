using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public partial class ProveedorService : IProveedorService
    {

        private IProveedorRepository _IProveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _IProveedorRepository = proveedorRepository;
        }
        public List<ConsultaProveedoresBE> ConsultarProveedores(ConsultaProveedoresRequestDTO consultaProveedoresRequestDTO)
        {
            //if (string.IsNullOrEmpty(consultaGuiaRemisionRequestDTO.NumeroDocumento) && string.IsNullOrEmpty(consultaGuiaRemisionRequestDTO.NumeroDocumento))
            //    throw new ResultException(new Result { ErrCode = "-20", Message = "Especifique un Número de BL o Contenedor" });

            var proveedoresList = _IProveedorRepository.ConsultarProveedores(consultaProveedoresRequestDTO);

            return proveedoresList.ToList();
        }





    }
}
