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


			Venta ventaBuscada = s.GetVentaPorId(id);
		
			int? idLogueado = HttpContext.Session.GetInt32("idLogueado");
			
			Cliente clienteLogueado = s.GetClientePorId(idLogueado.Value);
			

			ViewBag.SaldoDisponible = clienteLogueado.SaldoDisponible;

            return View(ventaBuscada);

        }



        [HttpPost]
        public IActionResult FinalizarCompra(int id, double monto)
        {
            try
            {
              
                int? idLogueado = HttpContext.Session.GetInt32("idLogueado");
                
                Cliente clienteLogueado = s.GetClientePorId(idLogueado.Value);
            
                Venta ventaBuscada = s.GetVentaPorId(id);

				ventaBuscada.PrecioFinal = ventaBuscada.CalcularPrecioFinal();
				
                double precioFinal = ventaBuscada.CalcularPrecioFinal();

				double saldoDisponible = s.GetSaldo(clienteLogueado);
                if (saldoDisponible < precioFinal)
                {
                    ViewBag.MsgError = "Saldo insuficiente.";
                    return RedirectToAction("Create", new { id }); // REDIRECCIONAR A RECARGAR BILLETERA
                }
				

				s.FinalizarCompra(ventaBuscada);

				clienteLogueado.SaldoDisponible -= precioFinal;

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