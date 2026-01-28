
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities 
{ 
	public class clsPersona
	{
        #region Atributos
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Los apellidos son obligatorios")]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage ="El teléfono es obligatorio")]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Required(ErrorMessage ="La dirección es obligatoria")]
        [StringLength(200)]
        public string Direccion { get; set; }

        // Ruta de la foto
        public string FotoURL { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public int IDDepartamento { get; set; }

        public string? NombreDepartamento { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public clsPersona()
        {
            this.ID = 0;
            this.Nombre = string.Empty;
            this.Apellidos = string.Empty;
            this.Telefono = string.Empty;
            this.Direccion = string.Empty;
            this.FotoURL = string.Empty;
            this.FechaNacimiento = DateTime.Today;
            this.IDDepartamento = 0;
        }

        public clsPersona(string nombre, string apellidos, string telefono, string direccion, DateTime fechaNacimiento, int idDepartamento)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.FechaNacimiento = fechaNacimiento;
            this.IDDepartamento = idDepartamento;
        }
        #endregion
    }
}