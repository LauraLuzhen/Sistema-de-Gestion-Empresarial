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
        #region Inyeccion de Dependencias
        // Inyección de dependencias de los repositorios necesarios
        private readonly IPersonaUseCases _peopleUseCases;

        public PersonasController(IPersonaUseCases peopleUseCases)
        {
            _peopleUseCases = peopleUseCases;
        }
        #endregion


        // GET: api/Personas
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> listadoCompleto = new List<clsPersona>();
            try
            {
                listadoCompleto = _peopleUseCases.GetPersonasConDetalles();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/Personas/3
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsPersona persona = null;
            try
            {
                persona = _peopleUseCases.GetPersonaById(id);
                if (persona == null)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(persona);
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/Personas
        [HttpPost]
        public IActionResult Create(clsPersona persona)
        {
            IActionResult salida;
            if (persona == null || string.IsNullOrWhiteSpace(persona.Nombre))
                salida = BadRequest();

            try
            {
                var idNuevo = _peopleUseCases.InsertPersona(persona);


                salida = Ok();
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // PUT api/Personas/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, clsPersona persona)
        {
            IActionResult salida;
            if (persona == null || id != persona.ID)
                salida = BadRequest();

            try
            {
                var filasAfectadas = _peopleUseCases.UpdatePersona(persona);
                if (filasAfectadas == 0)
                    salida = NotFound();

                salida = Ok();
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }


        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            bool filasAfectadas = false;
            try
            {
                filasAfectadas = _peopleUseCases.DeletePersona(id);
                if (filasAfectadas)
                {
                    salida = Ok();
                }
                else
                {
                    salida = NotFound();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }
            return salida;
        }
    }
}
