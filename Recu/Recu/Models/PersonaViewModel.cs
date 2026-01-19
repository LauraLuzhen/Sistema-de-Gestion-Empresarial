namespace UI.Models
{
    public class PersonaViewModel
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string ColorClue { get; set; }
        public int IdDepartamentoSeleccionado { get; set; } // Lo que elige el usuario
        public bool? EsCorrecto { get; set; } // Para mostrar feedback individual
    }
}