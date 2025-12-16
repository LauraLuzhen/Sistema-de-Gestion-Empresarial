using Proyecto.Domain.Entities;
using System.Collections.Generic;

namespace Proyecto.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        /// <summary>
        /// Obtiene el listado completo de categorías disponibles.
        /// </summary>
        /// <returns>Una lista de objetos Categoria.</returns>
        List<Categoria> getAll();

        /// <summary>
        /// Obtiene el nombre de una categoría a partir de su identificador.
        /// </summary>
        /// <param name="id">ID de la categoría.</param>
        /// <returns>El nombre de la categoría como String.</returns>
        string getNombreCategoriaById(int id);
    }
}