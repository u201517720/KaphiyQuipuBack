using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IProductorDocumentoRepository
    {
        int Insertar(ProductorDocumento ProductorDocumento);

        int Actualizar(ProductorDocumento ProductorDocumento);

        int Eliminar(int socioDocumentoId);

        IEnumerable<ConsultarProductorDocumentoPorProductorId> ConsultarProductorDocumentoPorProductorId(int ProductorId);

        ProductorDocumento ConsultarProductorDocumentoPorId(int productorDocumentoId);
    }
}
