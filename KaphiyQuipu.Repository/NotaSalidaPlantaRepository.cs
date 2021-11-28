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

        public IEnumerable<ConsultarNotaSalidaPlantaDTO> Consultar(DateTime fechaInicio, DateTime fechaFin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", fechaInicio);
            parameters.Add("@pFechaFin", fechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarNotaSalidaPlantaDTO>("uspConsultarNotasSalidaPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarPorIdNotaSalidaPlantaDTO> ConsultarPorId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pId", id);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarPorIdNotaSalidaPlantaDTO>("uspConsultarNotasSalidaPlantaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
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
