using AutoMapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;

namespace KaphiyQuipu.Service.MappingConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrarActualizarProductorRequestDTO, Productor>();
            CreateMap<RegistrarActualizarSocioRequestDTO, Socio>();
            CreateMap<RegistrarActualizarProductorFincaRequestDTO, ProductorFinca>();
            CreateMap<RegistrarActualizarSocioFincaRequestDTO, SocioFinca>();
            CreateMap<RegistrarActualizarSocioFincaCertificacionRequestDTO, SocioFincaCertificacion>();
            CreateMap<NotaSalidaAlmacen, GuiaRemisionAlmacen>();
            CreateMap<NotaSalidaAlmacenPlanta, GuiaRemisionAlmacenPlanta>();
            
            CreateMap<RegistrarActualizarClienteRequestDTO, Cliente>();
            CreateMap<RegistrarActualizarEmpresaTransporteRequestDTO, EmpresaTransporte>();
            CreateMap<RegistrarActualizarTransporteRequestDTO, Transporte>();
            CreateMap<RegistrarActualizarFincaMapaRequestDTO, FincaMapa>();
            CreateMap<RegistrarActualizarFincaDocumentoAdjuntoRequestDTO, FincaDocumentoAdjunto>();
            CreateMap<RegistrarActualizarFincaFotoGeoreferenciadaRequestDTO, FincaFotoGeoreferenciada>();
            CreateMap<RegistrarActualizarContratoRequestDTO, Contrato>();
            CreateMap<RegistrarActualizarZonaRequestDTO, Zona>();
            CreateMap<RegistrarActualizarAduanaRequestDTO, Aduana>();
            CreateMap<RegistrarActualizarDetalleCatalogoRequestDTO, DetalleCatalogo>();
            CreateMap<RegistrarSocioDocumentoRequestDTO, SocioDocumento>();
            CreateMap<RegistrarProductorDocumentoRequestDTO, ProductorDocumento>();
            CreateMap<RegistrarActualizarSocioProyectoRequestDTO, SocioProyecto>();
            CreateMap<RegistrarActualizarLiquidacionProcesoPlantaRequestDTO, LiquidacionProcesoPlanta>();
            CreateMap<RegistrarActualizarOrdenProcesoPlantaRequestDTO, OrdenProcesoPlanta>();
            CreateMap<RegistrarActualizarOrdenProcesoRequestDTO, OrdenProceso>();
            CreateMap<RegistrarActualizarUbigeoRequestDTO, Ubigeo>();
            CreateMap<RegistrarActualizarProductoPrecioDiaRequestDTO, ProductoPrecioDia>();
            CreateMap<RegistrarActualizarTipoCambioDiaRequestDTO, TipoCambioDia>();
            CreateMap<RegistrarActualizarEmpresaProveedoraAcreedoraRequestDTO, EmpresaProveedoraAcreedora>();
            CreateMap<RegistrarActualizarDiagnosticoRequestDTO, Diagnostico>();
            CreateMap<RegistrarActualizarAdelantoRequestDTO, Adelanto>();
            CreateMap<RegistrarActualizarSolicitudCompraRequestDTO, SolicitudCompra>();
        }
    }

}
