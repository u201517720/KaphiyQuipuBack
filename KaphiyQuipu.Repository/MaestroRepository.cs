using KaphiyQuipu.DTO;
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

        public IEnumerable<ConsultarTransportistaDTO> ConsultarTransportista(int id, string codigo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pIdProceso", id);
            parameters.Add("@pCodigo", codigo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarTransportistaDTO>("uspConsultarTransportistas", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultarResponsableDTO> ConsultarResponsable(ConsultarResponsableRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pTipo", request.Tipo);
            parameters.Add("@pNombre", request.Nombre);
            parameters.Add("@pNroDoc", request.Documento);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarResponsableDTO>("uspConsultarResponsables", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<TipoCambio> ObtenerTipoCambio()
        {
            var parameters = new DynamicParameters();

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<TipoCambio>("uspObtenerTipoCambio", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
