using Microsoft.AspNetCore.Mvc;

namespace _01HelloWorld.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult ListadoProductos()
        {
            return View();
        }
    }
}
