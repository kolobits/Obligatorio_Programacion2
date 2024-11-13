using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {
        Sistema s = Sistema.Instancia();
        public IActionResult Index()
        {
            //List<Publicacion> listaPublicaciones = s.GetPublicaciones();
            //ViewBag.Publicacion = listaPublicaciones;
            //return View();

            string nombreLogueado = HttpContext.Session.GetString("NombreLogueado");
            ViewBag.MsgNombreLog = nombreLogueado;

            string RolUsuario = HttpContext.Session.GetString("RolLogueado");
            ViewBag.MsgRolLog = RolUsuario;
            return View();
        }

        public IActionResult Create()
        {
			if (HttpContext.Session.GetInt32("idLogueado") != null)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
        }

		[HttpPost]
		public IActionResult Create(Cliente c)
		{
			try
			{
				s.AltaUsuario(c);
				ViewBag.Msg = "Persona creada correctamente";
			}
			catch (Exception e)
			{
				ViewBag.Msg = e.Message;
			}
			return View();
		}

		//public IActionResult Buy()
  //      {
  //          List<Publicacion> publicaciones = s.GetPublicaciones();

  //          return View(publicaciones);

  //      }
    }
}
