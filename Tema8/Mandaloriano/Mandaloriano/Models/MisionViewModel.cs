using MandoMissions.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MandoMissions.Models
{
    public class MisionViewModel
    {
        // Propiedad para recibir el valor seleccionado del desplegable
        public string MisionSeleccionada { get; set; }

        // Lista para popular el desplegable
        public IEnumerable<SelectListItem> OpcionesMisiones { get; set; }

        // Datos de la misión para mostrar detalles
        public clsMision DetallesMision { get; set; }

        // Mensaje de error/restricción
        public string MensajeRestriccion { get; set; }
    }
}