using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Core.Utils;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KaphiyQuipu.Repository
{
    public class NotaIngresoPlantaRepository : INotaIngresoPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaIngresoPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int AnularNotaIngresoPlanta(int NotaIngresoPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoPlantaAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

  

        public IEnumerable<NotaIngresoPlantaAnalisisFisicoColorDetalle> ConsultarNotaIngresoPlantaAnalisisFisicoColorDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoPlantaAnalisisFisicoColorDetalle>("uspNotaIngresoPlantaAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<NotaIngresoPlantaAnalisisFisicoOlorDetalle> ConsultarNotaIngresoPlantaAnalisisFisicoOlorDetallePorId(int NotaIngresoPlantaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoPlantaAnalisisFisicoOlorDetalle>("uspNotaIngresoPlantaAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public IEnumerable<NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalle> ConsultarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetallePorId(int NotaIngresoPlantaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalle>("uspNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);


            }


        }

        public IEnumerable<NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalle> ConsultarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalle>("uspNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<NotaIngresoPlantaAnalisisSensorialAtributoDetalle> ConsultarNotaIngresoPlantaAnalisisSensorialAtributoDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoPlantaAnalisisSensorialAtributoDetalle>("uspNotaIngresoPlantaAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NotaIngresoPlantaAnalisisSensorialDefectoDetalle> ConsultarNotaIngresoPlantaAnalisisSensorialDefectoDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoPlantaAnalisisSensorialDefectoDetalle>("uspNotaIngresoPlantaAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NotaIngresoPlantaRegistroTostadoIndicadorDetalle> ConsultarNotaIngresoPlantaRegistroTostadoIndicadorDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoPlantaRegistroTostadoIndicadorDetalle>("uspNotaIngresoPlantaRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarNotaIngresoPlantaAnalisisFisicoColorDetalle(List<NotaIngresoPlantaAnalisisFisicoColorDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisFisicoColorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalle(List<NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalle(List<NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar

        }
        public int ActualizarNotaIngresoPlantaAnalisisFisicoOlorDetalle(List<NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisFisicoOlorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarNotaIngresoPlantaAnalisisSensorialAtributoDetalle(List<NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisSensorialAtributoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarNotaIngresoPlantaAnalisisSensorialDefectoDetalle(List<NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisSensorialDefectoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarNotaIngresoPlantaRegistroTostadoIndicadorDetalle(List<NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaRegistroTostadoIndicadorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }


        public int ActualizarEstado(int NotaIngresoPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }
    }


}
