using Domain.Entities;

namespace Domain.RepositoriesUseCases
{
    public interface IDepartamentoUseCases
    {
        /// <summary>
        /// Devuelve todos los departamentos de la base de datos.
        /// </summary>
        /// <returns>El listado con todos los departamento de la BBDD</returns>
        List<clsDepartamento> GetDepartamentos();

        /// <summary>
        /// Inserta el departamento introducido por parámetro en la base de datos.
        /// </summary>
        /// <param name="departamento">El departamento que queremos añadir</param>
        /// <returns>El ID del nuevo departamento que se ha añadido</returns>
        int InsertDepartamento(clsDepartamento departamento);

        /// <summary>
        /// Actualiza el departamento introducido por parámetro en la base de datos.
        /// </summary>
        /// <param name="departamento">El departamento al cual se van a actualizar sus datos</param>
        /// <returns>Devuelve 1 si se encontró el departamento y 0 si no</returns>
        int UpdateDepartamento(clsDepartamento departamento);

        /// <summary>
        /// Busca un departamento por su ID.
        /// </summary>
        /// <param name="id">El ID del departamento que queremos saber</param>
        /// <returns>El departamento buscado por el ID, sino se encuentra devuelve null</returns>
        clsDepartamento GetDepartamentoById(int id);

        /// <summary>
        /// Compruba si se puede eliminar el departamento con el ID introducido por parámetro de la BBDD.
        /// </summary>
        /// <param name="id">El id del departamneto que queremeos eliminar</param>
        /// <returns>Si se ha eliminado correctamente devuelve true, en caso contrario false/returns>
        bool TryDeleteDepartamento(int id);

        /// <summary>
        /// Indica si existe el departamento con el nombre introducido por parámetro.
        /// </summary>
        /// <param name="nombre">El nombre del departamento</param>
        /// <returns>Si existe devuelve true, sino false</returns>
        bool Exists(string nombre);
    }
}