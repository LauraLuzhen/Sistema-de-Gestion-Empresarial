using Data.DataBase;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        /// <summary>
        /// Obtiene todas las categorías de la "base de datos" estática.
        /// </summary>
        /// <returns>Lista de objetos Categoria</returns>
        public List<Categoria> getAll()
        {
            return clsConnection.TablaCategorias;
        }

        /// <summary>
        /// Busca el nombre de una categoría específica por su ID.
        /// </summary>
        /// <param name="id">ID de la categoría</param>
        /// <returns>Nombre de la categoría o string vacío si no existe</returns>
        public string getNombreCategoriaById(int id)
        {
            var categoria = clsConnection.TablaCategorias
                .FirstOrDefault(c => c.id == id);

            return categoria != null ? categoria.nombre : string.Empty;
        }
    }
}