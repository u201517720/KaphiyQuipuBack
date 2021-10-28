using CoffeeConnect.Repository;
using Dapper;
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
    public class SolicitudCompraRepository : ISolicitudCompraRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public SolicitudCompraRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insertar(SolicitudCompra solicitudCompra)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@pDistribuidorId", solicitudCompra.DistribuidorId);
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
            parameters.Add("@pObservaciones", solicitudCompra.Observaciones);
            parameters.Add("@pUsuarioRegistro", solicitudCompra.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", DateTime.Now);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspRegistrarSolicitudCompra", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
