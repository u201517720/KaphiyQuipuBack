﻿using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System.Collections.Generic;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public partial class MaestroService : IMaestroService
    {
        private IMaestroRepository _IMaestroRepository;
        private IProductoPrecioDiaRepository _IProductoPrecioDiaRepository;

        public MaestroService(IMaestroRepository maestroRepository, IProductoPrecioDiaRepository productoPrecioDiaRepository)
        {
            _IMaestroRepository = maestroRepository;
            _IProductoPrecioDiaRepository = productoPrecioDiaRepository;
        }

        public List<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId, string idioma)
        {
            var lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(empresaId, idioma);

            return lista.ToList();
        }

        public List<ConsultaUbigeoBE> ConsultaUbibeo()
        {
            var lista = _IMaestroRepository.ConsultaUbibeo();

            return lista.ToList();
        }

        public List<Zona> ConsultarZona(string codigoDistrito)
        {
            var lista = _IMaestroRepository.ConsultarZona(codigoDistrito);

            return lista.ToList();
        }

        public List<ConsultaPaisBE> ConsultarPais()
        {
            var lista = _IMaestroRepository.ConsultarPais();

            return lista.ToList();
        }

        public List<ConsultaProductoPrecioDiaBE> ConsultarProductoPrecioDiaPorSubProductoIdPorEmpresaId(string subProductoId, int empresaId)
        {
            List<ConsultaProductoPrecioDiaBE> precios = _IProductoPrecioDiaRepository.ConsultarProductoPrecioDiaPorSubProductoIdPorEmpresaId(empresaId, subProductoId).ToList();

            return precios;
        }

     

    }
}
