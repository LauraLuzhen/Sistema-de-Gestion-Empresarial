using System.Collections.Generic;
using TuProyecto.Models.Entities;

namespace TuProyecto.Models.DAL
{
    public static class clsListadoDAL
    {
        public static List<clsDepartamento> GetDepartamentos()
        {
            // Si los departamentos también están en Entities, puedes mover esta lista allí.
            return new List<clsDepartamento>
            {
                new clsDepartamento { IdDepartamento = 1, NombreDepartamento = "Recursos Humanos" },
                new clsDepartamento { IdDepartamento = 2, NombreDepartamento = "Finanzas" },
                new clsDepartamento { IdDepartamento = 3, NombreDepartamento = "Marketing" },
                new clsDepartamento { IdDepartamento = 4, NombreDepartamento = "IT" }
            };
        }

        public static List<clsPersona> GetPersonas()
        {
            // Delegamos la obtención del listado a la clase en Entities
            return clsListadoPersonas.GetPersonas();
        }
    }
}
