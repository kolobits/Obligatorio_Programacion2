using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SubastaController : Controller
    {
        Sistema s = Sistema.Instancia();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Update(int id)
        {
            Subasta subastaBuscada = s.GetSubastaPorId(id);

            string rolLogueado = HttpContext.Session.GetString("RolLogueado");
            if (rolLogueado != "ADM")
            {
                ViewBag.Msg = "Acceso denegado: solo los administradores pueden cerrar subastas.";
                return View("Mensaje");
            }

            return View("Update", subastaBuscada);
        }

        [HttpPost]
        public IActionResult CerrarSubasta(int id)
        {
            try
            {
                string rolLogueado = HttpContext.Session.GetString("RolLogueado");
                if (rolLogueado != "ADM")
                {
                    ViewBag.Msg = "Acceso denegado: solo los administradores pueden cerrar subastas.";
                    return View("Mensaje");
                }

                int? idLogueado = HttpContext.Session.GetInt32("idLogueado");
                if (idLogueado == null)
                {
                    ViewBag.Msg = "Debe iniciar sesión como administrador.";
                    return View("Mensaje");
                }

                Administrador adminLogueado = s.GetAdministradorPorId(idLogueado.Value);

                Subasta subastaBuscada = s.GetSubastaPorId(id);
                //if (subastaBuscada == null)
                //{
                //    ViewBag.Msg = "La subasta no existe.";
                //    return RedirectToAction("ListarSubastas");
                //}

                subastaBuscada.CerrarSubasta(adminLogueado);

                ViewBag.MsgExito = "Subasta cerrada con éxito.";
                return View("Update", subastaBuscada);
            }
            catch (Exception e)
            {
                ViewBag.MsgError = e.Message;
                Subasta subastaBuscada = s.GetSubastaPorId(id);
                return View("Update", subastaBuscada);
            }
        }


        public IActionResult Create(int id)
        {
            Subasta subastaBuscada = s.GetSubastaPorId(id);

            int? idLogueado = HttpContext.Session.GetInt32("idLogueado");

            Cliente clienteLogueado = s.GetClientePorId(idLogueado.Value);

            ViewBag.SaldoDisponible = clienteLogueado.SaldoDisponible;

            return View(subastaBuscada);
        }

        [HttpPost]
        public IActionResult Ofertar(int id, double monto)
        {
            try
            {
                int? idLogueado = HttpContext.Session.GetInt32("idLogueado");
                Cliente clienteLogueado = s.GetClientePorId(idLogueado.Value);

                Subasta subastaBuscada = s.GetSubastaPorId(id);

                if (clienteLogueado.SaldoDisponible < monto)
                {
                    ViewBag.MsgError = "Saldo insuficiente para realizar esta oferta.";
                    ViewBag.SaldoDisponible = clienteLogueado.SaldoDisponible.ToString("F2");
                    return View("Create", subastaBuscada);
                }

                Oferta ofertaActual = subastaBuscada.ofertaMasAlta();

                if (ofertaActual != null && monto <= ofertaActual.Monto)
                {
                    ViewBag.MsgError = "La oferta ingresada debe ser mayor a la oferta más alta actual.";
                    ViewBag.SaldoDisponible = clienteLogueado.SaldoDisponible.ToString("F2");
                    return View("Create", subastaBuscada);
                }
                if (ofertaActual.Monto <= 0)
                {
                    ViewBag.MsgError = "La oferta ingresada debe ser mayor a 0.";
                    ViewBag.SaldoDisponible = clienteLogueado.SaldoDisponible.ToString("F2");
                    return View("Create", subastaBuscada);
                }

                Oferta nuevaOferta = new Oferta(clienteLogueado, monto, DateTime.Now);
                subastaBuscada.AgregarOferta(nuevaOferta);

                ViewBag.MsgExito = "Oferta realizada con éxito.";
                ViewBag.SaldoDisponible = clienteLogueado.SaldoDisponible.ToString("F2");

				return View("Create", subastaBuscada);
            }
            catch (Exception e)
            {
                ViewBag.MsgError = e.Message;
                return View("Create", s.GetSubastaPorId(id));
            }
        }

    }
}
