using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.UseCases;
using UI.Models;
using Core.Constants;

namespace UI.Controllers
{
    public class GameController : Controller
    {
        private readonly IListadoUseCase _listadoUseCase;
        private readonly IComprobarUseCase _comprobarUseCase;

        public GameController(IListadoUseCase listado, IComprobarUseCase comprobar)
        {
            _listadoUseCase = listado;
            _comprobarUseCase = comprobar;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var personasRepo = _listadoUseCase.GetPersonas();
            var departamentosRepo = _listadoUseCase.GetDepartamentos();

            var model = new GameViewModel
            {
                Departamentos = departamentosRepo,
                Personas = personasRepo.Select(p => new PersonaViewModel
                {
                    Id = p.Id,
                    NombreCompleto = $"{p.Nombre} {p.Apellidos}",
                    ColorClue = AppColors.GetColorByDeptId(p.IdDepartamento),
                    IdDepartamentoSeleccionado = 0
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(GameViewModel model)
        {
            int aciertos = 0;

            foreach (var p in model.Personas)
            {
                bool correcto = _comprobarUseCase.ComprobarSeleccion(p.Id, p.IdDepartamentoSeleccionado);
                p.EsCorrecto = correcto;
                if (correcto) aciertos++;
            }

            model.Gano = aciertos == model.Personas.Count;
            model.MensajeFinal = model.Gano.Value
                ? $"¡Felicidades! Has acertado todos ({aciertos})"
                : $"Has fallado. Aciertos: {aciertos} de {model.Personas.Count}";

            // Volvemos a cargar los departamentos porque no se mantienen en el POST
            model.Departamentos = _listadoUseCase.GetDepartamentos();

            return View(model);
        }
    }
}