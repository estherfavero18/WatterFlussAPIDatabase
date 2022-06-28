using APIDatabase.Models.Context;
using APIDatabase.Repository.Generic;
using APIDatabase.Repository.Implementation;
using APIDatabase.Repository.Interface;
using APIDatabase.Service.Implementation;
using APIDatabase.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace APIDatabase
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
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services
            .AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(
                    new System.Text.Json.Serialization.JsonStringEnumConverter());
            });

            services.AddHealthChecks();

            var sqlConnectionString = Configuration.GetConnectionString("SqlConection");
            if (!string.IsNullOrEmpty(sqlConnectionString))
                services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(sqlConnectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Database API",
                    Version = "v1",
                    Description = "Esta API fornecer acesso ao banco de dados.",
                    Contact = new OpenApiContact
                    {
                        Name = "Empresa",
                        Email = "contato@empresa.com.br",
                        Url = new Uri("https://www.empresa.com.br/"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IReservatorioRepository, ReservatorioRepository>();
            services.AddScoped<ISensorNivelRepository, SensorNivelRepository>();
            services.AddScoped<ISensorVazaoRepository, SensorVazaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IReservatorioService, ReservatorioService>();
            services.AddScoped<ISensorNivelService, SensorNivelService>();
            services.AddScoped<ISensorVazaoService, SensorVazaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();

            app.UseHealthChecks("/", env.HealthCheckOptions());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/", Health.HealthCheckOptions(env));
            });
        }
    }
}
