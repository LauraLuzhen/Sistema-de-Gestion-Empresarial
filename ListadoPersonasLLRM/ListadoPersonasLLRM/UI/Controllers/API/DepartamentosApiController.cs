using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        #region Inyección de dependencias
        private readonly IDepartamentoUseCases _useCases;

        public DepartamentosController(IDepartamentoUseCases useCases)
        {
            _useCases = useCases;
        }
        #endregion

        // GET: api/departamentos
        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            var departamentos = _useCases.GetDepartamentos();
            return Ok(departamentos);
        }

        // GET: api/departamentos/5
        [HttpGet("{id}")]
        public IActionResult GetDepartamento(int id)
        {
            var depto = _useCases.GetDepartamentoById(id);
            if (depto == null) return NotFound();
            return Ok(depto);
        }

        // POST: api/departamentos
        [HttpPost]
        public IActionResult CreateDepartamento([FromBody] clsDepartamento departamento)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newId = _useCases.InsertDepartamento(departamento);
            departamento.ID = newId;
            return CreatedAtAction(nameof(GetDepartamento), new { id = newId }, departamento);
        }

        // PUT: api/departamentos/5
        [HttpPut("{id}")]
        public IActionResult UpdateDepartamento(int id, [FromBody] clsDepartamento departamento)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != departamento.ID) return BadRequest("ID mismatch");

            var existing = _useCases.GetDepartamentoById(id);
            if (existing == null) return NotFound();

            _useCases.UpdateDepartamento(departamento);
            return NoContent();
        }

        // DELETE: api/departamentos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartamento(int id)
        {
            bool success = _useCases.TryDeleteDepartamento(id);
            if (!success) return BadRequest("No se puede eliminar, tiene personas asociadas.");
            return NoContent();
        }
    }
}