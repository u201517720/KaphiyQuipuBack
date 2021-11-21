using Dapper;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KaphiyQuipu.Repository
{
    public class GuiaRemisionAcopioRepository : IGuiaRemisionAcopioRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public GuiaRemisionAcopioRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
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

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspGenerarGuiaRemisionAcopio", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
