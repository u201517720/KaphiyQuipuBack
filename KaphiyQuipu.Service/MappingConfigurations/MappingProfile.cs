using AutoMapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;

namespace KaphiyQuipu.Service.MappingConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrarActualizarContratoRequestDTO, Contrato>();
            CreateMap<RegistrarActualizarDetalleCatalogoRequestDTO, DetalleCatalogo>();
            CreateMap<RegistrarActualizarUbigeoRequestDTO, Ubigeo>();
            CreateMap<RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO, EmpresaProveedoraAcreedora>();
            CreateMap<RegistrarActualizarSolicitudCompraRequestDTO, SolicitudCompra>();
            CreateMap<RegistrarActualizarGuiaRecepcionRequestDTO, GuiaRecepcionMateriaPrima>();
            CreateMap<RegistrarNotaIngresoAcopioRequestDTO, NotaIngresoAlmacenAcopio>();
        }
    }

}
