using Dapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KaphiyQuipu.Repository
{
    public class GuiaRemisionAcopioRepository : IGuiaRemisionAcopioRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public GuiaRemisionAcopioRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultarGuiaRemisionAcopioDTO> Consultar(DateTime fechaInicio, DateTime fechaFin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", fechaInicio);
            parameters.Add("@pFechaFin", fechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarGuiaRemisionAcopioDTO>("uspConsultarGuiasRemisionAcopio", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarPorCorrelativoGuiaRemisionDTO> ConsultarPorCorrelativo(string correlativo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", correlativo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarPorCorrelativoGuiaRemisionDTO>("uspConsultarGuiaRemisionPorCorrelativo", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarPorIdGuiaRemisionAcopioDTO> ConsultarPorId(int id)
        {
            IEnumerable<ConsultarPorIdGuiaRemisionAcopioDTO> itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarPorIdGuiaRemisionAcopioDTO>("uspObtenerGuiaRemisionAcopioPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public string Registrar(GuiaRemisionAcopio request)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", request.Correlativo);
            parameters.Add("@pOrdenProcesoId", request.OrdenProcesoId);
            parameters.Add("@pFechaTraslado", request.FechaRegistro);
            parameters.Add("@pFechaEmision", request.FechaRegistro);
            parameters.Add("@pUsuarioRegistro", request.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", request.FechaRegistro);
            parameters.Add("@pHashBC", request.HashBC);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspGenerarGuiaRemisionAcopio", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public string RegistrarDevolucion(GuiaRemisionDevolucion guia)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", guia.Correlativo);
            parameters.Add("@pNotaIngresoDevolucionId", guia.NotaIngresoDevolucionId);
            parameters.Add("@pFechaTraslado", guia.FechaTraslado);
            parameters.Add("@pFechaEmision", guia.FechaEmision);
            parameters.Add("@pHashBC", guia.HashBC);
            parameters.Add("@pUsuarioRegistro", guia.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", guia.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspGenerarGuiaRemisionDevolucion", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
