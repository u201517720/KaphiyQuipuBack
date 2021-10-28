using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IAduanaDocumentoAdjuntoRepository
    {
        int Insertar(AduanaDocumentoAdjunto AduanaDocumentoAdjunto);

        int Actualizar(AduanaDocumentoAdjunto AduanaDocumentoAdjunto);

        IEnumerable<ConsultaAduanaDocumentoAdjuntoPorId> ConsultarAduanaDocumentoAdjuntoPorAduanaId(int AduanaId);

        ConsultaAduanaDocumentoAdjuntoPorId ConsultarAduanaDocumentoAdjuntoPorId(int AduanaDocumentoAdjuntoId);

        int Eliminar(int AduanaDocumentoAdjuntoId);
    }
}