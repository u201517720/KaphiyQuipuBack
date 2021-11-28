using Dapper;
using KaphiyQuipu.DTO;
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

        public IEnumerable<ConsultarGuiaRemisionPlantaDTO> Consultar(DateTime fechaInicio, DateTime fechaFin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", fechaInicio);
            parameters.Add("@pFechaFin", fechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarGuiaRemisionPlantaDTO>("uspConsultarGuiaRemisionPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarCorrelativoGuiaRemisionPlantaDTO> ConsultarCorrelativo(string correlativo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", correlativo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarCorrelativoGuiaRemisionPlantaDTO>("uspConsultarGuiaRemisionPlantaPorCorrelativo", parameters, commandType: CommandType.StoredProcedure);
            }
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
