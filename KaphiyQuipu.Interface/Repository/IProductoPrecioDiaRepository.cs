﻿using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IProductoPrecioDiaRepository
    {
        int Insertar(ProductoPrecioDia ProductoPrecioDia);

        int Actualizar(ProductoPrecioDia ProductoPrecioDia);

        IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDia(ConsultaProductoPrecioDiaRequestDTO request);

        IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDiaPorSubProductoIdPorEmpresaId(int empresaID, string subProductoId);

        ConsultaProductoPrecioDiaPorIdBE ConsultarProductoPrecioDiaPorId(int ProductoPrecioDiaId);

        IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDiaPorEmpresaId(int empresaID);
    }
}