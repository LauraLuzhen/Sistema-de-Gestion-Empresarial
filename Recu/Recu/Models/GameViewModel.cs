using Domain.Entities;

namespace UI.Models
{
    public class GameViewModel
    {
        public List<PersonaViewModel> Personas { get; set; } = new();
        public List<Departamento> Departamentos { get; set; } = new();
        public string? MensajeFinal { get; set; }
        public bool? Gano { get; set; }
    }
}