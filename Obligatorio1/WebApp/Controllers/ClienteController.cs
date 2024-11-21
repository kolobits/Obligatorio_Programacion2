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
            IEnumerable<Publicacion> listaPublicaciones = s.GetPublicaciones();
            return View(listaPublicaciones);
        }
        


        public IActionResult RecargarBilletera()
        {
            int idLogueado = HttpContext.Session.GetInt32("idLogueado").Value;
            Cliente clienteLogueado = s.GetClientePorId(idLogueado);

            ViewBag.NombreCliente = clienteLogueado.Nombre;
            ViewBag.SaldoActual = clienteLogueado.SaldoDisponible;

            return View();
        }



        [HttpPost]
        public IActionResult RecargarBilletera(double monto)
        {
            try
            {
                // Validar que el monto sea mayor a 0
                if (monto <= 0)
                {
                    ViewBag.MsgError = "El monto debe ser mayor a 0.";
                    return View(); // Retornamos la vista directamente para mostrar el error
                }

                // Obtener el ID del cliente logueado desde la sesión
                int idLogueado = HttpContext.Session.GetInt32("idLogueado").Value;

                // Obtener el cliente logueado
                Cliente clienteLogueado = s.GetClientePorId(idLogueado);

                // Recargar billetera
                s.RecargarBilletera(idLogueado, monto);

                // Configurar ViewBag con información actualizada
                ViewBag.NombreCliente = clienteLogueado.Nombre;
                ViewBag.SaldoActual = clienteLogueado.SaldoDisponible;
                ViewBag.MsgExito = $"Se han recargado ${monto} correctamente.";

                // Retornar la vista con los datos actualizados
                return View();
            }
            catch (Exception e)
            {
                // Capturar cualquier excepción y mostrar el mensaje de error
                ViewBag.MsgError = e.Message;
                return View();
            }
        }



    }
}
