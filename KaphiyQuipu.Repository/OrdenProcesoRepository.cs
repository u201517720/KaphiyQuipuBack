﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KaphiyQuipu.Repository
{
    public class OrdenProcesoRepository : IOrdenProcesoRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public OrdenProcesoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Actualizar(OrdenProceso ordenProceso)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoId", ordenProceso.OrdenProcesoId);
            parameters.Add("@EmpresaId", ordenProceso.EmpresaId);
            parameters.Add("@EmpresaProcesadoraId", ordenProceso.EmpresaProcesadoraId);
            parameters.Add("@ContratoId", ordenProceso.ContratoId);
            parameters.Add("@Numero", ordenProceso.Numero);
            parameters.Add("@TipoProcesoId", ordenProceso.TipoProcesoId);
            parameters.Add("@Observacion", ordenProceso.Observacion);
            parameters.Add("@RendimientoEsperadoPorcentaje", ordenProceso.RendimientoEsperadoPorcentaje);
            parameters.Add("@NombreArchivo", ordenProceso.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ordenProceso.DescripcionArchivo);
            parameters.Add("@PathArchivo", ordenProceso.PathArchivo);
            parameters.Add("@FechaFinProceso", ordenProceso.FechaFinProceso);
            parameters.Add("@CantidadContenedores", ordenProceso.CantidadContenedores);
            parameters.Add("@FechaUltimaActualizacion", ordenProceso.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", ordenProceso.UsuarioUltimaActualizacion);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenProcesoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public int Anular(int ordenProcesoId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoId", ordenProcesoId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspOrdenProcesoAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public IEnumerable<ConsultaOrdenProcesoBE> ConsultarOrdenProceso(ConsultaOrdenProcesoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);
            parameters.Add("@NumeroContrato", request.NumeroContrato);
            parameters.Add("@NumeroCliente", request.NumeroCliente);
            parameters.Add("@RazonSocialCliente", request.RazonSocialCliente);
            parameters.Add("@RucEmpresaProcesadora", request.RucEmpresaProcesadora);
            parameters.Add("@RazonSocialEmpresaProcesadora", request.RazonSocialEmpresaProcesadora);
            parameters.Add("@TipoProcesoId", request.TipoProcesoId);
            parameters.Add("@EstadoId", request.EstadoId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFinal);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaOrdenProcesoBE>("uspOrdenProcesoConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<OrdenProcesoDetalle> ConsultarOrdenProcesoDetallePorId(int ordenProcesoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoId", ordenProcesoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenProcesoDetalle>("uspOrdenProcesoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(OrdenProceso ordenProceso)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", ordenProceso.EmpresaId);
            parameters.Add("@EmpresaProcesadoraId", ordenProceso.EmpresaProcesadoraId);
            parameters.Add("@ContratoId", ordenProceso.ContratoId);
            parameters.Add("@Numero", ordenProceso.Numero);
            parameters.Add("@Observacion", ordenProceso.Observacion);
            parameters.Add("@RendimientoEsperadoPorcentaje", ordenProceso.RendimientoEsperadoPorcentaje);
            parameters.Add("@FechaFinProceso", ordenProceso.FechaFinProceso);
            parameters.Add("@CantidadContenedores", ordenProceso.CantidadContenedores);
            parameters.Add("@TipoProcesoId", ordenProceso.TipoProcesoId);
            parameters.Add("@NombreArchivo", ordenProceso.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ordenProceso.DescripcionArchivo);
            parameters.Add("@PathArchivo", ordenProceso.PathArchivo);
            parameters.Add("@EstadoId", ordenProceso.EstadoId);
            parameters.Add("@FechaRegistro", ordenProceso.FechaRegistro);
            parameters.Add("@UsuarioRegistro", ordenProceso.UsuarioRegistro);
            parameters.Add("@OrdenProcesoId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspOrdenProcesoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("OrdenProcesoId");
            return id;
        }

        public int InsertarProcesoDetalle(OrdenProcesoDetalle ordenProcesoDetalle)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@FechaNotaIngresoPlanta", ordenProcesoDetalle.FechaNotaIngresoPlanta);
            parameters.Add("@OrdenProcesoId", ordenProcesoDetalle.OrdenProcesoId);
            parameters.Add("@NroNotaIngresoPlanta", ordenProcesoDetalle.NroNotaIngresoPlanta);
            parameters.Add("@RendimientoPorcentaje", ordenProcesoDetalle.RendimientoPorcentaje);
            parameters.Add("@HumedadPorcentaje", ordenProcesoDetalle.HumedadPorcentaje);
            parameters.Add("@CantidadSacos", ordenProcesoDetalle.CantidadSacos);
            parameters.Add("@KilosBrutos", ordenProcesoDetalle.KilosBrutos);
            parameters.Add("@Tara", ordenProcesoDetalle.Tara);
            parameters.Add("@KilosNetos", ordenProcesoDetalle.KilosNetos);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspOrdenProcesoDetalleInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int EliminarProcesoDetalle(int ordenProcesoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoId", ordenProcesoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspOrdenProcesoDetalleEliminar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public ConsultaOrdenProcesoPorIdBE ConsultarOrdenProcesoPorId(int ordenProcesoId)
        {
            ConsultaOrdenProcesoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@pOrdenProcesoId", ordenProcesoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaOrdenProcesoPorIdBE>("uspOrdenProcesoConsultarPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
                itemBE.detalle = ConsultarOrdenProcesoDetallePorId(ordenProcesoId);
            }
            return itemBE;
        }

        public IEnumerable<OrdenProcesoDTO> ConsultarImpresionOrdenProceso(int ordenProcesoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pOrdenProcesoId", ordenProcesoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenProcesoDTO>("uspOrdenProcesoConsultaImpresionPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
