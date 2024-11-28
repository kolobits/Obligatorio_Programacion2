using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	public class VentaController : Controller
	{
		Sistema s = Sistema.Instancia();

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create(int id)
		{
			try
			{
				Venta ventaBuscada = s.GetVentaPorId(id);

				int? idLogueado = HttpContext.Session.GetInt32("idLogueado");
				if (idLogueado == null)
				{
					return RedirectToAction("Login", "Home");
				}

				Cliente clienteLogueado = s.GetClientePorId(idLogueado.Value);
				if (clienteLogueado == null)
				{
					return RedirectToAction("Login", "Home");
				}
				ViewBag.SaldoDisponible = clienteLogueado.SaldoDisponible;

				return View(ventaBuscada);
			}
			catch (Exception e)
			{
				ViewBag.MsgError = e.Message;
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public IActionResult FinalizarCompra(int id)
		{
			try
			{
				int? idLogueado = HttpContext.Session.GetInt32("idLogueado");
				if (idLogueado == null)
				{
					return RedirectToAction("Login", "Home");
				}

				Cliente clienteLogueado = s.GetClientePorId(idLogueado.Value);
				if (clienteLogueado == null)
				{
					return RedirectToAction("Login", "Home");
				}

				Publicacion publicacion = s.GetPublicacionPorId(id);

				if (clienteLogueado.SaldoDisponible < publicacion.CalcularPrecioFinal())
				{
					ViewBag.MsgError = "No tienes suficiente saldo disponible para realizar esta compra.";
					ViewBag.SaldoDisponible = clienteLogueado.SaldoDisponible;
					return View("Create", publicacion);
				}

				Venta ventaBuscada = (Venta)publicacion;

				publicacion.CerrarPublicacion(clienteLogueado);

				ViewBag.MsgExito = "Compra finalizada exitosamente.";
				ViewBag.SaldoDisponible = clienteLogueado.SaldoDisponible;

				return View("Create", ventaBuscada);
			}
			catch (Exception e)
			{
				ViewBag.MsgError = e.Message;
				return RedirectToAction("Create", new { id });
			}
		}
	}
}
