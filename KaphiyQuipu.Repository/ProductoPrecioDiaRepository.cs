﻿using KaphiyQuipu.DTO;
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
    public class ProductoPrecioDiaRepository : IProductoPrecioDiaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public ProductoPrecioDiaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDia(ConsultaProductoPrecioDiaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("SubProductoId", request.SubProductoId);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaProductoPrecioDiaBE>("uspProductoPrecioDiaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDiaPorEmpresaId(int empresaID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", empresaID);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaProductoPrecioDiaBE>("uspProductoPrecioDiaConsultaPorEmpresaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDiaPorSubProductoIdPorEmpresaId(int empresaID, string subProductoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", empresaID);
            parameters.Add("SubProductoId", subProductoId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaProductoPrecioDiaBE>("uspProductoPrecioDiaConsultaPorSubProductoIdPorEmpresaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(ProductoPrecioDia productoPrecioDia)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", productoPrecioDia.EmpresaId);
            parameters.Add("@ProductoId", productoPrecioDia.ProductoId);
            parameters.Add("@MonedaId", productoPrecioDia.MonedaId);
            parameters.Add("@SubProductoId", productoPrecioDia.SubProductoId);
            parameters.Add("@Fecha", productoPrecioDia.Fecha);
            parameters.Add("@PrecioDia", productoPrecioDia.PrecioDia);
            parameters.Add("@FechaRegistro", productoPrecioDia.FechaRegistro);
            parameters.Add("@UsuarioRegistro", productoPrecioDia.UsuarioRegistro);
            parameters.Add("@EstadoId", productoPrecioDia.EstadoId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspProductoPrecioDiaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        public int Actualizar(ProductoPrecioDia productoPrecioDia)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ProductoPrecioDiaId", productoPrecioDia.ProductoPrecioDiaId);
            parameters.Add("@EmpresaId", productoPrecioDia.EmpresaId);
            parameters.Add("@ProductoId", productoPrecioDia.ProductoId);
            parameters.Add("@SubProductoId", productoPrecioDia.SubProductoId);
            parameters.Add("@MonedaId", productoPrecioDia.MonedaId);
            parameters.Add("@Fecha", productoPrecioDia.Fecha);
            parameters.Add("@PrecioDia", productoPrecioDia.PrecioDia);
            parameters.Add("@FechaUltimaActualizacion", productoPrecioDia.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", productoPrecioDia.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", productoPrecioDia.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspProductoPrecioDiaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaProductoPrecioDiaPorIdBE ConsultarProductoPrecioDiaPorId(int ProductoPrecioDiaId)
        {
            ConsultaProductoPrecioDiaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@ProductoPrecioDiaId", ProductoPrecioDiaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaProductoPrecioDiaPorIdBE>("uspProductoPrecioDiaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
