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
    public class NotaSalidaPlantaRepository: INotaSalidaPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public NotaSalidaPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public string Registrar(NotaSalidaPlanta salida)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", salida.Correlativo);
            parameters.Add("@pNotaIngresoPlantaId", salida.NotaIngresoPlantaId);
            parameters.Add("@pUsuarioRegistro", salida.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", salida.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspGenerarNotaSalidaPlanta", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
