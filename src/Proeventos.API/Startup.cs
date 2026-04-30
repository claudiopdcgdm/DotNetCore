using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Proeventos.API.Utils;
using Proeventos.Application;
using Proeventos.Application.Interfaces;
using Proeventos.Persistence;

namespace Proeventos.API
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

            services.AddCors();//Adiciona o cors
            services.AddScoped<IEventoService, EventoService>(); //injeta a classe concreta no scopo
            services.AddScoped<IEventoPersistence, EventoPersistence>(); //injeta a classe concreta no scopo
            services.AddScoped<IPalestrantePersistence, PalestantePersistence>(); //injeta a classe concreta no scopo
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//puxa a classe eventoprofile dentro de helpers para mapeamento
            services.AddControllers()
                    //Corrigi o erro de chamada ciclica dos objetos do dominio
                    .AddNewtonsoftJson(
                        c => c.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );
            services.AddDbContext<ProeventosContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Proeventos.API", Version = "v1" });
                c.OperationFilter<RemoveIdFromRequestFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proeventos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(acesso => acesso.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}