using Proyecto.Domain.Entities;

namespace Proyecto.Domain.Interfaces.UseCases
{
    public interface ICateogriaUseCase
    {
        /// <summary>
        /// Recupera todas las categorías para llenar el desplegable de la vista.
        /// </summary>
        List<Categoria> getAllCategorias();

        /// <summary>
        /// Obtiene el nombre descriptivo de una categoría mediante su ID.
        /// </summary>
        string getNombreCategoriaPorId(int id);
    }
}