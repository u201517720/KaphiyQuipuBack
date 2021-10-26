﻿using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Seguridad;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using CoffeeConnect.Models.User;
using Core.Common.Domain.Model;
using Core.Common.Encryption;
using KaphiyQuipu.Blockchain.Entities;
using KaphiyQuipu.Blockchain.ERC20;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _UsersRepository;
        private IClienteRepository _ClienteRepository;

        private IEmpresaRepository _EmpresaRepository;
        private IProductoPrecioDiaRepository _ProductoPrecioDiaRepository;
        private IUserContract _userContract;

        public UsersService(IUsersRepository usersRepository, IClienteRepository clienteRepository, IEmpresaRepository empresaRepository, IProductoPrecioDiaRepository productoPrecioDiaRepository,
                            IUserContract userContract)
        {
            _UsersRepository = usersRepository;
            _ClienteRepository = clienteRepository;
            _EmpresaRepository = empresaRepository;
            _ProductoPrecioDiaRepository = productoPrecioDiaRepository;
            _userContract = userContract;
        }

        string dataMenu = @"[
{
    path: '',
    title: 'Productor.Label',
    icon: 'ft-home',
    class: 'has-sub',
    badge: '',
    badgeClass: '',
    isExternalLink: false,
    submenu: [
      {
        path: '',
        title: 'Productor.Administracion.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/productor/administracion/productor/list',
            title: 'Productor.Administracion.Productor.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/productor/administracion/maestros-list',
            title: 'Productor.Administracion.MaestrosGenerales.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      }
    ]
  },
  {
    path: '',
    title: 'Acopio.Label',
    icon: 'ft-message-square',
    class: 'has-sub',
    badge: '',
    badgeClass: '',
    isExternalLink: false,
    submenu: [
      {
        path: '',
        title: 'Acopio.Operaciones.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/acopio/operaciones/guiarecepcionmateriaprima-list',
            title: 'Acopio.Operaciones.RecepcionMateriaPrima.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/acopio/operaciones/notasdecompra-list',
            title: 'Acopio.Operaciones.LiquidacionCompra.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/acopio/operaciones/ingresoalmacen-list',
            title: 'Acopio.Operaciones.IngresoAlmacen.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/acopio/operaciones/lotes-list',
            title: 'Acopio.Operaciones.Lotes.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/acopio/operaciones/notasalida-list',
            title: 'Acopio.Operaciones.SalidaAlmacen.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      },
      {
        path: '',
        title: 'Acopio.Administracion.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/uikit/font-awesome',
            title: 'Acopio.Administracion.Terceros.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/uikit/font-awesome',
            title: 'Acopio.Administracion.Intermediario.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/uikit/font-awesome',
            title: 'Acopio.Administracion.MaestrosGenerales.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      }
    ]
  },
  {
    path: '',
    title: 'Agropecuario.Label',
    icon: 'ft-home',
    class: 'has-sub',
    badge: '',
    badgeClass: '',
    isExternalLink: false,
    submenu: [
      {
        path: '',
        title: 'Agropecuario.Operaciones.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/agropecuario/operaciones/socio/list',
            title: 'Agropecuario.Operaciones.Socio.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          
        ]
      },
      {
        path: '',
        title: 'Agropecuario.Administracion.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/uikit/font-awesome',
            title: 'Agropecuario.Administracion.MaestrosGenerales.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      }
    ]
  },
  {
    path: '',
    title: 'Planta.Label',
    icon: 'ft-home',
    class: 'has-sub',
    badge: '',
    badgeClass: '',
    isExternalLink: false,
    submenu: [
      {
        path: '',
        title: 'Planta.Operaciones.Label',  
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/planta/operaciones/notaingreso-list',
            title: 'Planta.Operaciones.NotaIngreso.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
		  {
            path: '/planta/operaciones/notaingresoalmacen-list',
            title: 'Planta.Operaciones.NotaIngresoAlmacen.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      },
      {
        path: '',
        title: 'Planta.Administracion.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/uikit/font-awesome',
            title: 'Planta.Administracion.MaestrosGenerales.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      }
    ]
  },
  {
    path: '',
    title: 'Exportador.Label',
     icon: 'ft-life-buoy',
	class: 'has-sub',
	badge: '',
	badgeClass: '',
	isExternalLink: false,
	submenu: [
      {
        path: '',
        title: 'Exportador.Operaciones.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
      {
            path: '/acopio/operaciones/orderservicio-controlcalidadexterna-list',
            title: 'Exportador.Operaciones.ControlCalidadExterna.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
		  {
            path: '/exportador/operaciones/cliente/list',
            title: 'Exportador.Operaciones.Cliente.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
		  {
            path: '/exportador/operaciones/contrato/list',
            title: 'Exportador.Operaciones.Contrato.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
		  
		  {
            path: '/exportador/operaciones/ordenproceso/list',
            title: 'Exportador.Operaciones.OrdenProceso.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
    ]
      }
    ]
	
	
	
    
  },
  {
    path: '',
    title: 'Transporte.Label',
     icon: 'ft-book',
	class: 'has-sub',
	badge: '',
	badgeClass: '',
	isExternalLink: false,
    submenu: [
    
    ]
  },
{
    path: '',
    title: 'Cliente.Label',
     icon: 'ft-life-buoy',
	class: 'has-sub',
	badge: '',
	badgeClass: '',
	isExternalLink: false,
    submenu: [
    
    ]
  }
]
 ";

        public LoginBE AuthenticateUsers(string username, string password)
        {
            UserDTO userDTO = _userContract.ValidateUser(username, password).Result;

            if (userDTO is null)
                throw new ResultException(new Result { ErrCode = "02", Message = "Login.UsuarioPasswordIncorrecto" });

            LoginBE loginDTO = new LoginBE();

            var usuariosList = _UsersRepository.AuthenticateUsers(username, password);

            if (!usuariosList.Any())
                throw new ResultException(new Result { ErrCode = "02", Message = "Login.UsuarioPasswordIncorrecto" });

            var usuario = usuariosList.First();

            loginDTO.IdUsuario = usuario.UserId;
            loginDTO.NombreUsuario = usuario.UserName;
            loginDTO.NombreCompletoUsuario = usuario.FullName;
            loginDTO.RolId = usuario.RoleId;

            var empresa = _EmpresaRepository.ObtenerEmpresaPorId(usuario.EmpresaId);

            if (empresa != null)
            {
                loginDTO.RazonSocialEmpresa = empresa.RazonSocial;
                loginDTO.RucEmpresa = empresa.Ruc;
                loginDTO.EmpresaId = empresa.EmpresaId;
                loginDTO.TipoEmpresaid = empresa.TipoEmpresaid;
                loginDTO.DireccionEmpresa = empresa.Direccion;
                loginDTO.LogoEmpresa = empresa.Logo;
                loginDTO.MonedaId = "01";
                loginDTO.Moneda = "Soles";
            }

            if (usuario.ClienteId.HasValue)
            {
                ConsultaClientePorIdBE consultaClientePorIdBE = _ClienteRepository.ConsultarClientePorId(usuario.ClienteId.Value);

                if (consultaClientePorIdBE != null)
                {
                    loginDTO.Cliente = consultaClientePorIdBE.RazonSocial;
                    loginDTO.CodigoCliente = consultaClientePorIdBE.Numero;
                }
            }

            List<ConsultaOpcionesPorUsuario> opcionesUsuario = _UsersRepository.ConsultarOpcionesPorUsuario(usuario.UserId).ToList();

            //TODO: Armar dataMenu en base a opcionesUsuario
            List<Root> rootList = new List<Root>();

            var listaModulos = opcionesUsuario.Where(c => c.Type == "Modulo").ToList();
            foreach (ConsultaOpcionesPorUsuario objOpcion in listaModulos)
            {
                Root root = new Root();
                root.Badge = "";
                root.BadgeClass = "";
                root.Class = "has-sub";
                root.Icon = objOpcion.Icon;
                root.IsExternalLink = false;
                root.Path = objOpcion.Path;
                var submenu1List = opcionesUsuario.Where(c => c.Type == "Opcion" && Convert.ToString(c.OpcionPadreId) == objOpcion.Codigo).ToList();
                List<Submenu2> subMenuPrincipalList = new List<Submenu2>();
                foreach (ConsultaOpcionesPorUsuario submenu1 in submenu1List)
                {
                    Submenu2 subMenu = new Submenu2();
                    subMenu.Badge = "";
                    subMenu.BadgeClass = "";
                    subMenu.Class = "has-sub";
                    subMenu.Icon = submenu1.Icon;
                    subMenu.IsExternalLink = false;
                    subMenu.Path = submenu1.Path;
                    subMenu.Submenu = new List<Submenu2>();
                    subMenu.Title = submenu1.Tittle;
                    subMenuPrincipalList.Add(subMenu);
                }
                root.Submenu = subMenuPrincipalList;

                root.Title = objOpcion.Tittle;
                rootList.Add(root);
            }

            List<MenuBE> opciones = JsonConvert.DeserializeObject<List<MenuBE>>(dataMenu);

            loginDTO.Opciones = rootList;

            return loginDTO;
        }

        public int RegistrarUsuario(User request)
        {
            request.Password = EncryptionLibrary.EncryptText(request.Password);
            int id = _UsersRepository.Insertar(request);
            return id;
        }

        public int ValidarUsuario(string correo)
        {
            int result = _UsersRepository.ValidarUsuario(correo);
            return result;
        }

        public int RegistrarRolUsuario(int userId, int userRolId)
        {
            int id = _UsersRepository.InsertarRoles(userId, userRolId);
            return id;
        }
    }

}
