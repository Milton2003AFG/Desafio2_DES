using FG212499.DAL.Interfaces;
using FG212499.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.DAL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ICursoRepository, CursoRepository>();
            services.AddTransient<IEstudianteRepository, EstudianteRepository>();
            services.AddTransient<IInscripcionRepository, InscripcionRepository>();
            return services;
        }
    }
}
