using Proyecto.Domain.Entities;

namespace Proyecto.Domain.Dtos
{
    public class ListadoPlantaPorCategoriaDto
    {
        // El ID de la categoría que el usuario seleccionó en el desplegable
        public int idCategoria { get; set; }

        // Listado de todas las categorías disponibles para el DropDownList
        public List<Categoria> listaCategorias { get; set; }

        // Listado de plantas filtradas que se mostrarán en la tabla
        public List<Planta> listaPlantas { get; set; }

        public ListadoPlantaPorCategoriaDto()
        {
            listaCategorias = new List<Categoria>();
            listaPlantas = new List<Planta>();
        }
    }
}