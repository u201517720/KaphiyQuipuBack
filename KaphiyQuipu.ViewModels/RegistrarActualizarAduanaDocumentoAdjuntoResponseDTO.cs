﻿using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaphiyQuipu.DTO
{
   public class RegistrarActualizarAduanaDocumentoAdjuntoResponseDTO
	{

		public RegistrarActualizarAduanaDocumentoAdjuntoResponseDTO()
		{
			this.Result = new Result();
		}
		public Result Result { get; set; }


	}
}
