using Proyecto.Domain.Entities;
using Proyecto.Domain.Interfaces.Repositories;
using Proyecto.Domain.Interfaces.UseCases;

namespace Proyecto.Domain.UseCases
{
    public class CateogriaUseCase : ICateogriaUseCase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        // Inyección de dependencia del repositorio
        public CateogriaUseCase(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public List<Categoria> getAllCategorias()
        {
            return _categoriaRepository.getAll();
        }

        public string getNombreCategoriaPorId(int id)
        {
            return _categoriaRepository.getNombreCategoriaById(id);
        }
    }
}