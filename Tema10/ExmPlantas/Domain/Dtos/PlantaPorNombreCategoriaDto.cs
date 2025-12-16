using Proyecto.Domain.Entities;

namespace Proyecto.Domain.Dtos
{
    public class PlantaPorNombreCategoriaDto
    {
        // El ID de la planta específica
        public int idPlanta { get; set; }

        // El objeto planta con toda su información (Nombre, Descripcion, Categoria, etc.)
        public Planta planta { get; set; }

        public PlantaPorNombreCategoriaDto() { }

        public PlantaPorNombreCategoriaDto(int idPlanta, Planta planta)
        {
            this.idPlanta = idPlanta;
            this.planta = planta;
        }
    }
}