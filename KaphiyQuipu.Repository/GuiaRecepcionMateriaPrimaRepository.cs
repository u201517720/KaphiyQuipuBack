using Dapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KaphiyQuipu.Repository
{
    public class GuiaRecepcionMateriaPrimaRepository : IGuiaRecepcionMateriaPrimaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public GuiaRecepcionMateriaPrimaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaGuiaRecepcionMateriaPrimaDTO> Consultar(ConsultarGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pFechaInicio", request.FechaInicio);
            parameters.Add("@pFechaFinal", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaGuiaRecepcionMateriaPrimaDTO>("uspObtenerGuiasRecepcion", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public string Registrar(GuiaRecepcionMateriaPrima guia)
        {
            string result = string.Empty;

            var parameters = new DynamicParameters();
            parameters.Add("@pCorrelativo", guia.Correlativo);
            parameters.Add("@pContratoId", guia.ContratoId);
            parameters.Add("@pSacosPC", guia.SacosPC);
            parameters.Add("@pKilosBrutosPC", guia.KilosBrutosPC);
            parameters.Add("@pTaraSacoPC", guia.TaraSacoPC);
            parameters.Add("@pKilosNetos", guia.KilosNetos);
            parameters.Add("@pQQ55KG", guia.QQ55KG);
            parameters.Add("@pCafeExportacionGramosAFC", guia.CafeExportacionGramosAFC);
            parameters.Add("@pCafeExportacionPorcAFC", guia.CafeExportacionPorcAFC);
            parameters.Add("@pDescarteGramosAFC", guia.DescarteGramosAFC);
            parameters.Add("@pDescartePorcAFC", guia.DescartePorcAFC);
            parameters.Add("@pCascaraGramosAFC", guia.CascaraGramosAFC);
            parameters.Add("@pCascaraPorcAFC", guia.CascaraPorcAFC);
            parameters.Add("@pTotalGramosAFC", guia.TotalGramosAFC);
            parameters.Add("@pTotalPorcAFC", guia.TotalPorcAFC);
            parameters.Add("@pHumedad", guia.Humedad);
            parameters.Add("@pObservaciones", guia.Observaciones);
            parameters.Add("@pUsuarioRegistro", guia.UsuarioRegistro);
            parameters.Add("@pFechaRegistro", guia.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.ExecuteScalar<string>("uspRegistrarGuiaRecepcion", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
