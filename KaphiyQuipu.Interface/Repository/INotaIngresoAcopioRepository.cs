using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface INotaIngresoAcopioRepository
    {
        string Registrar(NotaIngresoAlmacenAcopio nota);
    }
}
