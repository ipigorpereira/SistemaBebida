using AutoMapper;
using GlobalExceptionHandler.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SistemaBebida.DTO_s.Bebidas;
using SistemaBebida.DTO_s.Clientes;
using SistemaBebida.DTO_s.Estoques;
using SistemaBebida.DTO_s.Marcas;
using SistemaBebida.DTO_s.TiposBebidas;
using SistemaBebida.DTO_s.Vendas;
using SistemaBebida.DTO_s.VendasBebidas;
using SistemaBebida.Entities;
using SistemaBebida.Identity;
using SistemaBebida.Repositories;
using SistemaBebida.Repositories.Bebidas;
using SistemaBebida.Repositories.Clientes;
using SistemaBebida.Repositories.Estoques;
using SistemaBebida.Repositories.Marcas;
using SistemaBebida.Repositories.TiposBebidas;
using SistemaBebida.Repositories.Vendas;
using SistemaBebida.Services.Bebidas;
using SistemaBebida.Services.Clientes;
using SistemaBebida.Services.Estoques;
using SistemaBebida.Services.Marcas;
using SistemaBebida.Services.TiposBebidas;
using SistemaBebida.Services.Vendas;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace SistemaBebida
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //AUTOMAPPER (DTO'S)
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cliente, ClienteRequest>();
                cfg.CreateMap<Cliente, ClienteResponse>();
                cfg.CreateMap<ClienteRequest, Cliente>();
                cfg.CreateMap<Marca, MarcaRequest>();
                cfg.CreateMap<Marca, MarcaResponse>();
                cfg.CreateMap<MarcaRequest, Marca>();
                cfg.CreateMap<TipoBebida, TipoBebidaRequest>();
                cfg.CreateMap<TipoBebida, TipoBebidaResponse>();
                cfg.CreateMap<TipoBebidaRequest, TipoBebida>();
                cfg.CreateMap<Bebida, BebidaRequest>();
                cfg.CreateMap<Bebida, BebidaResponse>();
                cfg.CreateMap<BebidaRequest, Bebida>();
                cfg.CreateMap<Estoque, EstoqueRequest>();
                cfg.CreateMap<Estoque, EstoqueResponse>();
                cfg.CreateMap<EstoqueRequest, Estoque>();
                cfg.CreateMap<Venda, VendaRequest>();
                cfg.CreateMap<Venda, VendaResponse>();
                cfg.CreateMap<VendaRequest, Venda>();
                cfg.CreateMap<VendaBebida, VendaBebidaRequest>();
                cfg.CreateMap<VendaBebida, VendaBebidaResponse>();
                cfg.CreateMap<VendaBebidaRequest, VendaBebida>();

            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            //CONTEXT
            services.AddDbContext<ProgramContext>(x => x.UseSqlServer(Configuration["ConnectionString"]));

            //IDENTITY
            services.AddDbContext<ApplicationDbContext>(options =>
                             options.UseSqlServer(Configuration["ConnectionString2"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                                                       .AddEntityFrameworkStores<ApplicationDbContext>()
                                                       .AddDefaultTokenProviders();





            //INJEÇAO DE DEPENDENCIA
            services.AddScoped<IBebidaRepository, BebidaRepository>();
            services.AddScoped<IBebidaService, BebidaService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<ITipoBebidaService, TipoBebidaService>();
            services.AddScoped<ITipoBebidaRepository, TipoBebidaRepository>();

            //SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Loja",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core",
                        Contact = new Contact
                        {
                            Name = "Igor Pereira",
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseGlobalExceptionHandler(x =>
            {
                x.ContentType = "application/json";
                x.ResponseBody(s => JsonConvert.SerializeObject(new
                {
                    Message = s.Message
                }));
            });

            app.Map("/error", x => x.Run(y => throw new Exception()));

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Loja");
            });
        }
    }
}