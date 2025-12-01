using Domain.Entities;

namespace Domain.RepositoriesInterfaces
{
    public interface IPersonaUseCases
    {
        /// <summary>
        /// Lista de personas con detalles adicionales como la foto.
        /// </summary>
        /// <returns>El listado de personas que se va a ver en la UI</returns>
        List<clsPersona> GetPersonasConDetalles();

        /// <summary>
        /// Añade una nueva persona a la base de datos.
        /// </summary>
        /// <param name="persona">La persona que queremos agregar</param>
        /// <returns>El nuevo ID de la persona creada</returns>
        int InsertPersona(clsPersona persona);

        /// <summary>
        /// Actualiza una persona existente en la base de datos.
        /// </summary>
        /// <param name="persona">La persona la cual se van a actualizar sus datos</param>
        /// <returns>Devuelve 1 si se encontró la persona sino 0</returns>
        int UpdatePersona(clsPersona persona);

        /// <summary>
        /// Elimina una persona de la base de datos por su ID.
        /// </summary>
        /// <param name="id">El ID de la persona que se va a eliminar</param>
        /// <returns>Devuelve 1 si existe en la BBDD sino 0</returns>
        bool DeletePersona(int id);

        /// <summary>
        /// Obtiene por el ID la persona correspondiente de la BBDD
        /// </summary>
        /// <param name="id">El ID de la perosna</param>
        /// <returns>La persona del ID introducido por parámetro, sino devuleve null</returns>
        clsPersona GetPersonaById(int id);
    }
}