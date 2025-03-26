using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PeliculasApi.Data;
using PeliculasApi.Excepciones;
using PeliculasApi.Repositorios;
using PeliculasApi.Servicios;
using PeliculasApi.Utilidades;

namespace PeliculasApi
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

            /*
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                });
            });
            */

            // AUTOMAPPER (PARA DTOs)
            services.AddAutoMapper(typeof(Startup));

            // IMÁGENES
            services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();
            services.AddHttpContextAccessor();

            // ESTABLECE CONEXIÓN CON "SQLServer" PARA CREAR LA BASE DE DATOS
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));


            // PERMISOS PARA QUE EL NAVEGADOR Y OTROS FRAMEWORKS (ANGULAR) PUEDAN ACCEDER A LOS DATOS Y ENTIDADES
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader().WithExposedHeaders(new string[] { "cantidadTotalRegistros" })
                          .AllowCredentials();
                });
            });


            // REPOSITORIOS
            services.AddScoped<IRepositorio, RepositorioEnMemoria>();


            // SERVICIOS
            services.AddTransient<GeneroServicio>();


            // EXCEPCIONES
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
                // options.Filters.Add<MiFiltroDeAccion>();
                // options.Filters.Add(typeof(FiltroDeExcepcion));
            });

            //FILTROS (COMPILACIÓN)
            //services.AddTransient<MiFiltroDeAccion>();


            // SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PeliculasApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // ELIMINAR Y RECREAR LA BASE DE DATOS CON CADA EJECUCIÓN
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // INTRODUCE LOS DATOS DE EJEMPLO DE "DbInitializer.cs" EN LA BASE DE DATOS
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                DbInitializer.Initialize(context);
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PeliculasApi v1"));
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            // Aplica CORS
            app.UseCors("AllowLocalhost");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
