using Core.Common.Domain.Model;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Helpers.OperationResults;
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
        private IContratoCompraContract _IContratoCompraContract;

        public AgricultorService(IAgricultorRepository agricultorRepository, IContratoCompraContract contratoCompraContract)
        {
            _IAgricultorRepository = agricultorRepository;
            _IContratoCompraContract = contratoCompraContract;
        }

        public void ConfirmarDisponibilidad(ConfirmarDisponibilidadRequestDTO request)
        {
            _IAgricultorRepository.ConfirmarDisponibilidad(request.ContratoSocioFincaId, request.Usuario);
        }

        public void ConfirmarEnvio(ConfirmarEnvioRequestDTO request)
        {
            ConfirmacionEnvioAgricultorDTO confirmacionEnvioAgricultorDTO = _IAgricultorRepository.ObtenerDatosConfirmacionEnvio(request.ContratoSocioFincaId);
            AgricultorContratoDTO agricultorContratoDTO = new AgricultorContratoDTO();
            agricultorContratoDTO.NroContrato = confirmacionEnvioAgricultorDTO.Contrato;
            agricultorContratoDTO.Nombre = confirmacionEnvioAgricultorDTO.NombreAgricultor;
            agricultorContratoDTO.NroDocumento = confirmacionEnvioAgricultorDTO.DNIAgricultor;
            agricultorContratoDTO.Finca = confirmacionEnvioAgricultorDTO.Finca;
            agricultorContratoDTO.Certificacion = confirmacionEnvioAgricultorDTO.Certificacion;

            TransactionResult result = _IContratoCompraContract.AgregarAgricultor(agricultorContratoDTO).Result;

            _IAgricultorRepository.ConfirmarEnvio(request.ContratoSocioFincaId, request.Usuario, result.TransactionHash);
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
                x.NombreCompleto = string.Format("{0}, {1}", x.ApellidoSocio.Trim(), x.NombreSocio.Trim());
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
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue)
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });
            }

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 365)
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });
            }
            List<ConsultaMateriaPrimaSolicitadaDTO> resultados = new List<ConsultaMateriaPrimaSolicitadaDTO>();
            request.FechaFin = request.FechaFin.AddHours(23).AddMinutes(59).AddSeconds(59);
            var list = _IAgricultorRepository.ConsultarMateriaPrimaSolicitada(request);
            resultados = list.ToList();
            return resultados;
        }

        public List<ListarCosechasPorAgricultorDTO> ListarCosechasPorAgricultor(ListarCosechasPorAgricultorRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue)
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });
            }

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 365)
            {
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });
            }
            request.FechaFin = request.FechaFin.AddHours(23).AddMinutes(59).AddSeconds(59);
            var list = _IAgricultorRepository.ListarCosechasPorAgricultor(request);
            List<ListarCosechasPorAgricultorDTO> resultados = list.ToList();
            return resultados;
        }

        public List<ListarFincasPorAgricultorDTO> ListarFincasPorAgricultor(ListarFincasPorAgricultorRequestDTO request)
        {
            List<ListarFincasPorAgricultorDTO> lista = new List<ListarFincasPorAgricultorDTO>();
            var result = _IAgricultorRepository.ListarFincasPorAgricultor(request.CodigoUsuario);
            if (result.Any())
            {
                lista = result.ToList();
            }
            return lista;
        }

        public void RegistrarCosechaPorFinca(RegistrarCosechaPorFincaRequestDTO request)
        {
            request.Fecha = DateTime.Now;
            _IAgricultorRepository.RegistrarCosechaPorFinca(request);
        }
    }
}
