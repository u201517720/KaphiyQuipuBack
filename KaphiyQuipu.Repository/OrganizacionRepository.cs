﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KaphiyQuipu.Repository
{
    public class OrganizacionRepository : IOrganizacionRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public OrganizacionRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }




        public IEnumerable<ConsultaOrganizacionBE> ConsultarOrganizacion(ConsultaOrganizacionRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("ClasificacionId", request.ClasificacionId);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("Numero", request.CodigoOrganizacion);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaOrganizacionBE>("uspOrganizacionConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
