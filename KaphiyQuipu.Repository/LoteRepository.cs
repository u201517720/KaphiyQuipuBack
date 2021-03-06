using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Core.Utils;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KaphiyQuipu.Repository
{
    public class LoteRepository : ILoteRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public LoteRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int InsertarLoteDetalle(List<LoteDetalle> request)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteDetalleTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteDetalleInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int EliminarLoteDetalle(List<TablaIdsTipo> request)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@TablaIdsTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteDetalleEliminarPorIds", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<ConsultaLoteBE> ConsultarLote(ConsultaLoteRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroContrato", request.NumeroContrato);
            parameters.Add("NombreRazonSocial", request.NombreRazonSocial);
            parameters.Add("TipoDocumentoId", request.TipoDocumentoId);
            parameters.Add("NumeroDocumento", request.NumeroDocumento);
            parameters.Add("CodigoSocio", request.CodigoSocio);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("TipoCertificacionId", request.TipoCertificacionId);
            parameters.Add("SubProductoId", request.SubProductoId);
            parameters.Add("AlmacenId", request.AlmacenId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaLoteBE>("uspLoteConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public IEnumerable<LoteDetalle> ConsultarLoteDetallePorLoteId(int loteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("LoteId", loteId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteDetalle>("uspLoteDetalleConsultaPorLoteId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarEstado(int loteId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", loteId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspLoteActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@TablaIdsTipo", ids.ToDataTable().AsTableValuedParameter());
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspLoteActualizarEstadoPorIds", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public IEnumerable<LoteDetalleConsulta> ConsultarBandejaLoteDetallePorId(int loteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("LoteId", loteId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteDetalleConsulta>("uspLotesDetalleConsultarBandejaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaLoteBandejaBE ConsultarLotePorId(int loteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("LoteId", loteId);

            IEnumerable<ConsultaLoteBandejaBE> result;
            ConsultaLoteBandejaBE lote = new ConsultaLoteBandejaBE();

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Query<ConsultaLoteBandejaBE>("uspLotesConsultarPorId", parameters, commandType: CommandType.StoredProcedure);
                if (result.Any())
                {
                    lote = result.First();
                }
            }

            return lote;
        }

        public LoteDetalle ConsultarLoteDetallePorId(int loteDetalleId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("LoteDetalleId", loteDetalleId);

            IEnumerable<LoteDetalle> result;
            LoteDetalle loteDetalle = new LoteDetalle();

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Query<LoteDetalle>("uspLoteDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
                if (result.Any())
                {
                    loteDetalle = result.First();
                }
            }

            return loteDetalle;
        }

        public int Actualizar(int loteId, DateTime fecha, string usuario, string almacenId, int cantidad, decimal totalKilosNetosPesado, decimal totalKilosBrutosPesado,int? contratoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", loteId);
            parameters.Add("@ContratoId", contratoId);
            
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@AlmacenId", almacenId);
            parameters.Add("@Cantidad", cantidad);
            parameters.Add("@TotalKilosNetosPesado", totalKilosNetosPesado);
            parameters.Add("@TotalKilosBrutosPesado", totalKilosBrutosPesado);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspLoteActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

  

        public IEnumerable<LoteRegistroTostadoIndicadorDetalle> ConsultarLoteRegistroTostadoIndicadorDetallePorId(int LoteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", LoteId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteRegistroTostadoIndicadorDetalle>("uspLoteRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }




        public int ActualizarLoteRegistroTostadoIndicadorDetalle(List<LoteRegistroTostadoIndicadorDetalleTipo> request, int LoteId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteId", LoteId);
            parameters.Add("@LoteRegistroTostadoIndicadorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteRegistroTostadoIndicadorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }


    }



}
