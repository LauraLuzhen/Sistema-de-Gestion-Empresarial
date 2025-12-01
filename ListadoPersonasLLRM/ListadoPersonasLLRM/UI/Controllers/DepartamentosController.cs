using Domain.Entities;
using Domain.RepositoriesUseCases;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class DepartamentosController : Controller
    {
        #region Inyeccion de Dependencias
        // Inyección de dependencias de los repositorios necesarios
        private readonly IDepartamentoUseCases _useCases;

        public DepartamentosController(IDepartamentoUseCases useCases)
        {
            // Se inyecta el Use Case
            _useCases = useCases;
        }
        #endregion

        // Index: Lista todos los departamentos
        public IActionResult Index() => View(_useCases.GetDepartamentos());

        #region Details
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var departamento = _useCases.GetDepartamentoById(id.Value);

            if (departamento == null) return NotFound();

            return View(departamento); 
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var departamento = _useCases.GetDepartamentoById(id.Value);
            if (departamento == null) return NotFound();
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Nombre")] clsDepartamento departamento)
        {
            if (id != departamento.ID) return NotFound();

            if (ModelState.IsValid)
            {
                _useCases.UpdateDepartamento(departamento); 
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var departamento = _useCases.GetDepartamentoById(id.Value);

            if (departamento == null) return NotFound();

            return View(departamento); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool success = _useCases.TryDeleteDepartamento(id); 

            if (!success)
            {
                TempData["ErrorMessage"] = "No se puede borrar el departamento porque tiene personas asociadas.";
                return RedirectToAction(nameof(Delete));
            }

            return RedirectToAction(nameof(Index)); 
        }
        #endregion

        #region Create
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nombre")] clsDepartamento departamento)
        {
            if (ModelState.IsValid)
            {
                if (_useCases.Exists(departamento.Nombre))
                {
                    TempData["ErrorMessage"] = "Ya existe un departamento con este nombre. Por favor, elige otro.";
                    return RedirectToAction(nameof(Create));
                    // ERROR con ModelState
                    // ModelState.AddModelError("Nombre", "Ya existe un departamento con este nombre. Por favor, elige otro.");
                }
                else
                {
                    _useCases.InsertDepartamento(departamento);

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(departamento);
        }
        #endregion
    }
}