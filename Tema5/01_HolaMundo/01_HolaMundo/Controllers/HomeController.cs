using System.Diagnostics;
using _01_HolaMundo.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_HolaMundo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Saludar(string txtNombre)
        {
            if (!string.IsNullOrEmpty(txtNombre))
            {
                string mensaje = $"Hola, {txtNombre}";
                ViewBag.Saludo = mensaje;
            }
            else
            {
                ViewBag.Saludo = null;
            }

            return View("Index");
        }
    }
}
