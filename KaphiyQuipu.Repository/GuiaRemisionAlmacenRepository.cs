﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Core.Common;
using Core.Utils;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KaphiyQuipu.Repository
{
    public class GuiaRemisionAlmacenRepository : IGuiaRemisionAlmacenRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public GuiaRemisionAlmacenRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int Insertar(GuiaRemisionAlmacen guiaRemisionAlmacen)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", guiaRemisionAlmacen.NotaSalidaAlmacenId);
            parameters.Add("@Numero", guiaRemisionAlmacen.Numero);
            parameters.Add("@EmpresaId", guiaRemisionAlmacen.EmpresaId);
            parameters.Add("@AlmacenId", guiaRemisionAlmacen.AlmacenId);
            parameters.Add("@MotivoTrasladoId", guiaRemisionAlmacen.MotivoTrasladoId);
            parameters.Add("@MotivoTrasladoReferencia", guiaRemisionAlmacen.MotivoTrasladoReferencia);
            parameters.Add("@EmpresaIdDestino", guiaRemisionAlmacen.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", guiaRemisionAlmacen.EmpresaTransporteId);
            parameters.Add("@TransporteId", guiaRemisionAlmacen.TransporteId);
            parameters.Add("@MarcaTractorId", guiaRemisionAlmacen.MarcaTractorId);
            parameters.Add("@PlacaTractor", guiaRemisionAlmacen.PlacaTractor);
            parameters.Add("@MarcaCarretaId", guiaRemisionAlmacen.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", guiaRemisionAlmacen.PlacaCarreta);
            parameters.Add("@Conductor", guiaRemisionAlmacen.Conductor);
            parameters.Add("@Licencia", guiaRemisionAlmacen.Licencia);
            parameters.Add("@CantidadLotes", guiaRemisionAlmacen.CantidadLotes);
            parameters.Add("@NumeroConstanciaMTC", guiaRemisionAlmacen.NumeroConstanciaMTC);

            parameters.Add("@TipoProduccionId", guiaRemisionAlmacen.TipoProduccionId);
            parameters.Add("@TipoCertificacionId", guiaRemisionAlmacen.TipoCertificacionId);

            parameters.Add("@PromedioPorcentajeRendimiento", guiaRemisionAlmacen.PromedioPorcentajeRendimiento);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", guiaRemisionAlmacen.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@CantidadTotal", guiaRemisionAlmacen.CantidadTotal);
            parameters.Add("@PesoKilosBrutos", guiaRemisionAlmacen.PesoKilosBrutos);
            parameters.Add("@EstadoId", guiaRemisionAlmacen.EstadoId);
            parameters.Add("@FechaRegistro", guiaRemisionAlmacen.FechaRegistro);
            parameters.Add("@UsuarioRegistro", guiaRemisionAlmacen.UsuarioRegistro);
            parameters.Add("@GuiaRemisionAlmacenId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRemisionAlmacenInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            result = parameters.Get<int>("GuiaRemisionAlmacenId");


            return result;
        }

        public int Actualizar(GuiaRemisionAlmacen guiaRemisionAlmacen)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", guiaRemisionAlmacen.NotaSalidaAlmacenId);
            parameters.Add("@Numero", guiaRemisionAlmacen.Numero);
            parameters.Add("@EmpresaId", guiaRemisionAlmacen.EmpresaId);
            parameters.Add("@AlmacenId", guiaRemisionAlmacen.AlmacenId);
            parameters.Add("@MotivoTrasladoId", guiaRemisionAlmacen.MotivoTrasladoId);
            parameters.Add("@MotivoTrasladoReferencia", guiaRemisionAlmacen.MotivoTrasladoReferencia);
            parameters.Add("@EmpresaIdDestino", guiaRemisionAlmacen.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", guiaRemisionAlmacen.EmpresaTransporteId);
            parameters.Add("@TransporteId", guiaRemisionAlmacen.TransporteId);
            parameters.Add("@MarcaTractorId", guiaRemisionAlmacen.MarcaTractorId);
            parameters.Add("@PlacaTractor", guiaRemisionAlmacen.PlacaTractor);
            parameters.Add("@MarcaCarretaId", guiaRemisionAlmacen.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", guiaRemisionAlmacen.PlacaCarreta);
            parameters.Add("@Conductor", guiaRemisionAlmacen.Conductor);
            parameters.Add("@Licencia", guiaRemisionAlmacen.Licencia);
            parameters.Add("@NumeroConstanciaMTC", guiaRemisionAlmacen.NumeroConstanciaMTC);
            parameters.Add("@TipoProduccionId", guiaRemisionAlmacen.TipoProduccionId);
            parameters.Add("@TipoCertificacionId", guiaRemisionAlmacen.TipoCertificacionId);

            parameters.Add("@CantidadLotes", guiaRemisionAlmacen.CantidadLotes);
            parameters.Add("@PromedioPorcentajeRendimiento", guiaRemisionAlmacen.PromedioPorcentajeRendimiento);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", guiaRemisionAlmacen.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@CantidadTotal", guiaRemisionAlmacen.CantidadTotal);
            parameters.Add("@PesoKilosBrutos", guiaRemisionAlmacen.PesoKilosBrutos);
            parameters.Add("@FechaUltimaActualizacion", guiaRemisionAlmacen.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", guiaRemisionAlmacen.UsuarioUltimaActualizacion);
            parameters.Add("@GuiaRemisionAlmacenId", guiaRemisionAlmacen.GuiaRemisionId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRemisionAlmacenActualizar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }


        public int ActualizarDatosCalidad(GuiaRemisionAlmacen guiaRemisionAlmacen)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@HumedadPorcentajeAnalisisFisico", guiaRemisionAlmacen.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@FechaUltimaActualizacion", guiaRemisionAlmacen.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", guiaRemisionAlmacen.UsuarioUltimaActualizacion);
            parameters.Add("@GuiaRemisionAlmacenId", guiaRemisionAlmacen.GuiaRemisionId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRemisionAlmacenActualizarDatosCalidad", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }


    }



}
