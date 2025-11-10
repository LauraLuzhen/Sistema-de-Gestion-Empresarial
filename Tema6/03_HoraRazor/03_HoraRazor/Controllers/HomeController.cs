using System.Diagnostics;
using _03_HoraRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace _03_HoraRazor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var horaAtual = DateTime.Now;
            if (horaAtual.Hour <= 12 && horaAtual.Hour>= 00)
            {
                ViewBag.Antes12 = true;
            }
            else
            {
                ViewBag.Antes12 = false;
            }

            ViewBag.Hora = horaAtual.ToString("HH:mm:ss");

            return View();
        }
    }
}
