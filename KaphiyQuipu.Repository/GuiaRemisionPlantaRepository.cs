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
    public class GuiaRemisionPlantaRepository : IGuiaRemisionPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public GuiaRemisionPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public string Registrar(GuiaRemisionPlanta guia)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", guia.Correlativo);
            parameters.Add("@pNotaSalidaPlantaId", guia.NotaSalidaPlantaId);
            parameters.Add("@pHashBC", guia.HashBC);
            parameters.Add("@pUsuarioRegistro", guia.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", guia.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspGenerarGuiaRemisionPlanta", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
