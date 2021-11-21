using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KaphiyQuipu.Repository
{
    public class EmpresaTransporteRepository : IEmpresaTransporteRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public EmpresaTransporteRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<EmpresaTransporteBE> ConsultarEmpresaTransporte(ConsultaEmpresaTransporteRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("EstadoId", request.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<EmpresaTransporteBE>("uspEmpresaTransporteConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaTransportistaBE> ConsultarTransportista(ConsultaTransportistaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("EmpresaId", request.EmpresaId );
            parameters.Add("EstadoId", request.EstadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaTransportistaBE>("uspTransportistaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaEmpresaTransportePorIdBE ConsultarEmpresaTransportePorId(int empresaTransporteId)
        {
            ConsultaEmpresaTransportePorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaTransporteId", empresaTransporteId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaEmpresaTransportePorIdBE>("uspEmpresaTransporteConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarEmpresaTransporte(ConsultaEmpresaTransporteDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@Ruc", request.Ruc);
            parameters.Add("@RazonSocial", request.RazonSocial);
            parameters.Add("@EstadoId", request.EstadoId);         


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaProductoPrecioDiaBE>("uspEmpresaTransporteConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
