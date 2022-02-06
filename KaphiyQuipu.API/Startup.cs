using AutoMapper;
using Core.Common.Auth;
using Core.Common.Email;
using Core.Common.Razor;
using Core.Common.SMS;
using KaphiyQuipu.API.Helper;
using KaphiyQuipu.Blockchain.Contracts;
using KaphiyQuipu.Blockchain.Contracts.Interface;
using KaphiyQuipu.Blockchain.ERC20;
using KaphiyQuipu.Blockchain.Facade;
using KaphiyQuipu.Blockchain.Services;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Repository;
using KaphiyQuipu.Service;
using KaphiyQuipu.Service.MappingConfigurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace KaphiyQuipu.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            var mappingConfiguration = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
            IMapper mapper = mappingConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            var jwtOptions = new JwtOptions();
            var section = Configuration.GetSection("jwt");
            section.Bind(jwtOptions);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination").Build());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtOptions.Issuer,
                            //ValidAudience = "readers",// Configuration["Jwt.Issuer"],
                            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                        };
                    });

            services.AddOptions();

            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<FileServerSettings>(Configuration.GetSection("FileServerSettings"));
            services.Configure<ParametrosSettings>(Configuration.GetSection("ParametrosSettings"));
            //services.Configure<MailServerSettings>(Configuration.GetSection("MailServerSettings"));
            //services.AddTransient<IVBRepository, VBRepository>();

            services.AddTransient<Core.Common.Logger.ILog, Core.Common.Logger.Log>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IViewRender, ViewRender>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IZonaRepository, ZonaRepository>();
            services.AddTransient<IMaestroService, MaestroService>();
            services.AddTransient<IMaestroRepository, MaestroRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IContratoService, ContratoService>();
            services.AddTransient<IContratoRepository, ContratoRepository>();
            services.AddTransient<IGuiaRecepcionMateriaPrimaRepository, GuiaRecepcionMateriaPrimaRepository>();
            services.AddTransient<IProveedorRepository, ProveedorRepository>();
            services.AddTransient<ILoteRepository, LoteRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IProductorRepository, ProductorRepository>();
            services.AddTransient<IProductoPrecioDiaRepository, ProductoPrecioDiaRepository>();
            services.AddTransient<ISocioRepository, SocioRepository>();
            services.AddTransient<IDetalleCatalogoService, DetalleCatalogoService>();
            services.AddTransient<IDetalleCatalogoRepository, DetalleCatalogoRepository>();
            services.AddTransient<ISocioFincaCertificacionRepository, SocioFincaCertificacionRepository>();
            services.AddTransient<IEmpresaTransporteRepository, EmpresaTransporteRepository>();
            services.AddTransient<IEmpresaProveedoraAcreedoraService, EmpresaProveedoraAcreedoraService>();
            services.AddTransient<IEmpresaProveedoraAcreedoraRepository, EmpresaProveedoraAcreedoraRepository>();
            services.AddTransient<ICorrelativoRepository, CorrelativoRepository>();
            services.AddTransient<IProductorFincaRepository, ProductorFincaRepository>();
            services.AddTransient<ISocioFincaRepository, SocioFincaRepository>();
            services.AddTransient<ISocioDocumentoRepository, SocioDocumentoRepository>();
            services.AddTransient<IProductorDocumentoRepository, ProductorDocumentoRepository>();
            services.AddTransient<IUbigeoService, UbigeoService>();
            services.AddTransient<IUbigeoRepository, UbigeoRepository>();
            services.AddTransient<ISocioProyectoRepository, SocioProyectoRepository>();
            services.AddTransient<IOrganizacionRepository, OrganizacionRepository>();
            services.AddTransient<ISolicitudCompraService, SolicitudCompraService>();
            services.AddTransient<ISolicitudCompraRepository, SolicitudCompraRepository>();
            services.AddTransient<ISolicitudCompraService, SolicitudCompraService>();
            services.AddTransient<IUserContract, UserContract>();
            services.AddTransient<ISolicitudCompraContract, SolicitudCompraContract>();
            services.AddTransient<IContratoCompraContract, ContratoCompraContract>();
            services.AddTransient<INotaIngresoPlantaContract, NotaIngresoPlantaContract>();
            services.AddSingleton<IContractFacade, ContractFacade>();
            services.AddSingleton<IContractOperation, ContractOperation>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<ContractService>();
            services.AddTransient<IAgricultorService, AgricultorService>();
            services.AddTransient<IAgricultorRepository, AgricultorRepository>();
            services.AddTransient<IGuiaRecepionMateriaPrimaService, GuiaRecepionMateriaPrimaService>();
            services.AddTransient<IGuiaRecepcionMateriaPrimaRepository, GuiaRecepcionMateriaPrimaRepository>();
            services.AddTransient<INotaIngresoAcopioService, NotaIngresoAcopioService>();
            services.AddTransient<INotaIngresoAcopioRepository, NotaIngresoAcopioRepository>();
            services.AddTransient<IOrdenProcesoAcopioService, OrdenProcesoAcopioService>();
            services.AddTransient<IOrdenProcesoAcopioRepository, OrdenProcesoAcopioRepository>();
            services.AddTransient<IMarcadoSacoAcopioService, MarcadoSacoAcopioService>();
            services.AddTransient<IMarcadoSacoAcopioRepository, MarcadoSacoAcopioRepository>();
            services.AddTransient<IGuiaRemisionAcopioService, GuiaRemisionAcopioService>();
            services.AddTransient<IGuiaRemisionAcopioRepository, GuiaRemisionAcopioRepository>();
            services.AddTransient<INotaIngresoPlantaService, NotaIngresoPlantaService>();
            services.AddTransient<INotaIngresoPlantaRepository, NotaIngresoPlantaRepository>();
            services.AddTransient<INotaSalidaPlantaService, NotaSalidaPlantaService>();
            services.AddTransient<INotaSalidaPlantaRepository, NotaSalidaPlantaRepository>();
            services.AddTransient<IGuiaRemisionPlantaService, GuiaRemisionPlantaService>();
            services.AddTransient<IGuiaRemisionPlantaRepository, GuiaRemisionPlantaRepository>();
            services.AddTransient<IGeneralService, GeneralService>();
            services.AddTransient<IGeneralRepository, GeneralRepository>();

            services.AddTransient<IMessageSender, MessageSender>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ReportService>();

            services.AddMvc(setupAction => { setupAction.EnableEndpointRouting = false; })
                    .AddJsonOptions(jsonOptions => { jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null; })
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
