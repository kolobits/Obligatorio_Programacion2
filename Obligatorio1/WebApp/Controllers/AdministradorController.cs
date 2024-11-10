using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdministradorController : Controller
    {
        Sistema s = Sistema.Instancia();

        public IActionResult Index()
        {
        //    Usuario usuarioBuscado = GetUsuarioLogueado();

        //ViewBag.MsgNombreLog = usuarioBuscado.Nombre;
        //ViewBag.MsgRolLog = usuarioBuscado.GetRol();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}