using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaphiyQuipu.Service
{
    public class AgricultorService : IAgricultorService
    {
        private IAgricultorRepository _IAgricultorRepository;

        public AgricultorService(IAgricultorRepository agricultorRepository)
        {
            _IAgricultorRepository = agricultorRepository;
        }

        public List<ConsultaAgricultorDTO> Consultar(ConsultaAgricultorRequestDTO request)
        {
            List<ConsultaAgricultorDTO> agricultores = new List<ConsultaAgricultorDTO>();
            if (string.IsNullOrEmpty(request.TipoCertificacionId))
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });
            }

            var list = _IAgricultorRepository.Consultar(request);
            agricultores = list.ToList();
            agricultores.ForEach(x =>
            {
                x.NombreSocio = string.Format("{0} {1}", x.ApellidoSocio.Trim(), x.NombreSocio.Trim());
                x.FechaActualizacionString = x.FechaRegistro != null ? ((DateTime)x.FechaRegistro).ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
            });
            return agricultores;
        }

        public ConsultaMateriaPrimaSolicitadaDTO ConsultarDetalleMateriaPrimaSolicitada(ConsultarDetalleMateriaPrimaSolicitadaRequestDTO request)
        {
            return _IAgricultorRepository.ConsultarDetalleMateriaPrimaSolicitada(request.ContratoSocioFincaId);
        }

        public List<ConsultaMateriaPrimaSolicitadaDTO> ConsultarMateriaPrimaSolicitada(ConsultaMateriaPrimaSolicitadaRequestDTO request)
        {
            List<ConsultaMateriaPrimaSolicitadaDTO> resultados = new List<ConsultaMateriaPrimaSolicitadaDTO>();
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue)
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });
            }

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 365)
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });
            }

            var list = _IAgricultorRepository.ConsultarMateriaPrimaSolicitada(request);
            resultados = list.ToList();
            return resultados;
        }
    }
}
