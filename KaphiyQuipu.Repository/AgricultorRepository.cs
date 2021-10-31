using Dapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KaphiyQuipu.Repository
{
    public class AgricultorRepository : IAgricultorRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public AgricultorRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaAgricultorDTO> Consultar(ConsultaAgricultorRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", request.TipoCertificacionId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaAgricultorDTO>("uspConsultaAgricultoresPorTipoCertificacion", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
