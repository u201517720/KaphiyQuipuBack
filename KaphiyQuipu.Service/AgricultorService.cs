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
            if (request.TipoCertificacionId <= 0)
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });
            }

            var list = _IAgricultorRepository.Consultar(request);
            agricultores = list.ToList();
            agricultores.ForEach(x =>
            {
                x.NombreSocio = string.Format("{0} {1}", x.ApellidoSocio.Trim(), x.NombreSocio.Trim());
                //x.FechaActualizacionString = x.FechaActualizacion != null ? x.FechaActualizacion.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
            });
            return agricultores;
        }
    }
}
