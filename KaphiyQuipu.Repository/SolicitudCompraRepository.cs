using KaphiyQuipu.Repository;
using Dapper;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using KaphiyQuipu.DTO;
using System.Linq;

namespace KaphiyQuipu.Repository
{
    public class SolicitudCompraRepository : ISolicitudCompraRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public SolicitudCompraRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaSolicitudCompraDTO> Consultar(ConsultaSolicitudCompraRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", request.FechaInicio);
            parameters.Add("@pFechaFin", request.FechaFin);
            parameters.Add("@pUsuarioId", request.UsuarioId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaSolicitudCompraDTO>("uspSolicitudCompraConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaSolicitudCompraPorIdDTO ConsultarPorId(int solicitudCompraId)
        {
            ConsultaSolicitudCompraPorIdDTO itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@pSolicitudCompraId", solicitudCompraId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaSolicitudCompraPorIdDTO>("uspSolicitudCompraConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public string Insertar(SolicitudCompra solicitudCompra)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pDistribuidorId", solicitudCompra.DistribuidorId);
            parameters.Add("@pCorrelativo", solicitudCompra.Correlativo);
            parameters.Add("@pPaisId", solicitudCompra.PaisId);
            parameters.Add("@pDepartamentoId", solicitudCompra.DepartamentoId);
            parameters.Add("@pMonedaId", solicitudCompra.MonedaId);
            parameters.Add("@pUnidadMedidaId", solicitudCompra.UnidadMedidaId);
            parameters.Add("@pTipoProduccionId", solicitudCompra.TipoProduccionId);
            parameters.Add("@pEmpaqueId", solicitudCompra.EmpaqueId);
            parameters.Add("@pTipoEmpaqueId", solicitudCompra.TipoEmpaqueId);
            parameters.Add("@pTotalSacos", solicitudCompra.TotalSacos);
            parameters.Add("@pPesoSaco", solicitudCompra.PesoSaco);
            parameters.Add("@pPesoKilos", solicitudCompra.PesoKilos);
            parameters.Add("@pProductoId", solicitudCompra.ProductoId);
            parameters.Add("@pSubProductoId", solicitudCompra.SubProductoId);
            parameters.Add("@pGradoPreparacionId", solicitudCompra.GradoPreparacionId);
            parameters.Add("@pCalidadId", solicitudCompra.CalidadId);
            parameters.Add("@pCertificacionId", solicitudCompra.CertificacionId);
            parameters.Add("@pObservaciones", solicitudCompra.Observaciones);
            parameters.Add("@pUsuarioRegistro", solicitudCompra.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", DateTime.Now);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspRegistrarSolicitudCompra", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
