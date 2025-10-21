using TuProyecto.Models.DAL;

namespace TuProyecto.Models.Entities
{
    public class clsPersona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }

        public clsDepartamento Departamento { get; set; }    
    }
}