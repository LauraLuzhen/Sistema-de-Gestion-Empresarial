using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Domain.UseCases
{
    // Implementa IPersonaUseCases
    public class PersonaUseCases : IPersonaUseCases
    {
        #region Inyeccion de Dependencias
        // Inyección de dependencias de los repositorios necesarios
        private readonly IPersonaRepository _repo;
        private readonly IDepartamentoRepository _deptoRepo;

        public PersonaUseCases(IPersonaRepository repo, IDepartamentoRepository deptoRepo)
        {
            _repo = repo;
            _deptoRepo = deptoRepo;
        }
        #endregion

        #region Métodos de negocio
        /// <summary>
        /// Listado de personas con detalles adicionales (NombreDepartamento y FotoURL)
        /// </summary>
        /// <returns>El listado de personas listo para la UI</returns>
        public List<clsPersona> GetPersonasConDetalles()
        {
            // Obtener los datos puros
            var personas = _repo.GetAll();

            // Obtener la lista de departamentos
            var departamentos = _deptoRepo.GetAll();

            foreach (var persona in personas)
            {
                var depto = departamentos.FirstOrDefault(d => d.ID == persona.IDDepartamento);
                persona.NombreDepartamento = depto?.Nombre ?? "Sin Departamento";

                int imageId = (persona.ID % 70) + 1;
                persona.FotoURL = $"https://i.pravatar.cc/500?img={imageId}";
            }

            return personas;
        }


        // Métodos CRUD básicos delegados al repositorio
        public int InsertPersona(clsPersona persona) => _repo.Insert(persona);

        public int UpdatePersona(clsPersona persona) => _repo.Update(persona);

        public bool DeletePersona(int id) => _repo.Delete(id);

        public clsPersona GetPersonaById(int id) => _repo.GetById(id);
        #endregion
    }
}