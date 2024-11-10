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
					//Guardar el id
					HttpContext.Session.SetInt32("idLogueado", usuarioBuscado.Id);
					//Guardar el rol
					HttpContext.Session.SetString("RolLogueado", usuarioBuscado.GetRol());
					//Guardo el nombre
					HttpContext.Session.SetString("NombreLogueado", usuarioBuscado.Nombre);
                    //Guardo el Apellido
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
					ViewBag.Msg = "Ingrese datos correctos";
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
