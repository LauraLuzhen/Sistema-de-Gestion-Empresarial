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
        #region Inyeccion de Dependencias
        // Inyección de dependencias de los repositorios necesarios
        private readonly IDepartamentoUseCases _useCases;

        public DepartamentosController(IDepartamentoUseCases useCases)
        {
            // Se inyecta el Use Case
            _useCases = useCases;
        }
        #endregion

        // GET: api/<DepartamentosController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsDepartamento> listadoCompleto = new List<clsDepartamento>();
            try
            {
                listadoCompleto = _useCases.GetDepartamentos();
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

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsDepartamento departamento = null;
            try
            {
                departamento = _useCases.GetDepartamentoById(id);
                if (departamento == null)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(departamento);
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public IActionResult Post(clsDepartamento departamento)
        {
            if (departamento == null || string.IsNullOrWhiteSpace(departamento.Nombre))
                return BadRequest("El nombre del departamento es obligatorio.");

            try
            {
                if (_useCases.Exists(departamento.Nombre))
                    return Conflict("Ya existe un departamento con este nombre.");

                var idNuevo = _useCases.InsertDepartamento(departamento);
                if (idNuevo <= 0)
                    return StatusCode(500, "No se pudo crear el departamento.");

                // Devolver solo 201 Created sin GetById
                return StatusCode(201, departamento);
            }
            catch
            {
                return StatusCode(500, "Error al crear el departamento.");
            }
        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, clsDepartamento departamento)
        {
            if (departamento == null || id != departamento.ID)
                return BadRequest("Datos inválidos.");

            try
            {
                var filasAfectadas = _useCases.UpdateDepartamento(departamento);
                if (filasAfectadas == 0)
                    return NotFound();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Error al actualizar el departamento.");
            }
        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            bool filasAfectadas = false;
            try
            {
                filasAfectadas = _useCases.TryDeleteDepartamento(id);
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
