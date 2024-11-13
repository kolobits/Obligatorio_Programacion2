using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdministradorController : Controller
    {
        Sistema s = Sistema.Instancia();

        public IActionResult Index()
        {
            string nombreLogueado = HttpContext.Session.GetString("NombreLogueado");
            ViewBag.MsgNombreLog = nombreLogueado;

            string RolUsuario = HttpContext.Session.GetString("RolLogueado");
            ViewBag.MsgRolLog = RolUsuario;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}