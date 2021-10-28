using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IFincaDocumentoAdjuntoRepository
    {
        int Insertar(FincaDocumentoAdjunto FincaDocumentoAdjunto);

        int Actualizar(FincaDocumentoAdjunto FincaDocumentoAdjunto);

        IEnumerable<ConsultaFincaDocumentoAdjuntoPorId> ConsultarFincaDocumentoAdjuntoPorFincaId(int fincaId);

        ConsultaFincaDocumentoAdjuntoPorId ConsultarFincaDocumentoAdjuntoPorId(int FincaDocumentoAdjuntoId);

        int Eliminar(int fincaDocumentoAdjuntoId);
    }
}