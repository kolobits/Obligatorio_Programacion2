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


		public IActionResult ListarSubastas()
		{
			int? idLogueado = HttpContext.Session.GetInt32("idLogueado");
			if (idLogueado == null)
			{
				ViewBag.Msg = "Por favor, inicie sesión para acceder a esta funcionalidad.";
				return View("Mensaje");
			}

			string rolLogueado = HttpContext.Session.GetString("RolLogueado");
			if (rolLogueado != "ADM")
			{
				ViewBag.Msg = "Acceso denegado: no tiene el rol adecuado para esta funcionalidad.";
				return View("Mensaje");
			}

			IEnumerable<Publicacion> listaSubastas = s.GetSubastas();

			return View(listaSubastas);
		}


	}
}