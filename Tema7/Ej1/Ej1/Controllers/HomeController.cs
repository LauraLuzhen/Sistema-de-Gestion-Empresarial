using Microsoft.AspNetCore.Mvc;
using TuProyecto.Models.Entities;

namespace TuProyecto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var hora = DateTime.Now.Hour;
            string saludo = hora < 12 ? "Buenos días" : hora < 20 ? "Buenas tardes" : "Buenas noches";
            ViewData["Saludo"] = saludo;
            ViewBag.Fecha = DateTime.Now.ToLongDateString();

            var persona = new clsPersona
            {
                Nombre = "Laura Luzhen",
                Apellidos = "Rodríguez Morán",
                Edad = 20
            };

            return View(persona);
        }

        public ActionResult listadoPersonas()
        {
            var personas = clsListadoPersonas.GetPersonas();
            return View(personas);
        }

        public ActionResult detallePersona()
        {
            var personas = clsListadoPersonas.GetPersonas();
            var personaSeleccionada = personas[2]; // posición 3 (índice 2)
            return View(personaSeleccionada);
        }

        


    }
}
