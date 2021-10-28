using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface ISolicitudCompraRepository
    {
        int Insertar(SolicitudCompra solicitudCompra);
    }
}
