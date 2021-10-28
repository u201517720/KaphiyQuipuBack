﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KaphiyQuipu.Repository
{
    public class NotaCompraRepository : INotaCompraRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaCompraRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insertar(NotaCompra notaCompra)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", notaCompra.GuiaRecepcionMateriaPrimaId);
            parameters.Add("@EmpresaId", notaCompra.EmpresaId);
            parameters.Add("@Numero", notaCompra.Numero);
            parameters.Add("@UnidadMedidaIdPesado", notaCompra.UnidadMedidaIdPesado);
            parameters.Add("@CantidadPesado", notaCompra.CantidadPesado);
            parameters.Add("@KilosBrutosPesado", notaCompra.KilosBrutosPesado);
            parameters.Add("@TaraPesado", notaCompra.TaraPesado);
            parameters.Add("@KilosNetosPesado", notaCompra.KilosNetosPesado);
            parameters.Add("@DescuentoPorHumedad", notaCompra.DescuentoPorHumedad);
            parameters.Add("@KilosNetosDescontar", notaCompra.KilosNetosDescontar);
            parameters.Add("@KilosNetosPagar", notaCompra.KilosNetosPagar);
            parameters.Add("@QQ55", notaCompra.QQ55);
            parameters.Add("@TipoId", notaCompra.TipoId);
            parameters.Add("@MonedaId", notaCompra.MonedaId);
            parameters.Add("@ValorId", notaCompra.ValorId);
            parameters.Add("@PrecioPagado", notaCompra.PrecioPagado);
            parameters.Add("@PrecioGuardado", notaCompra.PrecioGuardado);
            parameters.Add("@Importe", notaCompra.Importe);
            parameters.Add("@EstadoId", notaCompra.EstadoId);
            parameters.Add("@FechaRegistro", notaCompra.FechaRegistro);
            parameters.Add("@UsuarioRegistro", notaCompra.UsuarioRegistro);
            parameters.Add("@Observaciones", notaCompra.Observaciones);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaCompraInsertar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        public int Actualizar(NotaCompra notaCompra)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaCompraId", notaCompra.NotaCompraId);
            parameters.Add("@GuiaRecepcionMateriaPrimaId", notaCompra.GuiaRecepcionMateriaPrimaId);
            parameters.Add("@EmpresaId", notaCompra.EmpresaId);
            parameters.Add("@Numero", notaCompra.Numero);
            parameters.Add("@UnidadMedidaIdPesado", notaCompra.UnidadMedidaIdPesado);
            parameters.Add("@CantidadPesado", notaCompra.CantidadPesado);
            parameters.Add("@KilosBrutosPesado", notaCompra.KilosBrutosPesado);
            parameters.Add("@TaraPesado", notaCompra.TaraPesado);
            parameters.Add("@KilosNetosPesado", notaCompra.KilosNetosPesado);
            parameters.Add("@DescuentoPorHumedad", notaCompra.DescuentoPorHumedad);
            parameters.Add("@KilosNetosDescontar", notaCompra.KilosNetosDescontar);
            parameters.Add("@KilosNetosPagar", notaCompra.KilosNetosPagar);
            parameters.Add("@QQ55", notaCompra.QQ55);
            parameters.Add("@ValorId", notaCompra.ValorId);
            parameters.Add("@TipoId", notaCompra.TipoId);
            parameters.Add("@MonedaId", notaCompra.MonedaId);
            parameters.Add("@PrecioPagado", notaCompra.PrecioPagado);
            parameters.Add("@PrecioGuardado", notaCompra.PrecioGuardado);
            parameters.Add("@Importe", notaCompra.Importe);
            parameters.Add("@EstadoId", notaCompra.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", notaCompra.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", notaCompra.UsuarioUltimaActualizacion);
            parameters.Add("@Observaciones", notaCompra.Observaciones);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaCompraActualizar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        public int Anular(int notaCompraId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaCompraId", notaCompraId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaCompraAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int Liquidar(int notaCompraId, DateTime fecha, string usuario, string estadoId, string monedaId, decimal precioPagado, decimal importe, decimal? totalAdelanto, decimal totalPagar)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaCompraId", notaCompraId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);
            parameters.Add("@MonedaId", monedaId);
            parameters.Add("@PrecioPagado", precioPagado);
            parameters.Add("@Importe", importe);
            parameters.Add("@TotalAdelanto", totalAdelanto);
            parameters.Add("@TotalPagar", totalPagar);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaCompraLiquidar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public IEnumerable<ConsultaNotaCompraBE> ConsultarNotaCompra(ConsultaNotaCompraRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroGuiaRecepcion", request.NumeroGuiaRecepcion);
            parameters.Add("NombreRazonSocial", request.NombreRazonSocial);
            parameters.Add("TipoDocumentoId", request.TipoDocumentoId);
            parameters.Add("NumeroDocumento", request.NumeroDocumento);
            parameters.Add("CodigoSocio", request.CodigoSocio);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("TipoId", request.TipoId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaCompraBE>("uspNotaCompraConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdBE ConsultarNotaCompraPorGuiaRecepcionMateriaPrimaId(int guiaRecepcionMateriaPrimaId)
        {
            ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaNotaCompraPorGuiaRecepcionMateriaPrimaIdBE>("uspNotaCompraConsultaPorGuiaRecepcionMateriaPrimaId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public ConsultaImpresionNotaCompraPorGuiaRecepcionMateriaPrimaIdBE ConsultarImpresionNotaCompraPorGuiaRecepcionMateriaPrimaId(int guiaRecepcionMateriaPrimaId)
        {
            ConsultaImpresionNotaCompraPorGuiaRecepcionMateriaPrimaIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaImpresionNotaCompraPorGuiaRecepcionMateriaPrimaIdBE>("uspNotaCompraConsultaImpresionPorGuiaRecepcionMateriaPrimaId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public ConsultaNotaCompraPorIdBE ConsultarNotaCompraPorId(int notaCompraId)
        {
            ConsultaNotaCompraPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("NotaCompraId", notaCompraId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaNotaCompraPorIdBE>("uspNotaCompraObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

    }
}
