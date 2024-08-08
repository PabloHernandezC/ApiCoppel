using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebCoppel.Errores;
using Data;
using Microsoft.EntityFrameworkCore;
using BLL.Servicios.Interfaces;
using BLL.Servicios;
using Data.Interfaces;
using Data.Repositorios;
using Utilidades;

namespace WebCoppel.Extenciones
{
    public static class ServicioAppExtencion
    {
        public static IServiceCollection AgregarServicioAplicacion(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Ingrese Bearer [espacio] token \r\n\r\n " +
                        "Ejemplo: Bearer ejoy845848945",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                        }
                });
            });
            services.AddCors();
            services.AddScoped<ITokenServicio, TokenServicio>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errores = actionContext.ModelState
                                    .Where(e => e.Value.Errors.Count() > 0)
                                    .SelectMany(x => x.Value.Errors)
                                    .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidacionErrorResponse
                    {
                        Errores = errores
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            services.AddScoped<IUnidadTrabajo, UnidadTrabajo>();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IArticulosServicio, ArticuloServicio>();
            services.AddScoped<IClaseServicio, ClaseServicio>();
            services.AddScoped<IFamiliaServicio, FamiliaServicio>();
            services.AddScoped<IDepartamentoServicio, DepartamentoServicio>();

            return services;
        }
    }
}
