using FG212499.BL.AutoMapper;
using FG212499.BL.Interfaces;
using FG212499.DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(_ => { }, typeof(AutoMapperProfile));
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<IEstudianteService, EstudianteService>();
            services.AddTransient<IInscripcionService, InscripcionService>();
            services.AddRepositoryConnector();
            return services;
        }
    }
}
