using Proyecto.Domain.Dtos;

namespace Proyecto.Domain.Interfaces.UseCases
{
    public interface IPlantaUseCase
    {
        /// <summary>
        /// Ejecuta la lógica de actualización: verifica que el precio nuevo sea mayor al anterior.
        /// </summary>
        /// <returns>1 si se actualizó, -1 si el precio es inválido, 0 si no se encontró.</returns>
        int updatePrecioPlanta(int id, double precio);

        /// <summary>
        /// Prepara el DTO necesario para la vista principal, incluyendo categorías y plantas filtradas.
        /// </summary>
        ListadoPlantaPorCategoriaDto getListadoPlantaPorCategoria(int? idCategoria);

        /// <summary>
        /// Prepara el DTO para la vista de edición de precio de una planta específica.
        /// </summary>
        PlantaPorNombreCategoriaDto getPlataPorNombreCategoria(int? idPlanta);
    }
}