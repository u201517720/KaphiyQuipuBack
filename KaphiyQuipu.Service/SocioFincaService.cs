﻿
using AutoMapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public partial class SocioFincaService : ISocioFincaService
    {
        private readonly IMapper _Mapper;

        private ISocioFincaRepository _ISocioFincaRepository;

        private ISocioRepository _ISocioRepository;

        public SocioFincaService(ISocioFincaRepository socioFincaRepository, ISocioRepository socioRepository, IMapper mapper)
        {
            _ISocioFincaRepository = socioFincaRepository;
            _ISocioRepository = socioRepository;

            _Mapper = mapper;



        }

        public int RegistrarSocioFinca(RegistrarActualizarSocioFincaRequestDTO request)
        {
            SocioFinca socioFinca = _Mapper.Map<SocioFinca>(request);
            socioFinca.FechaRegistro = DateTime.Now;
            socioFinca.UsuarioRegistro = request.Usuario;


            int id = _ISocioFincaRepository.Insertar(socioFinca);


            List<SocioFincaEstimadoTipo> socioFincaEstimadoTipoList = new List<SocioFincaEstimadoTipo>();

            request.FincaEstimado.ForEach(z =>
            {
                SocioFincaEstimadoTipo item = new SocioFincaEstimadoTipo();
                item.Anio = z.Anio;
                item.Estimado = z.Estimado;
                item.SocioFincaId = id;
                item.ProductoId = "02"; //Pergamino;
                socioFincaEstimadoTipoList.Add(item);
            });


            _ISocioFincaRepository.ActualizarSocioFincaEstimado(socioFincaEstimadoTipoList, id);
            return id;
        }

        public int ActualizarSocioFinca(RegistrarActualizarSocioFincaRequestDTO request)
        {
            SocioFinca socioFinca = _Mapper.Map<SocioFinca>(request);
            socioFinca.FechaUltimaActualizacion = DateTime.Now;
            socioFinca.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _ISocioFincaRepository.Actualizar(socioFinca);

            List<SocioFincaEstimadoTipo> socioFincaEstimadoTipoList = new List<SocioFincaEstimadoTipo>();

            request.FincaEstimado.ForEach(z =>
            {
                SocioFincaEstimadoTipo item = new SocioFincaEstimadoTipo();
                item.Anio = z.Anio;
                item.Estimado = z.Estimado;
                item.Consumido = z.Consumido;
                item.SocioFincaId = request.SocioFincaId;
                item.ProductoId = "02"; //Pergamino;
                socioFincaEstimadoTipoList.Add(item);
            });

            _ISocioFincaRepository.ActualizarSocioFincaEstimado(socioFincaEstimadoTipoList, request.SocioFincaId);

            return affected;
        }

        public IEnumerable<ConsultaSocioFincaPorSocioIdBE> ConsultarSocioFincaPorSocioId(ConsultaSocioFincaPorSocioIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaPorSocioId(request.SocioId);
        }

        public ConsultaSocioFincaPorIdBE ConsultarSocioFincaPorId(ConsultaSocioFincaPorIdRequestDTO request)
        {
            ConsultaSocioFincaPorIdBE consultaSocioFincaPorIdBE = _ISocioFincaRepository.ConsultarSocioFincaPorId(request.SocioFincaId);

            consultaSocioFincaPorIdBE.FincaEstimado = _ISocioFincaRepository.ConsultarSocioFincaEstimadoPorSocioFincaId(request.SocioFincaId).ToList();


            return consultaSocioFincaPorIdBE;
        }

        public ConsultarSocioProductorPorSocioFincaId ConsultarSocioProductorPorSocioFincaId(ConsultaSocioFincaPorIdRequestDTO request)
        {

            ConsultarSocioProductorPorSocioFincaId consultarSocioProductorPorSocioFincaId = _ISocioRepository.ConsultarSocioProductorPorSocioFincaId(request.SocioFincaId);
           
            return consultarSocioProductorPorSocioFincaId;
        }



        public ConsultaSocioFincaEstimadoPorSocioFincaIdBE ConsultarSocioFincaEstimadoPorSocioFincaId(ConsultaSocioFincaEstimadoPorSocioFincaIdRequest request)
        {
            List<ConsultaSocioFincaEstimadoPorSocioFincaIdBE> fincaEstimados = _ISocioFincaRepository.ConsultarSocioFincaEstimadoPorSocioFincaId(request.SocioFincaId).ToList();

            ConsultaSocioFincaEstimadoPorSocioFincaIdBE fincaEstima = null;

            if (fincaEstimados.Count > 0)
            {
                int anioActual = DateTime.Now.Year;

                fincaEstima = fincaEstimados.Where(x => x.Anio == anioActual).FirstOrDefault();
                if (fincaEstima != null)
                {
                    fincaEstima.SaldoPendiente = fincaEstima.Estimado - fincaEstima.Consumido;
                }


            }
            return fincaEstima;
        }
    }
}
