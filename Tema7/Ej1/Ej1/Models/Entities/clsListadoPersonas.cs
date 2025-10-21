using System.Collections.Generic;
using TuProyecto.Models.DAL;

namespace TuProyecto.Models.Entities
{
    public static class clsListadoPersonas
    {
        public static List<clsPersona> GetPersonas()
        {
            var departamentos = new List<clsDepartamento>
            {
                new clsDepartamento { IdDepartamento = 1, NombreDepartamento = "Recursos Humanos" },
                new clsDepartamento { IdDepartamento = 2, NombreDepartamento = "Finanzas" },
                new clsDepartamento { IdDepartamento = 3, NombreDepartamento = "Marketing" },
                new clsDepartamento { IdDepartamento = 4, NombreDepartamento = "IT" }
            };

            return new List<clsPersona>
            {
                new clsPersona { Nombre = "Ana", Apellidos = "López", Edad = 25, Departamento = departamentos[0] },
                new clsPersona { Nombre = "Carlos", Apellidos = "Martín", Edad = 32, Departamento = departamentos[1] },
                new clsPersona { Nombre = "Lucía", Apellidos = "Fernández", Edad = 28, Departamento = departamentos[2] },
                new clsPersona { Nombre = "Miguel", Apellidos = "Sánchez", Edad = 40, Departamento = departamentos[3] },
                new clsPersona { Nombre = "Laura", Apellidos = "Ramírez", Edad = 22, Departamento = departamentos[0] },
                new clsPersona { Nombre = "David", Apellidos = "Castro", Edad = 35, Departamento = departamentos[1] }
            };
        }
    }
}
