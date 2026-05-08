using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Proeventos.API.Utils;
using Proeventos.Application;
using Proeventos.Application.Interfaces;
using Proeventos.Persistence;
using Proeventos.Persistence.Interfaces;
using System.Text.Json.Serialization;
using Proeventos.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Proeventos.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            this.Configuration = configuration;
   
        }
         public IConfiguration Configuration { get; }

      

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configurações do Identity default
            services.AddIdentityCore<User>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric=false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase=false;
                options.Password.RequiredLength = 6;

            })
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddSignInManager<SignInManager<User>>()
            .AddRoleValidator<RoleValidator<Role>>()
            .AddEntityFrameworkStores<ProeventosContext>()
            .AddDefaultTokenProviders();

            //CONFIGURAÇÃO DE AUTENTICAÇÃO VIA TOKEN
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            // INJEÇÃO DE SERVIÇOS
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<ILoteService,LoteService>();
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<ITokenService,TokenService>();

            // INJEÇÃO DE PERSITENCIAS
            services.AddScoped<IEventoPersistence, EventoPersistence>(); 
            services.AddScoped<ILotePersistence, LotePersistence>();
            services.AddScoped<IPalestrantePersistence, PalestantePersistence>(); 
            services.AddScoped<IUserPersistence, UserPersistence>(); 

            //Adiciona o cors
            services.AddCors();
            
            //puxa a classe eventoprofile dentro de helpers para mapeamento
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

           

            //Controllers config
            services.AddControllers()
                    // Configura o Enum para retornar o nome ao inves de indices
                    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new  JsonStringEnumConverter()))
                    // Corrigi o erro de chamada ciclica dos objetos do dominio
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
                c.OperationFilter<FileUploadOperationFilter>();
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
            
            // CONFIGURANDO UPLOAD DE IMAGENS
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"Resources")),
                RequestPath = new PathString("/Resources")
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}