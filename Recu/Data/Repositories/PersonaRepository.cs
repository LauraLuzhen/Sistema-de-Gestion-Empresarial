using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Data.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        public List<Persona> getListadoPersonas()
        {
            List<Persona> lista = new List<Persona>();

            using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString()))
            {
                string query = "SELECT id, nombre, apellidos, telefono, direccion, fechanacimiento, idDepartamento FROM Personas";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Persona(
                            (int)reader["id"],
                            reader["nombre"].ToString(),
                            reader["apellidos"].ToString(),
                            reader["telefono"].ToString(), // Asumimos string por formato de teléfono
                            reader["direccion"].ToString(),
                            (DateTime)reader["fechanacimiento"],
                            (int)reader["idDepartamento"]
                        ));
                    }
                }
            }
            return lista;
        }
    }
}