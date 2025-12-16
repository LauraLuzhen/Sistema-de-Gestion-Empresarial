using Microsoft.AspNetCore.Mvc;
using Proyecto.Domain.Interfaces.UseCases;
using Proyecto.Domain.Dtos;

namespace Proyecto.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlantaUseCase _plantaUseCase;

        // Inyectamos el UseCase de plantas (que ya incluye acceso a categorías)
        public HomeController(IPlantaUseCase plantaUseCase)
        {
            _plantaUseCase = plantaUseCase;
        }

        /// <summary>
        /// Acción principal que muestra el buscador y la tabla.
        /// </summary>
        /// <param name="idCategoria">Recibe el ID del desplegable (opcional)</param>
        /// <returns>Vista con el modelo ListadoPlantaPorCategoriaDto</returns>
        public IActionResult Index(int? idCategoria)
        {
            // El UseCase se encarga de llenar el DTO con categorías y plantas filtradas
            ListadoPlantaPorCategoriaDto modelo = _plantaUseCase.getListadoPlantaPorCategoria(idCategoria);

            return View(modelo);
        }
    }
}