using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Domain.Interfaces.Repositories; // Donde están las Interfaces
using Proyecto.Domain.Interfaces.UseCases;    // Donde están las Interfaces UC
using Proyecto.Domain.UseCases;               // Donde están las clases concretas UC

namespace Proyecto.DI
{
    public static class Container
    {
        /// <summary>
        /// Registra todas las dependencias del proyecto siguiendo Clean Architecture.
        /// </summary>
        /// <param name="services">Colección de servicios de IServiceCollection</param>
        public static void RegisterServices(IServiceCollection services)
        {
            // 1. Registro de Repositorios (Capa de Data)
            // Cuando alguien pida IPlantasRepository, dale un PlantasRepository
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IPlantasRepository, PlantasRepository>();

            // 2. Registro de Casos de Uso (Capa de Domain/Application)
            // Cuando alguien pida IPlantaUseCase, dale un PlantaUseCase
            services.AddScoped<ICateogriaUseCase, CateogriaUseCase>();
            services.AddScoped<IPlantaUseCase, PlantaUseCase>();
        }
    }
}