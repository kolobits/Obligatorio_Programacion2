using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
