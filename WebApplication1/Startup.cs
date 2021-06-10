using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SeriesApp.Business.Repository;
using curso.api.Infraestrutura.Data.Repositories;
using SeriesApp.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using SeriesApp.Configurations;
using SeriesApp.Services;

namespace SeriesApp
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>() }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // ler o swagger de um arquivo xml(utiliza biblioteca System.Reflection)
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); // caminho do diretorio que está o swagger
                c.IncludeXmlComments(xmlPath); //Inclui os comentarios no Swagger
            });

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfigurations:Secret").Value);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //configuracao do middle para usar JWT
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //configuracao do middle para usar JWT
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, //passando chave
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //    // ABRINDO O BANCO DE DADOS
            //    var optionsBuilder = new DbContextOptionsBuilder<CursosDbContext>();
            //    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CURSOS;Trusted_Connection=True");
            //    CursosDbContext contexto = new CursosDbContext(optionsBuilder.Options); //Cria o objeto contexto do banco de Dados ex: Tipagem das tabelas,
            //assim como chaves primarias e estrangeiras
            services.AddDbContext<SeriesDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAuthenticationService, TokenService> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Curso");// qual arquivo o swagger tem que ler?
                c.RoutePrefix = string.Empty; //swagger rota padrao
            });
        }
    }
}
