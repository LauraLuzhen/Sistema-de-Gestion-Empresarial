using Domain.Entities;

namespace Domain.RepositoriesInterfaces
{
    public interface IDepartamentoRepository
    {
        /// <summary>
        /// Devuelve todos los departamentos de la base de datos.
        /// </summary>
        /// <returns>El listado con todos los departamento de la BBDD</returns>
        List<clsDepartamento> GetAll();

        /// <summary>
        /// Inserta el departamento introducido por parámetro en la base de datos.
        /// </summary>
        /// <param name="departamento">El departamento que queremos añadir</param>
        /// <returns>El ID del nuevo departamento que se ha añadido</returns>
        int Insert(clsDepartamento departamento);

        /// <summary>
        /// Actualiza el departamento introducido por parámetro en la base de datos.
        /// </summary>
        /// <param name="departamento">El departamento al cual se van a actualizar sus datos</param>
        /// <returns>Devuelve 1 si se encontró el departamento y 0 si no</returns>
        int Update(clsDepartamento departamento);

        /// <summary>
        /// Elimina el departamento con el ID introducido por parámetro de la BBDD.
        /// </summary>
        /// <param name="id">El id del departamneto que queremeos eliminar</param>
        /// <returns>Si existe el ID devuelve 1 sino 0</returns>
        bool Delete(int id);

        /// <summary>
        /// Busca un departamento por su ID.
        /// </summary>
        /// <param name="id">El ID del departamento que queremos saber</param>
        /// <returns>El departamento buscado por el ID, sino se encuentra devuelve null</returns>
        clsDepartamento GetById(int id);

        /// <summary>
        /// Cuenta el número de departamentos con un nombre específico introducido por parámetro.
        /// </summary>
        /// <param name="nombre">El nombre del departamento que queremos comprobar</param>
        /// <returns>La cantidad de departamentos que existen con ese nombre</returns>
        int CountByName(string nombre);
    }
}
