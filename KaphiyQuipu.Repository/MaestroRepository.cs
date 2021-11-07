﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KaphiyQuipu.Repository
{
    public class MaestroRepository : IMaestroRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public MaestroRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId, string idioma)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", empresaId);
            parameters.Add("Idioma", idioma);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaDetalleTablaBE>("uspDetalleCatalogoObtenerPorEmpresaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaUbigeoBE> ConsultaUbibeo()
        {
            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaUbigeoBE>("uspUbigeoConsulta", null, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Zona> ConsultarZona(string codigoDistrito)
        {
            var parameters = new DynamicParameters();
            parameters.Add("DistritoId", codigoDistrito);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<Zona>("uspZonaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaPaisBE> ConsultarPais()
        {
            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaPaisBE>("uspPaisConsulta", commandType: CommandType.StoredProcedure);
            }
        }

    }
}
