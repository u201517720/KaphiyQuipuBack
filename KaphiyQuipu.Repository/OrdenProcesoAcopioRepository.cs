using Dapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KaphiyQuipu.Repository
{
    public class OrdenProcesoAcopioRepository: IOrdenProcesoAcopioRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public OrdenProcesoAcopioRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public void ActualizarTipoProceso(int ordenProcesoId, string tipoProceso, string usuario, DateTime fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pOrdenProcesoId", ordenProcesoId);
            parameters.Add("@pTipoProceso", tipoProceso);
            parameters.Add("@pUsuario", usuario);
            parameters.Add("@pFecha", fecha);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspActualizarOrdenProcesoAcopio", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarOrdenProcesoAcopioDTO> Consultar(DateTime fechaInicio, DateTime fechaFin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", fechaInicio);
            parameters.Add("@pFechaFin", fechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarOrdenProcesoAcopioDTO>("uspConsultarOrdenProcesoAcopio", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarPorIdOrdenProcesoDTO> ConsultarPorId(int ordenProcesoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pOrdenProcesoId", ordenProcesoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarPorIdOrdenProcesoDTO>("uspConsultarOrdenProcesoAcopioPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public string Registrar(OrdenProcesoAcopio ordenProceso)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", ordenProceso.Correlativo);
            parameters.Add("@pNotaIngresoAcopioId", ordenProceso.NotaIngresoAcopioId);
            parameters.Add("@pUsuarioRegistro", ordenProceso.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", ordenProceso.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspRegistrarOrdenProceso", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
