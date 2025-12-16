using Microsoft.AspNetCore.Mvc;
using Proyecto.Domain.Interfaces.UseCases;
using Proyecto.Domain.Dtos;

namespace Proyecto.UI.Controllers
{
    public class PlantaController : Controller
    {
        private readonly IPlantaUseCase _plantaUseCase;

        public PlantaController(IPlantaUseCase plantaUseCase)
        {
            _plantaUseCase = plantaUseCase;
        }

        /// <summary>
        /// Muestra la vista de asignación de precio para una planta específica.
        /// </summary>
        /// <param name="id">ID de la planta enviado desde el enlace de la tabla</param>
        /// <returns>Vista con el modelo PlantaPorNombreCategoriaDto</returns>
        [HttpGet]
        public IActionResult UpdatePrecio(int id)
        {
            PlantaPorNombreCategoriaDto modelo = _plantaUseCase.getPlataPorNombreCategoria(id);

            if (modelo.planta == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        /// <summary>
        /// Recibe los datos del formulario de edición.
        /// </summary>
        /// <param name="id">ID de la planta (hidden input)</param>
        /// <param name="precio">Nuevo precio introducido por el usuario</param>
        /// <returns>Redirección al Index si es correcto, o la misma vista con error</returns>
        [HttpPost]
        public IActionResult GuardarPrecio(int id, double precio)
        {
            // Ejecutamos la lógica de negocio (validación de precio mayor)
            int resultado = _plantaUseCase.updatePrecioPlanta(id, precio);

            if (resultado == -1)
            {
                // Error de validación: el precio no es mayor al anterior
                ViewBag.MensajeError = "Error: El nuevo precio debe ser mayor al precio actual de la planta.";

                // Recargamos el modelo para no perder la información en la vista
                PlantaPorNombreCategoriaDto modelo = _plantaUseCase.getPlataPorNombreCategoria(id);
                return View("UpdatePrecio", modelo);
            }

            if (resultado == 0)
            {
                return NotFound();
            }

            // Si todo es correcto, volvemos al listado principal
            return RedirectToAction("Index", "Home");
        }
    }
}