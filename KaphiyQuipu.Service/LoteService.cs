
using AutoMapper;
using Core.Common.Domain.Model;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaphiyQuipu.Service
{
    public partial class LoteService : ILoteService
    {
        private readonly IMapper _Mapper;
        private ILoteRepository _ILoteRepository;
        private INotaIngresoAlmacenRepository _INotaIngresoAlmacenRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public LoteService(ILoteRepository loteRepository, INotaIngresoAlmacenRepository notaIngresoAlmacenRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _ILoteRepository = loteRepository;
            _INotaIngresoAlmacenRepository = notaIngresoAlmacenRepository;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public int GenerarLote(GenerarLoteRequestDTO request)
        {
            Lote lote = new Lote();
            lote.EmpresaId = request.EmpresaId;
            lote.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.Lote);
            lote.EstadoId = LoteEstados.Ingresado;
            lote.AlmacenId = request.AlmacenId;
            lote.FechaRegistro = DateTime.Now;
            lote.UsuarioRegistro = request.Usuario;
            lote.ProductoId = request.ProductoId;
            lote.SubProductoId = request.SubProductoId;
            lote.TipoCertificacionId = request.TipoCertificacionId;

            int loteId = 0;

            decimal totalKilosNetosPesado = 0;
            decimal totalKilosBrutosPesado = 0;
            decimal totalCantidad = 0;
            string unidadMedidaId = String.Empty;
            decimal totalRendimientoPorcentaje = 0;
            decimal totalAnalisisSensorial = 0;
            decimal totalHumedadPorcentaje = 0;
            string tipoProduccionId = String.Empty;

            List<NotaIngresoAlmacen> notasIngreso = _INotaIngresoAlmacenRepository.ConsultarNotaIngresoPorIds(request.NotasIngresoAlmacenId).ToList();

            if (notasIngreso != null)
            {

                List<LoteDetalle> lotesDetalle = new List<LoteDetalle>();

                notasIngreso.ForEach(notaingreso =>
                {
                    LoteDetalle item = new LoteDetalle();
                    item.LoteId = loteId;
                    item.NotaIngresoAlmacenId = notaingreso.NotaIngresoAlmacenId;
                    item.Numero = notaingreso.Numero;
                    item.TipoProvedorId = notaingreso.TipoProvedorId;
                    item.SocioId = notaingreso.SocioId;
                    item.TerceroId = notaingreso.TerceroId;
                    item.IntermediarioId = notaingreso.IntermediarioId;
                    item.ProductoId = notaingreso.ProductoId;
                    item.SubProductoId = notaingreso.SubProductoId;
                    item.UnidadMedidaIdPesado = notaingreso.UnidadMedidaIdPesado;
                    item.CantidadPesado = notaingreso.CantidadPesado;
                    item.KilosNetosPesado = notaingreso.KilosNetosPesado;
                    item.KilosBrutosPesado = notaingreso.KilosBrutosPesado;
                    item.RendimientoPorcentaje = notaingreso.RendimientoPorcentaje;
                    item.HumedadPorcentaje = notaingreso.HumedadPorcentajeAnalisisFisico;
                    item.TotalAnalisisSensorial = notaingreso.TotalAnalisisSensorial.Value;


                    item.NotaIngresoAlmacenId = notaingreso.NotaIngresoAlmacenId;
                    totalKilosNetosPesado = totalKilosNetosPesado + item.KilosNetosPesado;
                    totalKilosBrutosPesado = totalKilosBrutosPesado + item.KilosBrutosPesado;
                    totalRendimientoPorcentaje = totalRendimientoPorcentaje + item.RendimientoPorcentaje.Value;
                    totalAnalisisSensorial = totalAnalisisSensorial + item.TotalAnalisisSensorial;
                    totalHumedadPorcentaje = totalHumedadPorcentaje + item.HumedadPorcentaje;
                    totalCantidad = totalCantidad + item.CantidadPesado;
                    unidadMedidaId = item.UnidadMedidaIdPesado;
                    tipoProduccionId = notaingreso.TipoProduccionId;
                    lotesDetalle.Add(item);
                });


                lote.TotalKilosNetosPesado = totalKilosNetosPesado;
                lote.TotalKilosBrutosPesado = totalKilosBrutosPesado;
                //lote.PromedioRendimientoPorcentaje = totalRendimientoPorcentaje / lotesDetalle.Count;
                //lote.PromedioHumedadPorcentaje = totalHumedadPorcentaje / lotesDetalle.Count;
                lote.UnidadMedidaId = unidadMedidaId;
                lote.TipoProduccionId = tipoProduccionId;
                //lote.PromedioTotalAnalisisSensorial = totalAnalisisSensorial / lotesDetalle.Count;

                lote.Cantidad = totalCantidad;

                loteId = _ILoteRepository.Insertar(lote);

                lotesDetalle.ForEach(loteDetalle =>
                {
                    loteDetalle.LoteId = loteId;

                });

                int affected = _ILoteRepository.InsertarLoteDetalle(lotesDetalle);

                notasIngreso.ForEach(notaingreso =>
                {
                    _INotaIngresoAlmacenRepository.ActualizarEstado(notaingreso.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Lotizado);
                });

            }

            return loteId;
        }


        public List<ConsultaLoteBE> ConsultarLote(ConsultaLoteRequestDTO request)
        {

            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.NotaCompra.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.NotaCompra.ValidacionRangoFechaMayor2anios.Label" });

            var list = _ILoteRepository.ConsultarLote(request);

            return list.ToList();
        }

        public int AnularLote(AnularLoteRequestDTO request)
        {
            int affected = _ILoteRepository.ActualizarEstado(request.LoteId, DateTime.Now, request.Usuario, LoteEstados.Anulado);

            List<LoteDetalle> lotesDetalle = _ILoteRepository.ConsultarLoteDetallePorLoteId(request.LoteId).ToList();

            lotesDetalle.ForEach(loteDetalle =>
            {
                _INotaIngresoAlmacenRepository.ActualizarEstado(loteDetalle.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Ingresado);
            });

            return affected;
        }

        public int ActualizarLote(ActualizarLoteRequestDTO request)
        {
            int affected = _ILoteRepository.Actualizar(request.LoteId, DateTime.Now, request.Usuario, request.AlmacenId, request.Cantidad, request.TotalKilosNetosPesado, request.TotalKilosBrutosPesado, request.ContratoId);

            if (request.NotasIngresoAlmacenId != null && request.NotasIngresoAlmacenId.Count > 0)
            {
                List<ListaIdsAccion> notasIngresoAlmacenIdEliminar = request.NotasIngresoAlmacenId.Where(a => a.Accion == "E").ToList();

                if (notasIngresoAlmacenIdEliminar != null && notasIngresoAlmacenIdEliminar.Count > 0)
                {
                    List<TablaIdsTipo> loteDetalleIdEliminar = new List<TablaIdsTipo>();
                    List<TablaIdsTipo> notasIntegresoIdActualizar = new List<TablaIdsTipo>();

                    foreach (ListaIdsAccion id in notasIngresoAlmacenIdEliminar)
                    {
                        TablaIdsTipo tablaIdsTipo = new TablaIdsTipo();
                        tablaIdsTipo.Id = id.Id;
                        loteDetalleIdEliminar.Add(tablaIdsTipo);


                        LoteDetalle loteDetalle = _ILoteRepository.ConsultarLoteDetallePorId(id.Id);

                        if (loteDetalle != null)
                        {
                            TablaIdsTipo tablaNotasIntegresoIdsTipo = new TablaIdsTipo();
                            tablaNotasIntegresoIdsTipo.Id = loteDetalle.NotaIngresoAlmacenId;
                            notasIntegresoIdActualizar.Add(tablaNotasIntegresoIdsTipo);

                        }
                    }

                    _ILoteRepository.EliminarLoteDetalle(loteDetalleIdEliminar);

                    _INotaIngresoAlmacenRepository.ActualizarEstadoPorIds(notasIntegresoIdActualizar, DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Ingresado);
                }

                List<ListaIdsAccion> notasIngresoAlmacenIdNuevo = request.NotasIngresoAlmacenId.Where(a => a.Accion == "N").ToList();

                if (notasIngresoAlmacenIdNuevo != null && notasIngresoAlmacenIdNuevo.Count > 0)
                {

                    List<TablaIdsTipo> notasIngresoAlmacenIdConsulta = new List<TablaIdsTipo>();

                    foreach (ListaIdsAccion id in notasIngresoAlmacenIdNuevo)
                    {
                        TablaIdsTipo tablaIdsTipo = new TablaIdsTipo();
                        tablaIdsTipo.Id = id.Id;
                        notasIngresoAlmacenIdConsulta.Add(tablaIdsTipo);
                    }

                    List<NotaIngresoAlmacen> notasIngreso = _INotaIngresoAlmacenRepository.ConsultarNotaIngresoPorIds(notasIngresoAlmacenIdConsulta).ToList();

                    if (notasIngreso != null && notasIngreso.Count > 0)
                    {

                        List<LoteDetalle> lotesDetalle = new List<LoteDetalle>();

                        notasIngreso.ForEach(notaingreso =>
                        {
                            LoteDetalle item = new LoteDetalle();
                            item.LoteId = request.LoteId;
                            item.NotaIngresoAlmacenId = notaingreso.NotaIngresoAlmacenId;
                            item.Numero = notaingreso.Numero;
                            item.TipoProvedorId = notaingreso.TipoProvedorId;
                            item.SocioId = notaingreso.SocioId;
                            item.TerceroId = notaingreso.TerceroId;
                            item.IntermediarioId = notaingreso.IntermediarioId;
                            item.ProductoId = notaingreso.ProductoId;
                            item.SubProductoId = notaingreso.SubProductoId;
                            item.UnidadMedidaIdPesado = notaingreso.UnidadMedidaIdPesado;
                            item.CantidadPesado = notaingreso.CantidadPesado;
                            item.KilosNetosPesado = notaingreso.KilosNetosPesado;
                            item.KilosBrutosPesado = notaingreso.KilosBrutosPesado;
                            item.RendimientoPorcentaje = notaingreso.RendimientoPorcentaje;
                            item.HumedadPorcentaje = notaingreso.HumedadPorcentajeAnalisisFisico;
                            item.TotalAnalisisSensorial = notaingreso.TotalAnalisisSensorial.Value;


                            item.NotaIngresoAlmacenId = notaingreso.NotaIngresoAlmacenId;
                            //totalKilosNetosPesado = totalKilosNetosPesado + item.KilosNetosPesado;
                            //totalKilosBrutosPesado = totalKilosBrutosPesado + item.KilosBrutosPesado;
                            //totalRendimientoPorcentaje = totalRendimientoPorcentaje + item.RendimientoPorcentaje.Value;
                            //totalAnalisisSensorial = totalAnalisisSensorial + item.TotalAnalisisSensorial;
                            //totalHumedadPorcentaje = totalHumedadPorcentaje + item.HumedadPorcentaje;
                            //totalCantidad = totalCantidad + item.CantidadPesado;
                            //unidadMedidaId = item.UnidadMedidaIdPesado;

                            lotesDetalle.Add(item);
                        });


                        /*
                        lote.TotalKilosNetosPesado = totalKilosNetosPesado;
                        lote.TotalKilosBrutosPesado = totalKilosBrutosPesado;
                        //lote.PromedioRendimientoPorcentaje = totalRendimientoPorcentaje / lotesDetalle.Count;
                        //lote.PromedioHumedadPorcentaje = totalHumedadPorcentaje / lotesDetalle.Count;
                        lote.UnidadMedidaId = unidadMedidaId;
                        //lote.PromedioTotalAnalisisSensorial = totalAnalisisSensorial / lotesDetalle.Count;

                        lote.Cantidad = totalCantidad;

                        loteId = _ILoteRepository.Insertar(lote);



                        

                        */

                        _ILoteRepository.InsertarLoteDetalle(lotesDetalle);

                        notasIngreso.ForEach(notaingreso =>
                        {
                            _INotaIngresoAlmacenRepository.ActualizarEstado(notaingreso.NotaIngresoAlmacenId, DateTime.Now, request.Usuario, NotaIngresoAlmacenEstados.Lotizado);
                        });
                    }

                }
            }

            return affected;
        }

        public List<LoteDetalleConsulta> ConsultaLoteDetalleBusquedaPorLoteId(ConsultaLoteDetalleBusquedaPorLoteIdRequestDTO request)
        {
            var resultado = _ILoteRepository.ConsultarBandejaLoteDetallePorId(request.LoteId).ToList();

            return resultado;
        }

        public ConsultaLoteBandejaBE ConsultarLotePorId(ConsultaLoteDetallePorLoteIdRequestDTO request)
        {

            ConsultaLoteBandejaBE response = _ILoteRepository.ConsultarLotePorId(request.LoteId);
            //ConsultaLoteBandejaBE response = new ConsultaLoteBandejaBE();
            //ConsultaLoteBandejaBE response= _Mapper.Map<ConsultaLoteBandejaBE>(Lote);
            IEnumerable<LoteDetalleConsulta> resultado = _ILoteRepository.ConsultarBandejaLoteDetallePorId(request.LoteId);

            //response.LoteId = Lote.LoteId;
            //response.Numero = Lote.Numero;
            //response.EmpresaId = Lote.EmpresaId;
            //response.RazonSocial = Lote.RazonSocial;
            //response.Ruc = Lote.Ruc;
            //response.Direccion = Lote.Direccion;
            //response.Logo = Lote.Logo;
            //response.DepartamentoId = Lote.DepartamentoId;
            //response.Departamento = Lote.Departamento;
            //response.ProvinciaId = Lote.ProvinciaId;
            //response.Provincia = Lote.Provincia;
            //response.DistritoId = Lote.DistritoId;
            //response.Distrito = Lote.Distrito;
            //response.EstadoId = Lote.EstadoId;
            //response.Estado = Lote.Estado;
            //response.AlmacenId = Lote.AlmacenId;
            //response.Almacen = Lote.Almacen;
            //response.UnidadMedidaId = Lote.UnidadMedidaId;
            //response.UnidadMedida = Lote.UnidadMedida;
            //response.Cantidad = Lote.Cantidad;
            //response.TotalKilosNetosPesado = Lote.TotalKilosBrutosPesado;
            //response.TotalKilosBrutosPesado = Lote.TotalKilosBrutosPesado;
            //response.PromedioRendimientoPorcentaje = Lote.PromedioRendimientoPorcentaje;
            //response.PromedioHumedadPorcentaje = Lote.PromedioHumedadPorcentaje;
            //response.PromedioTotalAnalisisSensorial = Lote.PromedioTotalAnalisisSensorial;
            //response.FechaRegistro = Lote.FechaRegistro;
            //response.UsuarioRegistro = Lote.UsuarioRegistro;
            //response.FechaUltimaActualizacion = Lote.FechaUltimaActualizacion;
            //response.UsuarioUltimaActualizacion = Lote.UsuarioUltimaActualizacion;
            //response.Activo = Lote.Activo;
            //response.PromedioTotalAnalisisSensorial = Lote.PromedioTotalAnalisisSensorial;
            //response.ProductoId = Lote.ProductoId;
            //response.Producto = Lote.Producto;
            //response.SubProductoId = Lote.SubProductoId;
            //response.SubProducto = Lote.SubProducto;
            //response.TipoCertificacionId = Lote.TipoCertificacionId;
            //response.TipoCertificacion = Lote.TipoCertificacion;

            response.listaDetalle = resultado.ToList();

            response.AnalisisFisicoColorDetalle = _ILoteRepository.ConsultarLoteAnalisisFisicoColorDetallePorId(request.LoteId);
            response.AnalisisFisicoDefectoPrimarioDetalle = _ILoteRepository.ConsultarLoteAnalisisFisicoDefectoPrimarioDetallePorId(request.LoteId);
            response.AnalisisFisicoDefectoSecundarioDetalle = _ILoteRepository.ConsultarLoteAnalisisFisicoDefectoSecundarioDetallePorId(request.LoteId);
            response.AnalisisFisicoOlorDetalle = _ILoteRepository.ConsultarLoteAnalisisFisicoOlorDetallePorId(request.LoteId);
            response.AnalisisSensorialAtributoDetalle = _ILoteRepository.ConsultarLoteAnalisisSensorialAtributoDetallePorId(request.LoteId);
            response.AnalisisSensorialDefectoDetalle = _ILoteRepository.ConsultarLoteAnalisisSensorialDefectoDetallePorId(request.LoteId);
            response.RegistroTostadoIndicadorDetalle = _ILoteRepository.ConsultarLoteRegistroTostadoIndicadorDetallePorId(request.LoteId).ToList();



            //if (resultado.Any())
            //{
            //    response.TotalPesoNeto = resultado.Sum(x => x.KilosNetosPesado);
            //    response.PromedioHumedad = resultado.Average(x => x.HumedadPorcentaje);
            //    response.PromedioRendimiento = resultado.Average(x => x.RendimientoPorcentaje);
            //}
            //response.LoteId = request.LoteId;

            return response;
        }

    }
}
