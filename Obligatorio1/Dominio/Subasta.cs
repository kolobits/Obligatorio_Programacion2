using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class Subasta : Publicacion
	{
		public List<Oferta> _ofertas { get; set; }
		public Usuario UsuarioGanador { get; set; }
		public Usuario AdministradorQueCierra { get; set; }


		public Subasta()
		{
			_ofertas = new List<Oferta>();
		}

		public Subasta(string nombre, DateTime fechaPublicacion, double montoBase)
		  : base(nombre, fechaPublicacion)
		{
			_ofertas = new List<Oferta>();
		}



		// ALTA OFERTA
		public void AgregarOferta(Oferta oferta)
		{
			if (oferta == null)
			{
				throw new Exception("La oferta no puede ser nula.");
			}
			if (oferta.Cliente.SaldoDisponible < oferta.Monto)
			{
				throw new Exception("No tiene saldo suficiente para realizar la oferta.");
			}
			_ofertas.Add(oferta);
		}


		// OFERTA MAS ALTA
		public Oferta ofertaMasAlta()
		{
			if (_ofertas == null && _ofertas.Count == 0)
			{
				return null;
			}

			Oferta mejorOferta = _ofertas[0];

			foreach (Oferta o in _ofertas)
			{
				if (o.Monto > mejorOferta.Monto)
				{
					mejorOferta = o;
				}
			}

			return mejorOferta;
		}


		// CALCULAR PRECIO FINAL
		public override double CalcularPrecioFinal()
		{
			Oferta mejorOferta = ofertaMasAlta();
			if (mejorOferta != null)
			{
				return mejorOferta.Monto;
			}
			else
			{
				return 0;
			}

		}


		public override void CerrarPublicacion(Usuario usuario)
		{
			if (usuario is Administrador admin)
			{
				if (_ofertas == null && _ofertas.Count == 0)
				{
					throw new Exception("No hay ofertas para esta subasta.");
				}

				Oferta mejorOferta = ofertaMasAlta();
				if (mejorOferta != null)
				{
					ClienteFinal = mejorOferta.Cliente;

					if (ClienteFinal.SaldoDisponible < mejorOferta.Monto)
					{
						throw new Exception($"El cliente {ClienteFinal.Nombre} no tiene saldo suficiente para pagar la subasta.");
					}

					ClienteFinal.SaldoDisponible -= mejorOferta.Monto;
					Estado = Estado.CERRADA;
					FechaFin = DateTime.Now;
					UsuarioFinalizador = admin;
				}
				else
				{
					throw new Exception("No se pudo determinar la oferta más alta.");
				}
			}

		}
	}
}

