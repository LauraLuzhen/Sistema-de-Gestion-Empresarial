using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Data.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        public List<Departamento> GetListadoDepartamento()
        {
            List<Departamento> lista = new List<Departamento>();

            using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString()))
            {
                string query = "SELECT id, nombre FROM Departamentos";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Departamento
                        {
                            Id = (int)reader["id"],
                            Nombre = reader["nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
    }
}