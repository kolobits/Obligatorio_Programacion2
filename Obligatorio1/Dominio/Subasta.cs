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
		//public Usuario UsuarioGanador { get; set; }
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

        // AGREGAR OFERTA
        public void AgregarOferta(Oferta oferta)
        {
            if (oferta == null)
            {
                throw new Exception("La oferta no puede ser nula.");
            }

            Oferta ofertaActual = ofertaMasAlta();
            if (ofertaActual != null && oferta.Monto <= ofertaActual.Monto)
            {
                throw new Exception("La oferta debe ser mayor a la oferta más alta actual.");
            }

            if (oferta.Monto <= 0)
            {
                throw new Exception("El monto de la oferta debe ser mayor a 0.");
            }
            _ofertas.Add(oferta);
        }


        // OFERTA MAS ALTA
        public Oferta ofertaMasAlta()
		{
			if (_ofertas == null || _ofertas.Count == 0)
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

        // CERRAR SUBASTA
        public override void CerrarPublicacion(Usuario admin)
        {
            if (_ofertas == null || _ofertas.Count == 0)
            {
                throw new Exception("No hay ofertas para esta subasta.");
            }

            _ofertas.Sort((o1, o2) => o2.Monto.CompareTo(o1.Monto));

            foreach (Oferta oferta in _ofertas)
            {
                if (oferta.Cliente.SaldoDisponible >= oferta.Monto)
                {
                    ClienteFinal = oferta.Cliente;
                    ClienteFinal.SaldoDisponible -= oferta.Monto;
                    UsuarioFinalizador = admin;
                    Estado = Estado.CERRADA;
                    FechaFin = DateTime.Now;
                    return;
                }
            }
            Estado = Estado.CANCELADA;
            UsuarioFinalizador = admin;
            FechaFin = DateTime.Now;
        }
    }
}
