
namespace Data.DataBase
{
    public class clsConnection
    {
        /// <summary>
        /// Conexión a la base de datos Azure SQL PersonasDB
        /// </summary>
        /// <returns>Todos los datos del servidor</returns>
        public static string GetConnectionString()
        {
            return "server=lauradb.database.windows.net;database=PersonasDB;uid=laura;pwd=abc123@.;trustServerCertificate = true;";
        }
    }
}
