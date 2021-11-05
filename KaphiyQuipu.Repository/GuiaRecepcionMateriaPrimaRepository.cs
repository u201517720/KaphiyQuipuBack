﻿using KaphiyQuipu.DTO;
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
    public class GuiaRecepcionMateriaPrimaRepository : IGuiaRecepcionMateriaPrimaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public GuiaRecepcionMateriaPrimaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int AnularGuiaRecepcionMateriaPrima(int guiaRecepcionMateriaPrimaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspGuiaRecepcionMateriaPrimaAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int ActualizarPesado(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrima.GuiaRecepcionMateriaPrimaId);
            parameters.Add("@NumeroReferencia", guiaRecepcionMateriaPrima.NumeroReferencia);
            parameters.Add("@EmpresaId", guiaRecepcionMateriaPrima.EmpresaId);
            parameters.Add("@TipoProvedorId", guiaRecepcionMateriaPrima.TipoProvedorId);
            parameters.Add("@SocioId", guiaRecepcionMateriaPrima.SocioId);
            parameters.Add("@TerceroId", guiaRecepcionMateriaPrima.TerceroId);
            parameters.Add("@IntermediarioId", guiaRecepcionMateriaPrima.IntermediarioId);
            parameters.Add("@ProductoId", guiaRecepcionMateriaPrima.ProductoId);
            parameters.Add("@SubProductoId", guiaRecepcionMateriaPrima.SubProductoId);
            parameters.Add("@FechaCosecha", guiaRecepcionMateriaPrima.FechaCosecha);
            parameters.Add("@FechaPesado", guiaRecepcionMateriaPrima.FechaPesado);
            parameters.Add("@UsuarioPesado", guiaRecepcionMateriaPrima.UsuarioPesado);
            parameters.Add("@UnidadMedidaIdPesado", guiaRecepcionMateriaPrima.UnidadMedidaIdPesado);
            parameters.Add("@CantidadPesado", guiaRecepcionMateriaPrima.CantidadPesado);
            parameters.Add("@KilosBrutosPesado", guiaRecepcionMateriaPrima.KilosBrutosPesado);
            parameters.Add("@TaraPesado", guiaRecepcionMateriaPrima.TaraPesado);
            parameters.Add("@ObservacionPesado", guiaRecepcionMateriaPrima.ObservacionPesado);
            parameters.Add("@EstadoId", guiaRecepcionMateriaPrima.EstadoId);
            parameters.Add("@SocioFincaId", guiaRecepcionMateriaPrima.SocioFincaId);
            parameters.Add("@TerceroFincaId", guiaRecepcionMateriaPrima.TerceroFincaId);
            parameters.Add("@IntermediarioFinca", guiaRecepcionMateriaPrima.IntermediarioFinca);
            parameters.Add("@KilosNetosPesado", guiaRecepcionMateriaPrima.KilosNetosPesado);
            parameters.Add("@FechaUltimaActualizacion", guiaRecepcionMateriaPrima.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", guiaRecepcionMateriaPrima.UsuarioUltimaActualizacion);
            parameters.Add("@TipoProduccionId", guiaRecepcionMateriaPrima.TipoProduccionId);
            parameters.Add("@SocioFincaCertificacion", guiaRecepcionMateriaPrima.SocioFincaCertificacion);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaPesadoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }



            return result;
        }


        public int InsertarPesado(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", guiaRecepcionMateriaPrima.EmpresaId);
            parameters.Add("@Numero", guiaRecepcionMateriaPrima.Numero);
            parameters.Add("@NumeroReferencia", guiaRecepcionMateriaPrima.NumeroReferencia);
            parameters.Add("@TipoProvedorId", guiaRecepcionMateriaPrima.TipoProvedorId);
            parameters.Add("@SocioId", guiaRecepcionMateriaPrima.SocioId);
            parameters.Add("@TerceroId", guiaRecepcionMateriaPrima.TerceroId);
            parameters.Add("@IntermediarioId", guiaRecepcionMateriaPrima.IntermediarioId);
            parameters.Add("@ProductoId", guiaRecepcionMateriaPrima.ProductoId);
            parameters.Add("@SubProductoId", guiaRecepcionMateriaPrima.SubProductoId);
            parameters.Add("@FechaCosecha", guiaRecepcionMateriaPrima.FechaCosecha);
            parameters.Add("@FechaPesado", guiaRecepcionMateriaPrima.FechaPesado);
            parameters.Add("@UsuarioPesado", guiaRecepcionMateriaPrima.UsuarioPesado);
            parameters.Add("@UnidadMedidaIdPesado", guiaRecepcionMateriaPrima.UnidadMedidaIdPesado);
            parameters.Add("@ContratoAsignadoId", guiaRecepcionMateriaPrima.ContratoAsignadoId);
            

            parameters.Add("@CantidadPesado", guiaRecepcionMateriaPrima.CantidadPesado);
            parameters.Add("@KilosBrutosPesado", guiaRecepcionMateriaPrima.KilosBrutosPesado);
            parameters.Add("@KilosNetosPesado", guiaRecepcionMateriaPrima.KilosNetosPesado);
            parameters.Add("@TaraPesado", guiaRecepcionMateriaPrima.TaraPesado);
            parameters.Add("@ObservacionPesado", guiaRecepcionMateriaPrima.ObservacionPesado);
            parameters.Add("@EstadoId", guiaRecepcionMateriaPrima.EstadoId);
            parameters.Add("@SocioFincaId", guiaRecepcionMateriaPrima.SocioFincaId);
            parameters.Add("@TerceroFincaId", guiaRecepcionMateriaPrima.TerceroFincaId);
            parameters.Add("@IntermediarioFinca", guiaRecepcionMateriaPrima.IntermediarioFinca);
            parameters.Add("@SocioFincaCertificacion", guiaRecepcionMateriaPrima.SocioFincaCertificacion);


            parameters.Add("@FechaRegistro", guiaRecepcionMateriaPrima.FechaRegistro);
            parameters.Add("@UsuarioRegistro", guiaRecepcionMateriaPrima.UsuarioRegistro);
            parameters.Add("@TipoProduccionId", guiaRecepcionMateriaPrima.TipoProduccionId);

            parameters.Add("@GuiaRecepcionMateriaPrimaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaPesadoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("GuiaRecepcionMateriaPrimaId");

            return id;
        }

        public int ActualizarAnalisisCalidad(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrima.GuiaRecepcionMateriaPrimaId);
            parameters.Add("@ExportableGramosAnalisisFisico", guiaRecepcionMateriaPrima.ExportableGramosAnalisisFisico);
            parameters.Add("@ExportablePorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.ExportablePorcentajeAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", guiaRecepcionMateriaPrima.DescarteGramosAnalisisFisico);
            parameters.Add("@DescartePorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.DescartePorcentajeAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", guiaRecepcionMateriaPrima.CascarillaGramosAnalisisFisico);
            parameters.Add("@CascarillaPorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.CascarillaPorcentajeAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", guiaRecepcionMateriaPrima.TotalGramosAnalisisFisico);
            parameters.Add("@TotalPorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.TotalPorcentajeAnalisisFisico);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@TotalAnalisisSensorial", guiaRecepcionMateriaPrima.TotalAnalisisSensorial);

            parameters.Add("@SubTotalAnalisisSensorial", guiaRecepcionMateriaPrima.SubTotalAnalisisSensorial);
            parameters.Add("@DefectosTasaAnalisisSensorial", guiaRecepcionMateriaPrima.DefectosTasaAnalisisSensorial);
            parameters.Add("@DefectosIntensidadAnalisisSensorial", guiaRecepcionMateriaPrima.DefectosIntensidadAnalisisSensorial);


            parameters.Add("@ObservacionAnalisisFisico", guiaRecepcionMateriaPrima.ObservacionAnalisisFisico);
            parameters.Add("@FechaCalidad", guiaRecepcionMateriaPrima.FechaCalidad);
            parameters.Add("@UsuarioCalidad", guiaRecepcionMateriaPrima.UsuarioCalidad);
            parameters.Add("@ObservacionRegistroTostado", guiaRecepcionMateriaPrima.ObservacionRegistroTostado);
            parameters.Add("@ObservacionAnalisisSensorial", guiaRecepcionMateriaPrima.ObservacionAnalisisSensorial);
            parameters.Add("@EstadoId", guiaRecepcionMateriaPrima.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", guiaRecepcionMateriaPrima.FechaCalidad);
            parameters.Add("@UsuarioUltimaActualizacion", guiaRecepcionMateriaPrima.UsuarioCalidad);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaCalidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetallePorId(int guiaRecepcionMateriaPrimaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetallePorId(int guiaRecepcionMateriaPrimaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetallePorId(int guiaRecepcionMateriaPrimaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);


            }


        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetallePorId(int guiaRecepcionMateriaPrimaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetallePorId(int guiaRecepcionMateriaPrimaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetallePorId(int guiaRecepcionMateriaPrimaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle> ConsultarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetallePorId(int guiaRecepcionMateriaPrimaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle>("uspGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle(List<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo> request, int GuiaRecepcionMateriaPrimaId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRecepcionMateriaPrimaId", GuiaRecepcionMateriaPrimaId);
            parameters.Add("@GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle(List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo> request, int GuiaRecepcionMateriaPrimaId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRecepcionMateriaPrimaId", GuiaRecepcionMateriaPrimaId);
            parameters.Add("@GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle(List<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo> request, int GuiaRecepcionMateriaPrimaId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRecepcionMateriaPrimaId", GuiaRecepcionMateriaPrimaId);
            parameters.Add("@GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar

        }
        public int ActualizarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle(List<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo> request, int GuiaRecepcionMateriaPrimaId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRecepcionMateriaPrimaId", GuiaRecepcionMateriaPrimaId);
            parameters.Add("@GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle(List<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo> request, int GuiaRecepcionMateriaPrimaId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRecepcionMateriaPrimaId", GuiaRecepcionMateriaPrimaId);
            parameters.Add("@GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle(List<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleTipo> request, int GuiaRecepcionMateriaPrimaId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRecepcionMateriaPrimaId", GuiaRecepcionMateriaPrimaId);
            parameters.Add("@GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle(List<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo> request, int GuiaRecepcionMateriaPrimaId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRecepcionMateriaPrimaId", GuiaRecepcionMateriaPrimaId);
            parameters.Add("@GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }


        public int ActualizarEstado(int guiaRecepcionMateriaPrimaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspGuiaRecepcionMateriaPrimaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }
    }


}
