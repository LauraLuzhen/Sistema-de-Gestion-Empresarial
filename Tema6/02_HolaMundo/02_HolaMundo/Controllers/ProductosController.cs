using Microsoft.AspNetCore.Mvc;

namespace _02_HolaMundo.Controllers
{
    public class ProductosController : Controller
    {
        public ViewResult ListadoProductos()
        {
            return View("ListadoProductos");
        }
    }
}
