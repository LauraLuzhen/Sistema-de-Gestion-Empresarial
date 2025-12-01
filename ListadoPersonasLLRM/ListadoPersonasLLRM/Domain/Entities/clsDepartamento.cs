using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class clsDepartamento
    {
        #region Atributos
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public clsDepartamento()
        {
            this.ID = 0;
            this.Nombre = string.Empty;
        }

        /// <summary>
        /// Constructor con todos los parámetros 
        /// </summary>
        /// <param name="id">El ID del departamento</param>
        /// <param name="nombre">El nombre del departamento</param>
        public clsDepartamento(int id, string nombre)
        {
            this.ID = id;
            this.Nombre = nombre;
        }
        #endregion
    }
}