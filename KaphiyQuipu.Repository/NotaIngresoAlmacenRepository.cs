using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Core.Common;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KaphiyQuipu.Repository
{
    public class NotaIngresoAlmacenRepository : INotaIngresoAlmacenRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaIngresoAlmacenRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int Insertar(NotaIngresoAlmacen notaIngresoAlmacen)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", notaIngresoAlmacen.EmpresaId);
            parameters.Add("@AlmacenId", notaIngresoAlmacen.AlmacenId);
            parameters.Add("@GuiaRecepcionMateriaPrimaId", notaIngresoAlmacen.GuiaRecepcionMateriaPrimaId);
            parameters.Add("@Numero", notaIngresoAlmacen.Numero);
            parameters.Add("@TipoProduccionId", notaIngresoAlmacen.TipoProduccionId);

            parameters.Add("@TipoProvedorId", notaIngresoAlmacen.TipoProvedorId);
            parameters.Add("@SocioId", notaIngresoAlmacen.SocioId);
            parameters.Add("@TerceroId", notaIngresoAlmacen.TerceroId);
            parameters.Add("@IntermediarioId", notaIngresoAlmacen.IntermediarioId);
            parameters.Add("@ProductoId", notaIngresoAlmacen.ProductoId);
            parameters.Add("@SubProductoId", notaIngresoAlmacen.SubProductoId);
            parameters.Add("@UnidadMedidaIdPesado", notaIngresoAlmacen.UnidadMedidaIdPesado);
            parameters.Add("@CantidadPesado", notaIngresoAlmacen.CantidadPesado);
            parameters.Add("@KilosBrutosPesado", notaIngresoAlmacen.KilosBrutosPesado);
            parameters.Add("@TaraPesado", notaIngresoAlmacen.TaraPesado);
            parameters.Add("@KilosNetosPesado", notaIngresoAlmacen.KilosNetosPesado);
            parameters.Add("@QQ55", notaIngresoAlmacen.QQ55);
            parameters.Add("@ExportableGramosAnalisisFisico", notaIngresoAlmacen.ExportableGramosAnalisisFisico);
            parameters.Add("@ExportablePorcentajeAnalisisFisico", notaIngresoAlmacen.ExportablePorcentajeAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", notaIngresoAlmacen.DescarteGramosAnalisisFisico);
            parameters.Add("@DescartePorcentajeAnalisisFisico", notaIngresoAlmacen.DescartePorcentajeAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", notaIngresoAlmacen.CascarillaGramosAnalisisFisico);
            parameters.Add("@CascarillaPorcentajeAnalisisFisico", notaIngresoAlmacen.CascarillaPorcentajeAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", notaIngresoAlmacen.TotalGramosAnalisisFisico);
            parameters.Add("@TotalPorcentajeAnalisisFisico", notaIngresoAlmacen.TotalPorcentajeAnalisisFisico);
            parameters.Add("@TotalAnalisisSensorial", notaIngresoAlmacen.TotalAnalisisSensorial);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", notaIngresoAlmacen.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@Observacion", notaIngresoAlmacen.Observacion);
            parameters.Add("@RendimientoPorcentaje", notaIngresoAlmacen.RendimientoPorcentaje);
            parameters.Add("@EstadoId", notaIngresoAlmacen.EstadoId);
            parameters.Add("@FechaRegistro", notaIngresoAlmacen.FechaRegistro);
            parameters.Add("@UsuarioRegistro", notaIngresoAlmacen.UsuarioRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoAlmacenInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<NotaIngresoAlmacen> ConsultarNotaIngresoPorIds(List<TablaIdsTipo> request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TablaIdsTipo", request.ToDataTable().AsTableValuedParameter());


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoAlmacen>("uspNotaIngresoAlmacenConsultarPorIds", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public int ActualizarEstado(int notaIngresoAlmacenId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenId", notaIngresoAlmacenId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoAlmacenActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int Actualizar(int notaIngresoAlmacenId, DateTime fecha, string usuario, string almacenId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenId", notaIngresoAlmacenId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@AlmacenId", almacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoAlmacenActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@TablaIdsTipo", ids.ToDataTable().AsTableValuedParameter());
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoAlmacenActualizarEstadoPorIds", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

    }
}
