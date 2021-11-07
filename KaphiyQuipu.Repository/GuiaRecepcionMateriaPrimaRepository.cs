using Dapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KaphiyQuipu.Repository
{
    public class GuiaRecepcionMateriaPrimaRepository : IGuiaRecepcionMateriaPrimaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public GuiaRecepcionMateriaPrimaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaGuiaRecepcionMateriaPrimaDTO> Consultar(ConsultarGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", request.FechaInicio);
            parameters.Add("@pFechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaGuiaRecepcionMateriaPrimaDTO>("uspObtenerGuiasRecepcion", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
