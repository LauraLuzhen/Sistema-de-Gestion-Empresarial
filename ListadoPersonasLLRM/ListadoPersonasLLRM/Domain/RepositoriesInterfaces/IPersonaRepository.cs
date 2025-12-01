using System.Collections.Generic;
using Domain.Entities;


namespace Domain.RepositoriesInterfaces
{
    public interface IPersonaRepository 
    {
        /// <summary>
        /// Devuelve todas las personas de la base de datos
        /// </summary>
        /// <returns>El listado de personas</returns>
        List<clsPersona> GetAll();

        /// <summary>
        /// Inserta una nueva persona en la base de datos y devuelve el ID generado.
        /// </summary>
        /// <param name="persona">La persona la cual vamos a insertar</param>
        /// <returns>El nuevo ID de la persona creada</returns>
        int Insert(clsPersona persona);

        /// <summary>
        /// Actualiza una persona existente en la base de datos.
        /// </summary>
        /// <param name="persona">La persona la cual se van a actualizar sus datos</param>
        /// <returns>Devuelve 1 si se encontró la persona sino 0</returns>
        int Update(clsPersona persona);

        /// <summary>
        /// Elimina una persona de la base de datos por su ID.
        /// </summary>
        /// <param name="id">El ID de la persona que se va a eliminar</param>
        /// <returns>Devuelve 1 si existe en la BBDD sino 0</returns>
        bool Delete(int id);

        /// <summary>
        /// Obtiene por el ID la persona correspondiente de la BBDD
        /// </summary>
        /// <param name="id">El ID de la perosna</param>
        /// <returns>La persona del ID introducido por parámetro, sino devuleve null</returns>
        clsPersona GetById(int id);

        /// <summary>
        /// Cuenta el número de personas en un departamento específico introducido por parámetro.
        /// </summary>
        /// <param name="idDepartamento">El ID del departamento que queremos saber la cantidad de personas que hay</param>
        /// <returns>Devuelve la cantidad de personas que hay en el departamento</returns>
        int CountByDepartamentoId(int idDepartamento); 
    }
}