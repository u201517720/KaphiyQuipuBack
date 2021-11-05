using KaphiyQuipu.DTO;
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
    public class GuiaRemisionAlmacenPlantaRepository : IGuiaRemisionAlmacenPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public GuiaRemisionAlmacenPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insertar(GuiaRemisionAlmacenPlanta GuiaRemisionAlmacenPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenPlantaId", GuiaRemisionAlmacenPlanta.NotaSalidaAlmacenPlantaId);
            parameters.Add("@Numero", GuiaRemisionAlmacenPlanta.Numero);
            parameters.Add("@EmpresaId", GuiaRemisionAlmacenPlanta.EmpresaId);
            parameters.Add("@AlmacenId", GuiaRemisionAlmacenPlanta.AlmacenId);
            parameters.Add("@MotivoSalidaId", GuiaRemisionAlmacenPlanta.MotivoSalidaId);
            parameters.Add("@MotivoSalidaReferencia", GuiaRemisionAlmacenPlanta.MotivoSalidaReferencia);
            parameters.Add("@EmpresaIdDestino", GuiaRemisionAlmacenPlanta.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", GuiaRemisionAlmacenPlanta.EmpresaTransporteId);
            parameters.Add("@TransporteId", GuiaRemisionAlmacenPlanta.TransporteId);
            parameters.Add("@MarcaTractorId", GuiaRemisionAlmacenPlanta.MarcaTractorId);
            parameters.Add("@PlacaTractor", GuiaRemisionAlmacenPlanta.PlacaTractor);
            parameters.Add("@MarcaCarretaId", GuiaRemisionAlmacenPlanta.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", GuiaRemisionAlmacenPlanta.PlacaCarreta);
            parameters.Add("@Conductor", GuiaRemisionAlmacenPlanta.Conductor);
            parameters.Add("@Licencia", GuiaRemisionAlmacenPlanta.Licencia);
            parameters.Add("@CantidadLotes", GuiaRemisionAlmacenPlanta.CantidadLotes);
            parameters.Add("@NumeroConstanciaMTC", GuiaRemisionAlmacenPlanta.NumeroConstanciaMTC);
            parameters.Add("@TipoProduccionId", GuiaRemisionAlmacenPlanta.TipoProduccionId);
            parameters.Add("@TipoCertificacionId", GuiaRemisionAlmacenPlanta.TipoCertificacionId);
            parameters.Add("@PromedioPorcentajeRendimiento", GuiaRemisionAlmacenPlanta.PromedioPorcentajeRendimiento);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", GuiaRemisionAlmacenPlanta.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@CantidadTotal", GuiaRemisionAlmacenPlanta.CantidadTotal);
            parameters.Add("@PesoKilosBrutos", GuiaRemisionAlmacenPlanta.PesoKilosBrutos);
            parameters.Add("@EstadoId", GuiaRemisionAlmacenPlanta.EstadoId);
            parameters.Add("@FechaRegistro", GuiaRemisionAlmacenPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", GuiaRemisionAlmacenPlanta.UsuarioRegistro);
            parameters.Add("@GuiaRemisionAlmacenPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRemisionAlmacenPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            result = parameters.Get<int>("GuiaRemisionAlmacenPlantaId");
            return result;
        }

        public int Actualizar(GuiaRemisionAlmacenPlanta GuiaRemisionAlmacenPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenPlantaId", GuiaRemisionAlmacenPlanta.NotaSalidaAlmacenPlantaId);
            parameters.Add("@Numero", GuiaRemisionAlmacenPlanta.Numero);
            parameters.Add("@EmpresaId", GuiaRemisionAlmacenPlanta.EmpresaId);
            parameters.Add("@AlmacenId", GuiaRemisionAlmacenPlanta.AlmacenId);
            parameters.Add("@MotivoSalidaId", GuiaRemisionAlmacenPlanta.MotivoSalidaId);
            parameters.Add("@MotivoSalidaReferencia", GuiaRemisionAlmacenPlanta.MotivoSalidaReferencia);
            parameters.Add("@EmpresaIdDestino", GuiaRemisionAlmacenPlanta.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", GuiaRemisionAlmacenPlanta.EmpresaTransporteId);
            parameters.Add("@TransporteId", GuiaRemisionAlmacenPlanta.TransporteId);
            parameters.Add("@MarcaTractorId", GuiaRemisionAlmacenPlanta.MarcaTractorId);
            parameters.Add("@PlacaTractor", GuiaRemisionAlmacenPlanta.PlacaTractor);
            parameters.Add("@MarcaCarretaId", GuiaRemisionAlmacenPlanta.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", GuiaRemisionAlmacenPlanta.PlacaCarreta);
            parameters.Add("@Conductor", GuiaRemisionAlmacenPlanta.Conductor);
            parameters.Add("@Licencia", GuiaRemisionAlmacenPlanta.Licencia);
            parameters.Add("@NumeroConstanciaMTC", GuiaRemisionAlmacenPlanta.NumeroConstanciaMTC);
            parameters.Add("@TipoProduccionId", GuiaRemisionAlmacenPlanta.TipoProduccionId);
            parameters.Add("@TipoCertificacionId", GuiaRemisionAlmacenPlanta.TipoCertificacionId);
            parameters.Add("@CantidadLotes", GuiaRemisionAlmacenPlanta.CantidadLotes);
            parameters.Add("@PromedioPorcentajeRendimiento", GuiaRemisionAlmacenPlanta.PromedioPorcentajeRendimiento);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", GuiaRemisionAlmacenPlanta.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@CantidadTotal", GuiaRemisionAlmacenPlanta.CantidadTotal);
            parameters.Add("@PesoKilosBrutos", GuiaRemisionAlmacenPlanta.PesoKilosBrutos);
            parameters.Add("@FechaUltimaActualizacion", GuiaRemisionAlmacenPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", GuiaRemisionAlmacenPlanta.UsuarioUltimaActualizacion);
            parameters.Add("@GuiaRemisionAlmacenPlantaId", GuiaRemisionAlmacenPlanta.GuiaRemisionAlmacenPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRemisionAlmacenPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

    }



}
