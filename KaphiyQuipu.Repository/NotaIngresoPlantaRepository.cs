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
    public class NotaIngresoPlantaRepository: INotaIngresoPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public NotaIngresoPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaNotaIngresoPlantaDTO> Consultar(DateTime fechaInicio, DateTime fechaFin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", fechaInicio);
            parameters.Add("@pFechaFin", fechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaIngresoPlantaDTO>("uspConsultarNotasIngresosPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarPorIdNotaIngresoPlantaDTO> ConsultarPorId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarPorIdNotaIngresoPlantaDTO>("uspConsultarNotaIngresoPlantaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public string Registrar(NotaIngresoPlanta nota)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", nota.Correlativo);
            parameters.Add("@pGuiaRemisionAcopioId", nota.GuiaRemisionAcopioId);
            parameters.Add("@pObservaciones", nota.Observaciones);
            parameters.Add("@pUsuarioRegistro", nota.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", nota.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspGenerarNotaIngresoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
