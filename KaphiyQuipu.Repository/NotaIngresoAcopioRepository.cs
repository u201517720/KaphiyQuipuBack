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
    public class NotaIngresoAcopioRepository : INotaIngresoAcopioRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public NotaIngresoAcopioRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaNotaIngresoAcopioDTO> Consultar(ConsultaNotaIngresoAcopioRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", request.FechaInicio);
            parameters.Add("@pFechaFinal", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaIngresoAcopioDTO>("uspObtenerNotasIngresoAcopio", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaPorIdNotaIngresoAcopioDTO> ConsultarPorId(int notaIngresoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pNotaIngresoAcopioId", notaIngresoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaPorIdNotaIngresoAcopioDTO>("uspObtenerIngresoAlmacenAcopioPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaPorIdNotaIngresoAcopioAgricultoresDTO> ObtenerAgricultores(int notaIngresoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pNotaIngresoAcopioId", notaIngresoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaPorIdNotaIngresoAcopioAgricultoresDTO>("uspObtenerAgricultoresPorNotaIngresoAcopioId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaPorIdNotaIngresoAcopioControlCalidadDTO> ObtenerControlesCalidad(int notaIngresoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pNotaIngresoAcopioId", notaIngresoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaPorIdNotaIngresoAcopioControlCalidadDTO>("uspObtenerControlesCalidadPorNotaIngresoAcopioId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public string Registrar(NotaIngresoAlmacenAcopio nota)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", nota.Correlativo);
            parameters.Add("@pGuiaRecepcionId", nota.GuiaRecepcionId);
            parameters.Add("@pUsuarioRegistro", nota.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", nota.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspRegistrarNotaIngresoAcopio", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public void UbicarMateriaPrimaAlmacen(UbicarMateriaPrimaAlmacenRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pNotaIngresoAcopioId", request.NotaIngresoAcopioId);
            parameters.Add("@pAlmacenId", request.AlmacenId);
            parameters.Add("@pUsuario", request.Usuario);
            parameters.Add("@pFecha", request.Fecha);
            parameters.Add("@pHashBC", request.HashBC);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspUbicarMateriaPrimaEnAlmacen", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
