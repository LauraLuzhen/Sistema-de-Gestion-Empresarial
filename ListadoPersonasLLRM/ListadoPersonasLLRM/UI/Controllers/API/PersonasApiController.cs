using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        # region Inyección de dependencias
        private readonly IPersonaUseCases _peopleUseCases;
        private readonly IDepartamentoUseCases _deptoUseCases;

        public PersonasController(IPersonaUseCases peopleUseCases, IDepartamentoUseCases deptoUseCases)
        {
            _peopleUseCases = peopleUseCases;
            _deptoUseCases = deptoUseCases;
        }
        # endregion

        // GET: api/personas
        [HttpGet]
        public IActionResult GetPersonas()
        {
            var personas = _peopleUseCases.GetPersonasConDetalles();
            return Ok(personas);
        }

        // GET: api/personas/5
        [HttpGet("{id}")]
        public IActionResult GetPersona(int id)
        {
            var persona = _peopleUseCases.GetPersonaById(id);
            if (persona == null) return NotFound();

            // Asignar nombreDepartamento y foto
            var depto = _deptoUseCases.GetDepartamentoById(persona.IDDepartamento);
            persona.NombreDepartamento = depto?.Nombre;
            persona.FotoURL ??= $"https://i.pravatar.cc/500?img={(persona.ID % 70) + 1}";

            return Ok(persona);
        }

        // POST: api/personas
        [HttpPost]
        public IActionResult CreatePersona([FromBody] clsPersona persona)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newId = _peopleUseCases.InsertPersona(persona);
            persona.ID = newId;
            return CreatedAtAction(nameof(GetPersona), new { id = newId }, persona);
        }

        // PUT: api/personas/5
        [HttpPut("{id}")]
        public IActionResult UpdatePersona(int id, [FromBody] clsPersona persona)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != persona.ID) return BadRequest("ID mismatch");

            var existing = _peopleUseCases.GetPersonaById(id);
            if (existing == null) return NotFound();

            _peopleUseCases.UpdatePersona(persona);
            return NoContent();
        }

        // DELETE: api/personas/5
        [HttpDelete("{id}")]
        public IActionResult DeletePersona(int id)
        {
            var existing = _peopleUseCases.GetPersonaById(id);
            if (existing == null) return NotFound();

            _peopleUseCases.DeletePersona(id);
            return NoContent();
        }
    }
}
