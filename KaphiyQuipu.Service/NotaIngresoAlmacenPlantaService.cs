﻿
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public partial class NotaIngresoAlmacenPlantaService : INotaIngresoAlmacenPlantaService
    {

        private INotaIngresoAlmacenPlantaRepository _INotaIngresoAlmacenPlantaRepository;
        private INotaIngresoPlantaRepository _INotaIngresoPlantaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public NotaIngresoAlmacenPlantaService(INotaIngresoAlmacenPlantaRepository NotaIngresoAlmacenPlantaRepository, INotaIngresoPlantaRepository notaIngresoPlantaRepository, ICorrelativoRepository correlativoRepository)
        {
            _INotaIngresoAlmacenPlantaRepository = NotaIngresoAlmacenPlantaRepository;
            _INotaIngresoPlantaRepository = notaIngresoPlantaRepository;
            _ICorrelativoRepository = correlativoRepository;
        }

        public int Registrar(EnviarAlmacenNotaIngresoPlantaRequestDTO request)
        {
            ConsultaNotaIngresoPlantaPorIdBE notaIngresoPlanta = _INotaIngresoPlantaRepository.ConsultarNotaIngresoPlantaPorId(request.NotaIngresoPlantaId);

            NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta = new NotaIngresoAlmacenPlanta();
            NotaIngresoAlmacenPlanta.NotaIngresoPlantaId = request.NotaIngresoPlantaId;

            NotaIngresoAlmacenPlanta.EmpresaId = notaIngresoPlanta.EmpresaId;
            NotaIngresoAlmacenPlanta.Numero = _ICorrelativoRepository.Obtener(notaIngresoPlanta.EmpresaId, Documentos.NotaIngresoAlmacenPlanta);
            NotaIngresoAlmacenPlanta.AlmacenId = null;
            NotaIngresoAlmacenPlanta.CertificacionId = notaIngresoPlanta.CertificacionId;
            NotaIngresoAlmacenPlanta.EntidadCertificadoraId = notaIngresoPlanta.EntidadCertificadoraId;
            NotaIngresoAlmacenPlanta.TipoProduccionId = notaIngresoPlanta.TipoProduccionId;
            NotaIngresoAlmacenPlanta.ProductoId = notaIngresoPlanta.ProductoId;
            NotaIngresoAlmacenPlanta.SubProductoId = notaIngresoPlanta.SubProductoId;
            NotaIngresoAlmacenPlanta.UnidadMedidaIdPesado = notaIngresoPlanta.EmpaqueId;
            NotaIngresoAlmacenPlanta.CantidadPesado = notaIngresoPlanta.Cantidad;
            NotaIngresoAlmacenPlanta.KilosBrutosPesado = notaIngresoPlanta.KilosBrutos;
            NotaIngresoAlmacenPlanta.TaraPesado = notaIngresoPlanta.Tara;
            NotaIngresoAlmacenPlanta.KilosNetosPesado = notaIngresoPlanta.KilosBrutos - notaIngresoPlanta.Tara;
   

            NotaIngresoAlmacenPlanta.ExportableGramosAnalisisFisico = notaIngresoPlanta.ExportableGramosAnalisisFisico;
            //NotaIngresoAlmacenPlanta.ExportableGramosAnalisisFisico = (notaIngresoPlanta.ExportableGramosAnalisisFisico.HasValue) ? notaIngresoPlanta.ExportableGramosAnalisisFisico.Value : 0;


            NotaIngresoAlmacenPlanta.ExportablePorcentajeAnalisisFisico = notaIngresoPlanta.ExportablePorcentajeAnalisisFisico;
            NotaIngresoAlmacenPlanta.DescarteGramosAnalisisFisico = notaIngresoPlanta.DescarteGramosAnalisisFisico;
            NotaIngresoAlmacenPlanta.DescartePorcentajeAnalisisFisico = notaIngresoPlanta.DescartePorcentajeAnalisisFisico;
            NotaIngresoAlmacenPlanta.CascarillaGramosAnalisisFisico = notaIngresoPlanta.CascarillaGramosAnalisisFisico;
            NotaIngresoAlmacenPlanta.CascarillaPorcentajeAnalisisFisico = notaIngresoPlanta.CascarillaPorcentajeAnalisisFisico;
            NotaIngresoAlmacenPlanta.TotalGramosAnalisisFisico = notaIngresoPlanta.TotalGramosAnalisisFisico;

            //NotaIngresoAlmacenPlanta.TotalGramosAnalisisFisico = (notaIngresoPlanta.TotalGramosAnalisisFisico.HasValue) ? notaIngresoPlanta.TotalGramosAnalisisFisico.Value : 0;

            NotaIngresoAlmacenPlanta.TotalPorcentajeAnalisisFisico = notaIngresoPlanta.TotalPorcentajeAnalisisFisico;
            NotaIngresoAlmacenPlanta.TotalAnalisisSensorial = notaIngresoPlanta.TotalAnalisisSensorial;
            NotaIngresoAlmacenPlanta.HumedadPorcentajeAnalisisFisico = notaIngresoPlanta.HumedadPorcentajeAnalisisFisico;


            NotaIngresoAlmacenPlanta.ExportablePorcentajeAnalisisFisico = notaIngresoPlanta.ExportablePorcentajeAnalisisFisico;

            if (notaIngresoPlanta.TotalGramosAnalisisFisico.HasValue && notaIngresoPlanta.TotalGramosAnalisisFisico.Value >0)
            {
                NotaIngresoAlmacenPlanta.RendimientoPorcentaje = (notaIngresoPlanta.ExportableGramosAnalisisFisico / notaIngresoPlanta.TotalGramosAnalisisFisico) * 100;
            }
            else
            {
                NotaIngresoAlmacenPlanta.RendimientoPorcentaje = 0;

            }
                
            
            //NotaIngresoAlmacenPlanta.Observacion = guiaRecepcionMateriaPrima.Observacion;
            NotaIngresoAlmacenPlanta.UsuarioRegistro = request.Usuario;
            NotaIngresoAlmacenPlanta.FechaRegistro = DateTime.Now;
            NotaIngresoAlmacenPlanta.EstadoId = NotaIngresoPlantaEstados.Pesado;
            NotaIngresoAlmacenPlanta.PesoporSaco = notaIngresoPlanta.PesoPorSaco;




            int affected = _INotaIngresoAlmacenPlantaRepository.Insertar(NotaIngresoAlmacenPlanta);

            _INotaIngresoPlantaRepository.ActualizarEstado(request.NotaIngresoPlantaId, DateTime.Now, request.Usuario, NotaIngresoPlantaEstados.EnviadoAlmacen);

            return affected;
        }

        public List<ConsultaNotaIngresoAlmacenPlantaBE> ConsultarNotaIngresoAlmacenPlanta(ConsultaNotaIngresoAlmacenPlantaRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });

            //if (string.IsNullOrEmpty(request.EstadoId))
            //    throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });

            var list = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlanta(request);
            return list.ToList();
        }

        //public int AnularNotaIngresoAlmacenPlanta(AnularNotaIngresoAlmacenPlantaRequestDTO request)
        //{
        //    ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(request.NotaIngresoAlmacenPlantaId);

        //    int affected = 0;

        //    if (consultaNotaIngresoAlmacenPlantaPorIdBE != null)
        //    {
        //        affected = _INotaIngresoAlmacenPlantaRepository.ActualizarEstado(request.NotaIngresoAlmacenPlantaId, DateTime.Now, request.Usuario, LoteEstados.Anulado);

        //        _IGuiaRecepcionMateriaPrimaRepository.ActualizarEstado(consultaNotaIngresoAlmacenPlantaPorIdBE.GuiaRecepcionMateriaPrimaId, DateTime.Now, request.Usuario, GuiaRecepcionMateriaPrimaEstados.Analizado);

        //    }

        //    return affected;
        //}

        public int ActualizarNotaIngresoAlmacenPlanta(ActualizarNotaIngresoAlmacenPlantaRequestDTO request)
        {
            int affected = 0;


            affected = _INotaIngresoAlmacenPlantaRepository.Actualizar(request.NotaIngresoAlmacenPlantaId, DateTime.Now, request.Usuario, request.AlmacenId);



            return affected;
        }

        public ConsultaNotaIngresoAlmacenPlantaPorIdBE ConsultarNotaIngresoAlmacenPlantaPorId(ConsultaNotaIngresoAlmacenPlantaPorIdRequestDTO request)
        {
            ConsultaNotaIngresoAlmacenPlantaPorIdBE consultaNotaIngresoAlmacenPlantaPorIdBE = _INotaIngresoAlmacenPlantaRepository.ConsultarNotaIngresoAlmacenPlantaPorId(request.NotaIngresoAlmacenPlantaId);


            return consultaNotaIngresoAlmacenPlantaPorIdBE;
        }
    }
}
