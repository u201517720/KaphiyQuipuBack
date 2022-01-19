using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System.Collections.Generic;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ISocioDocumentoRepository
    {
        int Insertar(SocioDocumento socioDocumento);

        int Actualizar(SocioDocumento socioDocumento);

        IEnumerable<ConsultarSocioDocumentoPorSocioId> ConsultarSocioDocumentoPorSocioId(int socioId);

        int Eliminar(int socioDocumentoId);

        SocioDocumento ConsultarSocioDocumentoPorId(int socioDocumentoId);
    }
}
