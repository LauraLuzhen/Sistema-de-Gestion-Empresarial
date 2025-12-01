using MandoMissions.Models;
using MandoMissions.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MandoMissions.Controllers
{
    public class MisionesController : Controller
    {
        private readonly clsMisionesUseCase _useCase = new clsMisionesUseCase();

        private bool EsHoraValida()
        {
            // Restricción: No puede ver misiones después de media noche (00:00) y antes de las 8:00
            TimeSpan horaActual = DateTime.Now.TimeOfDay;
            TimeSpan medianoche = new TimeSpan(0, 0, 0); // 00:00
            TimeSpan ochoAM = new TimeSpan(8, 0, 0);    // 08:00

            // Es inválido si la hora actual está entre 00:00:00 y 07:59:59
            return !(horaActual >= medianoche && horaActual < ochoAM);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new MisionViewModel();

            if (!EsHoraValida())
            {
                viewModel.MensajeRestriccion = "¡Es hora de descansar, Mando! Vuelve a intentarlo a partir de las 8 de la mañana.";
                return View(viewModel); // Muestra la vista con el mensaje de restricción
            }

            // Cargar las opciones del desplegable
            var nombres = _useCase.ObtenerNombresMisiones();
            viewModel.OpcionesMisiones = nombres.Select(n => new SelectListItem { Text = n, Value = n });

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(MisionViewModel model)
        {
            // Se debe volver a comprobar la hora, por si la petición POST se hizo fuera de horario
            if (!EsHoraValida())
            {
                // Si la hora ya no es válida, devolvemos el mensaje de restricción
                model.MensajeRestriccion = "¡Es hora de descansar, Mando! Vuelve a intentarlo a partir de las 8 de la mañana.";
                return View(model);
            }

            // Recargar las opciones para que el desplegable no esté vacío al refrescar la vista
            var nombres = _useCase.ObtenerNombresMisiones();
            model.OpcionesMisiones = nombres.Select(n => new SelectListItem { Text = n, Value = n });

            // Obtener detalles de la misión seleccionada
            if (!string.IsNullOrEmpty(model.MisionSeleccionada))
            {
                model.DetallesMision = _useCase.ObtenerDetallesMision(model.MisionSeleccionada);
            }

            return View(model);
        }
    }
}