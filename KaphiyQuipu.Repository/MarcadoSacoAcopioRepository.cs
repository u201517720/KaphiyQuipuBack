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
    public class MarcadoSacoAcopioRepository: IMarcadoSacoAcopioRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public MarcadoSacoAcopioRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public string Registrar(MarcadoSacoAcopio marcado)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", marcado.Correlativo);
            parameters.Add("@pOrdenProcesoId", marcado.OrdenProcesoId);
            parameters.Add("@pUsuarioRegistro", marcado.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", marcado.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspGenerarMarcadoSacosAcopio", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
