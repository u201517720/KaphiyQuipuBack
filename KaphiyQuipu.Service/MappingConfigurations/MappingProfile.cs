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
            CreateMap<RegistrarOrdenProcesoAcopioRequestDTO, OrdenProcesoAcopio>();
            CreateMap<RegistrarGuiaRemisionAcopioRequestDTO, MarcadoSacoAcopio>();
            CreateMap<RegistrarGuiaRemisionAcopioRequestDTO, GuiaRemisionAcopio>();
            CreateMap<RegistrarNotaIngresoPlantaRequestDTO, NotaIngresoPlanta>();
            CreateMap<RegistrarControlCalidadNotaIngresoPlantaRequestDTO, NotaIngresoPlanta>();
            CreateMap<RegistrarResultadosTransformacionNotaIngresoPlantaRequestDTO,NotaIngresoPlantaResultadoTransformacion>();
            CreateMap<GenerarNotaSalidaPlantaRequestDTO, NotaSalidaPlanta>();
            CreateMap<GenerarGuiaRemisionPlantaRequestDTO, GuiaRemisionPlanta>();
            CreateMap<RegistrarDevolucionNotaIngresoRequestDTO, NotaIngresoDevolucion>();
            CreateMap<RegistrarDevolucionGuiaRemisionRequestDTO, GuiaRemisionDevolucion>();
        }
    }

}
