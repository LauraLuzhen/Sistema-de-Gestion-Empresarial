using System.Diagnostics;
using _04_TablaMultiplicaciones.Models;
using Microsoft.AspNetCore.Mvc;

namespace _04_TablaMultiplicaciones.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
