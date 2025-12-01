using Domain.Entities;
using Domain.RepositoriesUseCases; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.RepositoriesInterfaces;

namespace UI.Controllers
{
    public class PersonasController : Controller
    {
        #region Inyeccion de Dependencias
        // Inyección de dependencias de los repositorios necesarios
        private readonly IPersonaUseCases _peopleUseCases;
        private readonly IDepartamentoUseCases _deptoUseCases; 

        public PersonasController(IPersonaUseCases peopleUseCases, IDepartamentoUseCases deptoUseCases)
        {
            _peopleUseCases = peopleUseCases;
            _deptoUseCases = deptoUseCases;
        }
        #endregion

        // Método para lista de departamentos en DropDownList
        private void PopulateDepartamentosDropDownList(object selectedDepartment = null)
        {
            var departamentos = _deptoUseCases.GetDepartamentos();

            ViewData["IDDepartamento"] = new SelectList(
                departamentos,
                "ID",         
                "Nombre",     
                selectedDepartment 
            );
        }

        // Index: Muestra la lista de personas
        public IActionResult Index()
        {
            var personas = _peopleUseCases.GetPersonasConDetalles();
            return View(personas);
        }

        #region Details
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var persona = _peopleUseCases.GetPersonaById(id.Value);
            if (persona == null) return NotFound();

            if (string.IsNullOrEmpty(persona.NombreDepartamento))
            {
                var depto = _deptoUseCases.GetDepartamentoById(persona.IDDepartamento);
                persona.NombreDepartamento = depto?.Nombre;
            }

            persona.FotoURL = $"https://i.pravatar.cc/500?img={(persona.ID % 70) + 1}";

            return View(persona);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            PopulateDepartamentosDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nombre, Apellidos, Telefono, Direccion, FechaNacimiento, IDDepartamento")] clsPersona persona)
        {
            if (ModelState.IsValid)
            {
                _peopleUseCases.InsertPersona(persona);
                return RedirectToAction(nameof(Index));
            }

            PopulateDepartamentosDropDownList(persona.IDDepartamento);
            return View(persona);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var persona = _peopleUseCases.GetPersonaById(id.Value);

            if (persona == null) return NotFound();

            PopulateDepartamentosDropDownList(persona.IDDepartamento);

            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, Nombre, Apellidos, Telefono, Direccion, FechaNacimiento, IDDepartamento")] clsPersona persona)
        {
            if (id != persona.ID) return NotFound();

            if (ModelState.IsValid)
            {
                _peopleUseCases.UpdatePersona(persona);
                return RedirectToAction(nameof(Index));
            }

            PopulateDepartamentosDropDownList(persona.IDDepartamento);
            return View(persona);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var persona = _peopleUseCases.GetPersonaById(id.Value);

            if (persona == null) return NotFound();

            var depto = _deptoUseCases.GetDepartamentoById(persona.IDDepartamento);
            persona.NombreDepartamento = depto?.Nombre;
            persona.FotoURL = $"https://i.pravatar.cc/500?img={(persona.ID % 70) + 1}";

            return View(persona);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _peopleUseCases.DeletePersona(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}