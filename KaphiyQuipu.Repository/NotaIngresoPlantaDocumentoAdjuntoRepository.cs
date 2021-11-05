using KaphiyQuipu.DTO;
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
    public class NotaIngresoPlantaDocumentoAdjuntoRepository : INotaIngresoPlantaDocumentoAdjuntoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaIngresoPlantaDocumentoAdjuntoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

 

        public int Eliminar(int NotaIngresoPlantaDocumentoAdjuntoId)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaDocumentoAdjuntoId", NotaIngresoPlantaDocumentoAdjuntoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaDocumentoAdjuntoEliminar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
