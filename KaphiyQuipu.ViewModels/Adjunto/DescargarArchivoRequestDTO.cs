﻿using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.DTO.Adjunto
{
    public class DescargarArchivoRequestDTO
    {
        public DescargarArchivoRequestDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
