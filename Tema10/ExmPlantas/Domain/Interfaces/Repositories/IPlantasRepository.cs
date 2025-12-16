using Proyecto.Domain.Entities;

namespace Proyecto.Domain.Interfaces.Repositories
{
    public interface IPlantasRepository
    {
        /// <summary>
        /// Obtiene todas las plantas que pertenecen a una categoría específica.
        /// </summary>
        /// <param name="id">ID de la categoría por la que filtrar.</param>
        /// <returns>Lista de objetos Planta.</returns>
        List<Planta> getPlantaByCategoriaId(int id);

        /// <summary>
        /// Obtiene los detalles de una planta específica por su ID.
        /// </summary>
        /// <param name="id">ID único de la planta.</param>
        /// <returns>Un objeto de tipo Planta.</returns>
        Planta getPlantaById(int id);

        /// <summary>
        /// Actualiza el valor del precio de una planta en el sistema.
        /// </summary>
        /// <param name="id">ID de la planta a modificar.</param>
        /// <param name="precio">Nuevo precio a asignar.</param>
        /// <returns>Un entero que representa las filas afectadas (1 si tuvo éxito, 0 si no).</returns>
        int updatePrecio(int id, double precio);
    }
}