using Microsoft.AspNetCore.Mvc;
using TuProyecto.Models.Entities;

namespace TuProyecto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var hora = DateTime.Now.Hour;
            string saludo = hora < 12 ? "Buenos d�as" : hora < 20 ? "Buenas tardes" : "Buenas noches";
            ViewData["Saludo"] = saludo;
            ViewBag.Fecha = DateTime.Now.ToLongDateString();

            var persona = new clsPersona
            {
                Nombre = "Laura Luzhen",
                Apellidos = "Rodr�guez Mor�n",
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
            var personaSeleccionada = personas[2]; // posici�n 3 (�ndice 2)
            return View(personaSeleccionada);
        }

        


    }
}
