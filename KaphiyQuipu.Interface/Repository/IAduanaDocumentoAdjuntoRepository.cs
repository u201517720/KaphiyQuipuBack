﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IAduanaDocumentoAdjuntoRepository
    {

        int Eliminar(int AduanaDocumentoAdjuntoId);
    }
}