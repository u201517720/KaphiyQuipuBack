
using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adelanto;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public partial class NotaCompraService : INotaCompraService
    {
        private INotaCompraRepository _INotaCompraRepository;
        private IAdelantoRepository _IAdelantoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public NotaCompraService(INotaCompraRepository notaCompraRepository, IAdelantoRepository adelantoRepository, ICorrelativoRepository correlativoRepository)
        {
            _INotaCompraRepository = notaCompraRepository;
            _ICorrelativoRepository = correlativoRepository;
            _IAdelantoRepository = adelantoRepository;
        }

        public int RegistrarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request)
        {
            NotaCompra notaCompra = new NotaCompra();

            notaCompra.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            notaCompra.EmpresaId = request.EmpresaId;
            notaCompra.Numero = request.Numero;
            notaCompra.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaCompra);
            notaCompra.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            notaCompra.CantidadPesado = request.CantidadPesado;
            notaCompra.KilosBrutosPesado = request.KilosBrutosPesado;
            notaCompra.TaraPesado = request.TaraPesado;
            notaCompra.KilosNetosPesado = request.KilosNetosPesado;
            notaCompra.DescuentoPorHumedad = request.DescuentoPorHumedad;
            notaCompra.KilosNetosDescontar = request.KilosNetosDescontar;
            notaCompra.KilosNetosPagar = request.KilosNetosPagar;
            notaCompra.QQ55 = request.QQ55;
            notaCompra.TipoId = request.TipoId;
            notaCompra.MonedaId = request.MonedaId;
            notaCompra.PrecioGuardado = request.PrecioGuardado;
            notaCompra.PrecioPagado = request.PrecioPagado;
            notaCompra.Importe = request.Importe;
            notaCompra.EstadoId = NotaCompraEstados.PorLiquidar;
            notaCompra.FechaRegistro = DateTime.Now;
            notaCompra.UsuarioRegistro = request.UsuarioNotaCompra;
            notaCompra.Observaciones = request.Observaciones;
            notaCompra.ValorId = request.ValorId;

            int affected = _INotaCompraRepository.Insertar(notaCompra);

            return affected;
        }

        public int ActualizarNotaCompra(RegistrarActualizarNotaCompraRequestDTO request)
        {
            NotaCompra notaCompra = new NotaCompra();

            notaCompra.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            notaCompra.NotaCompraId = request.NotaCompraId;
            notaCompra.EmpresaId = request.EmpresaId;
            notaCompra.Numero = request.Numero;
            notaCompra.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            notaCompra.CantidadPesado = request.CantidadPesado;
            notaCompra.KilosBrutosPesado = request.KilosBrutosPesado;
            notaCompra.TaraPesado = request.TaraPesado;
            notaCompra.KilosNetosPesado = request.KilosNetosPesado;
            notaCompra.DescuentoPorHumedad = request.DescuentoPorHumedad;
            notaCompra.KilosNetosDescontar = request.KilosNetosDescontar;
            notaCompra.KilosNetosPagar = request.KilosNetosPagar;
            notaCompra.QQ55 = request.QQ55;
            notaCompra.TipoId = request.TipoId;
            notaCompra.MonedaId = request.MonedaId;
            notaCompra.PrecioGuardado = request.PrecioGuardado;
            notaCompra.PrecioPagado = request.PrecioPagado;
            notaCompra.Importe = request.Importe;
            notaCompra.EstadoId = NotaCompraEstados.PorLiquidar;
            notaCompra.FechaUltimaActualizacion = DateTime.Now;
            notaCompra.UsuarioUltimaActualizacion = request.UsuarioNotaCompra;
            notaCompra.Observaciones = request.Observaciones;
            notaCompra.ValorId = request.ValorId;

            int affected = _INotaCompraRepository.Actualizar(notaCompra);

            return affected;
        }


        public int LiquidarNotaCompra(LiquidarNotaCompraRequestDTO request)
        {
            List<ConsultaAdelantoBE> _adelantos = _IAdelantoRepository.ConsultarAdelantosPorNotaCompra(request.NotaCompraId, AdelantoEstados.PorLiquidar).ToList();

            if (_adelantos.Count > 0)
            {
                decimal montoAdelanto = _adelantos.Sum(x => x.Monto);
                request.TotalAdelanto = montoAdelanto;
            }

            if (!request.TotalAdelanto.HasValue)
            {
                request.TotalAdelanto = 0;

            }

            request.TotalPagar = request.Importe - request.TotalAdelanto.Value;



            int affected = _INotaCompraRepository.Liquidar(request.NotaCompraId, DateTime.Now, request.Usuario, NotaCompraEstados.Liquidado, request.MonedaId, request.PrecioPagado, request.Importe, request.TotalAdelanto, request.TotalPagar);

            if (_adelantos.Count > 0)
            {
                _IAdelantoRepository.ActualizarEstadoPorNotaCompra(request.NotaCompraId, DateTime.Now, request.Usuario, AdelantoEstados.Liquidado);
            }

            return affected;
        }

      

    }
}
