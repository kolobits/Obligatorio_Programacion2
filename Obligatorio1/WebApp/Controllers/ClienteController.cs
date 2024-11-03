using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {
        Sistema s = Sistema.Instancia();
        public IActionResult Index()
        {
            List<Publicacion> listaPublicaciones = s.GetPublicaciones();
            ViewBag.Publicacion = listaPublicaciones;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Buy()
        {
            List<Publicacion> publicaciones = s.GetPublicaciones();

            return View(publicaciones);

        }
    }
}
