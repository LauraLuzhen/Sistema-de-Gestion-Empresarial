using Microsoft.Extensions.DependencyInjection;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using Domain.UseCases;

namespace AppContenedorPrincipal
{
    public static class Container
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // --- Registro de Repositorios (Data) ---
            // Usamos AddScoped para que se cree una instancia por cada solicitud HTTP
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

            // --- Registro de Casos de Uso (Domain) ---
            services.AddScoped<IListadoUseCase, ListadoUseCase>();
            services.AddScoped<IComprobarUseCase, ComprobarUseCase>();

            // Nota: Aquí no registramos el Controller, 
            // ASP.NET Core lo hace automáticamente.
        }
    }
}