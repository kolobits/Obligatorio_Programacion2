using System.Diagnostics;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
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

		public IActionResult Privacy()
        {
            return View();
        }

       public IActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Login(Cliente c)
		{
			try
			{
				Usuario usuarioBuscado = s.Login(c.Email, c.Contrasena);

				if (usuarioBuscado != null)
				{
					
					HttpContext.Session.SetInt32("idLogueado", usuarioBuscado.Id);
					
					HttpContext.Session.SetString("RolLogueado", usuarioBuscado.GetRol());
					
					HttpContext.Session.SetString("NombreLogueado", usuarioBuscado.Nombre);
                    
                    HttpContext.Session.SetString("ApellidoLogueado", usuarioBuscado.Apellido);


                    if (usuarioBuscado.GetRol() == "ADM")
                    {
                        return RedirectToAction("Index", "Administrador");
                    }
                    else if (usuarioBuscado.GetRol() == "CLI")
                    {
                        return RedirectToAction("Index", "Cliente");
                    }

                }
				else
				{
					ViewBag.Msg = "Email o contraseña incorrectos.";
				}

			}
			catch (Exception)
			{

				throw;
			}


			return View();
		}

        //LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


    }
}
