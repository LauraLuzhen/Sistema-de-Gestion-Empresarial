using Data.DataBase;
using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Microsoft.Data.SqlClient;

namespace Data.Repositories 
{
    // Implementa IDepartamentoRepository
    public class DepartamentoRepositoryAzure : IDepartamentoRepository
    {
        #region ListadoDepartamentos
        /// <summary>
        /// Devuelve todos los departamentos de la base de datos.
        /// </summary>
        /// <returns>El listado con todos los departamento de la BBDD</returns>
        public List<clsDepartamento> GetAll()
        {
            var departamentos = new List<clsDepartamento>();
            string connectionString = clsConnection.GetConnectionString();
            string sql = "SELECT ID, Nombre FROM Departamentos";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departamentos.Add(new clsDepartamento
                        {
                            ID = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        });
                    }
                }
            }
            return departamentos;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Inserta el departamento introducido por parámetro en la base de datos.
        /// </summary>
        /// <param name="departamento">El departamento que queremos añadir</param>
        /// <returns>El ID del nuevo departamento que se ha añadido</returns>
        public int Insert(clsDepartamento departamento)
        {
            string connectionString = clsConnection.GetConnectionString();
            string sql = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre); SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Actualiza el departamento introducido por parámetro en la base de datos.
        /// </summary>
        /// <param name="departamento">El departamento al cual se van a actualizar sus datos</param>
        /// <returns>Devuelve 1 si se encontró el departamento y 0 si no</returns>
        public int Update(clsDepartamento departamento)
        {
            string connectionString = clsConnection.GetConnectionString();
            string sql = "UPDATE Departamentos SET Nombre = @Nombre WHERE ID = @ID";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                command.Parameters.AddWithValue("@ID", departamento.ID);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Elimina el departamento con el ID introducido por parámetro de la BBDD.
        /// </summary>
        /// <param name="id">El id del departamneto que queremeos eliminar</param>
        /// <returns>Si existe el ID devuelve 1 sino 0</returns>
        public bool Delete(int id)
        {
            string connectionString = clsConnection.GetConnectionString();
            string sql = "DELETE FROM Departamentos WHERE ID = @ID";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        #endregion

        #region DepartamentoPorID
        /// <summary>
        /// Busca un departamento por su ID.
        /// </summary>
        /// <param name="id">El ID del departamento que queremos saber</param>
        /// <returns>El departamento buscado por el ID, sino se encuentra devuelve null</returns>
        public clsDepartamento GetById(int id)
        {
            string connectionString = clsConnection.GetConnectionString();
            string sql = "SELECT ID, Nombre FROM Departamentos WHERE ID = @ID";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new clsDepartamento
                        {
                            ID = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }
        #endregion

        #region CountDepartamentosPorNombre
        /// <summary>
        /// Cuenta el número de departamentos con un nombre específico introducido por parámetro.
        /// </summary>
        /// <param name="nombre">El nombre del departamento que queremos comprobar</param>
        /// <returns>La cantidad de departamentos que existen con ese nombre</returns>
        public int CountByName(string nombre)
        {
            string connectionString = clsConnection.GetConnectionString();
            string sql = "SELECT COUNT(*) FROM Departamentos WHERE Nombre = @Nombre";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);
                connection.Open();
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
        #endregion
    }
}

