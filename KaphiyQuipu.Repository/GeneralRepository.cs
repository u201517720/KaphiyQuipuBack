using Dapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KaphiyQuipu.Repository
{
    public class GeneralRepository : IGeneralRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public GeneralRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultarDocumentoPagoDTO> ConsultarDocumentoPago(string correlativoDPA, string correlativoCC)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativoDPA", correlativoDPA);
            parameters.Add("@pCorrelativoCC", correlativoCC);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarDocumentoPagoDTO>("uspConsultarDocumentosPagos", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarDocumentoPagoPorIdDTO> ConsultarDocumentoPagoPorId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarDocumentoPagoPorIdDTO>("uspConsultarDocumentoPagoPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
