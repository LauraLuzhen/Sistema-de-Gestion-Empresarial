using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class Container
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services)
        {
            // Registrar los Repositorios (Data)
            services.AddScoped<IPersonaRepository, PersonaRepositoryAzure>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepositoryAzure>();

            // Registrar los Use Cases (Domain)
            services.AddScoped<IPersonaUseCases, PersonaUseCases>();
            services.AddScoped<IDepartamentoUseCases, DepartamentoUseCases>();

            // Devolver el contenedor de servicios
            return services;
        }
    }

}

