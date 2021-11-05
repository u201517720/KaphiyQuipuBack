using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using Core.Common;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KaphiyQuipu.Repository
{
    public class InspeccionInternaRepository : IInspeccionInternaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public InspeccionInternaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }



        public int ActualizarInspeccionInternaParcela(List<InspeccionInternaParcelaTipo> request, int inspeccionInternaId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@InspeccionInternaId", inspeccionInternaId);
            parameters.Add("@InspeccionInternaParcelaTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaParcelaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int ActualizarInspeccionInternaNormas(List<InspeccionInternaNormasTipo> request, int inspeccionInternaId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@InspeccionInternaId", inspeccionInternaId);
            parameters.Add("@InspeccionInternaNormasTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaNormasActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
            //uspLoteAnalisisFisicoColorDetalleActualizar
        }

        public int ActualizarInspeccionInternaLevantamientoNoConformidad(List<InspeccionInternaLevantamientoNoConformidadTipo> request, int inspeccionInternaId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@InspeccionInternaId", inspeccionInternaId);
            parameters.Add("@InspeccionInternaLevantamientoNoConformidadTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaLevantamientoNoConformidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int ActualizarInspeccionInternaNoConformidad(List<InspeccionInternaNoConformidadTipo> request, int inspeccionInternaId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@InspeccionInternaId", inspeccionInternaId);
            parameters.Add("@InspeccionInternaNoConformidadTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaNoConformidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<InspeccionInternaLevantamientoNoConformidad> ConsultarInspeccionInternaLevantamientoNoConformidadPorId(int inspeccionInternaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInternaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<InspeccionInternaLevantamientoNoConformidad>("uspInspeccionInternaLevantamientoNoConformidadConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<InspeccionInternaNoConformidad> ConsultarInspeccionInternaNoConformidadPorId(int inspeccionInternaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInternaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<InspeccionInternaNoConformidad>("uspInspeccionInternaNoConformidadConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<InspeccionInternaNorma> ConsultarInspeccionInternaNormasPorId(int inspeccionInternaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInternaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<InspeccionInternaNorma>("uspInspeccionInternaNormasConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<InspeccionInternaParcela> ConsultarInspeccionInternaParcelaPorId(int inspeccionInternaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInternaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<InspeccionInternaParcela>("uspInspeccionInternaParcelaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
