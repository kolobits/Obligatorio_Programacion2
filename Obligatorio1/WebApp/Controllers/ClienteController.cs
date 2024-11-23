using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
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
                ViewBag.MsgExito = "Persona creada correctamente";
            }
            catch (Exception e)
            {
                ViewBag.MsgError = e.Message;
            }
            return View();
        }


        public IActionResult Listar()
        {			
			int? idLogueado = HttpContext.Session.GetInt32("idLogueado");
			if (idLogueado == null)
			{
                ViewBag.Msg = "Por favor, inicie sesión para acceder a esta funcionalidad.";
                return View("Mensaje"); 
            }

			string rolLogueado = HttpContext.Session.GetString("RolLogueado");
			if (rolLogueado != "CLI")
			{
                ViewBag.Msg = "Acceso denegado: no tiene el rol adecuado para esta funcionalidad.";
                return View("Mensaje");
            }

			IEnumerable<Publicacion> listaPublicaciones = s.GetPublicaciones();

            return View(listaPublicaciones);
        }
        


        public IActionResult RecargarBilletera()
        {
            int? idLogueado = HttpContext.Session.GetInt32("idLogueado");
            if (idLogueado == null)
            {
                ViewBag.Msg = "Por favor, inicie sesión para acceder a esta funcionalidad.";
                return View("Mensaje");
            }

            string rolLogueado = HttpContext.Session.GetString("RolLogueado");
            if (rolLogueado != "CLI")
            {
                ViewBag.Msg = "Acceso denegado: no tiene el rol adecuado para esta funcionalidad.";
                return View("Mensaje");
            }

            Cliente clienteLogueado = s.GetClientePorId(idLogueado.Value);

            ViewBag.NombreCliente = clienteLogueado.Nombre;
            ViewBag.SaldoActual = clienteLogueado.SaldoDisponible.ToString("F2");

            return View();
        }



        [HttpPost]
        public IActionResult RecargarBilletera(double monto)
        {
            try
            {
                if (monto <= 0)
                {
                    ViewBag.MsgError = "El monto debe ser mayor a 0.";
                    return View();
                }

                int idLogueado = HttpContext.Session.GetInt32("idLogueado").Value;

                Cliente clienteLogueado = s.GetClientePorId(idLogueado);

                s.RecargarBilletera(idLogueado, monto);

                ViewBag.NombreCliente = clienteLogueado.Nombre;
                ViewBag.SaldoActual = clienteLogueado.SaldoDisponible;
                ViewBag.MsgExito = $"Se han recargado ${monto} correctamente.";

                return View();
            }
            catch (Exception e)
            {
                ViewBag.MsgError = e.Message;
                return View();
            }
        }



    }
}
