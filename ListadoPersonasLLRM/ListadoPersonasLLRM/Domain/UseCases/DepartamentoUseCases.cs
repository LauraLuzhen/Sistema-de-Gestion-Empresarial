using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Domain.RepositoriesUseCases;

namespace Domain.UseCases
{
    // Implementa IDepartamentoUseCases
    public class DepartamentoUseCases : IDepartamentoUseCases
    {
        #region Inyeccion de Dependencias
        // Inyección de dependencias de los repositorios necesarios
        private readonly IDepartamentoRepository _deptoRepo;
        private readonly IPersonaRepository _peopleRepo;

        public DepartamentoUseCases(IDepartamentoRepository deptoRepo, IPersonaRepository peopleRepo)
        {
            _deptoRepo = deptoRepo;
            _peopleRepo = peopleRepo;
        }
        #endregion

        #region Métodos de negocio
        public List<clsDepartamento> GetDepartamentos() => _deptoRepo.GetAll();
        
        public int InsertDepartamento(clsDepartamento departamento) => _deptoRepo.Insert(departamento);

        public int UpdateDepartamento(clsDepartamento departamento) => _deptoRepo.Update(departamento);

        public clsDepartamento GetDepartamentoById(int id) => _deptoRepo.GetById(id);

        /// <summary>
        /// Comprueba si se puede eliminar el departamento, si hay personas no se puede
        /// </summary>
        /// <param name="id">El ID del departamento</param>
        /// <returns>Si hay personas devuelve false, sino ejecutamos la función delete</returns>
        public bool TryDeleteDepartamento(int id)
        {
            if (_peopleRepo.CountByDepartamentoId(id) > 0)
            {
                return false;
            }

            return _deptoRepo.Delete(id);
        }

        public bool Exists(string nombre) => _deptoRepo.CountByName(nombre) > 0;
        #endregion
    }
}
