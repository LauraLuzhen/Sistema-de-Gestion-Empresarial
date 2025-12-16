using Data.DataBase;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class PlantasRepository : IPlantasRepository
    {
        /// <summary>
        /// Filtra las plantas que pertenecen a una categoría específica.
        /// </summary>
        /// <param name="id">ID de la categoría seleccionada</param>
        /// <returns>Lista de plantas filtradas</returns>
        public List<Planta> getPlantaByCategoriaId(int id)
        {
            return clsConnection.TablaPlantas
                .Where(p => p.idCategoria == id)
                .ToList();
        }

        /// <summary>
        /// Busca una planta única por su ID para mostrar sus detalles en la vista de edición.
        /// </summary>
        /// <param name="id">ID de la planta</param>
        /// <returns>Objeto Planta o null</returns>
        public Planta getPlantaById(int id) => clsConnection.TablaPlantas.FirstOrDefault(p => p.id == id);


        /// <summary>
        /// Actualiza el precio de una planta en la lista estática.
        /// </summary>
        /// <param name="id">ID de la planta a modificar</param>
        /// <param name="precio">Nuevo precio validado</param>
        /// <returns>1 si tuvo éxito, 0 si no encontró la planta</returns>
        public int updatePrecio(int id, double precio)
        {
            var planta = clsConnection.TablaPlantas.FirstOrDefault(p => p.id == id);

            if (planta != null)
            {
                planta.precio = precio;
                return 1; // Registro actualizado correctamente
            }

            return 0; // Error: Planta no encontrada
        }
    }
}