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
            if (oferta.Cliente == null)
            {
                throw new Exception("La oferta debe estar asociada a un cliente.");
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

        // CERRAR PUBLICACION
        //public override void CerrarPublicacion(Usuario usuario)
        //{
        //	if (usuario is Administrador admin)
        //	{
        //		if (_ofertas == null && _ofertas.Count == 0)
        //		{
        //			throw new Exception("No hay ofertas para esta subasta.");
        //		}

        //		Oferta mejorOferta = ofertaMasAlta();
        //		if (mejorOferta != null)
        //		{
        //			ClienteFinal = mejorOferta.Cliente;

        //			if (ClienteFinal.SaldoDisponible < mejorOferta.Monto)
        //			{
        //				throw new Exception($"El cliente {ClienteFinal.Nombre} no tiene saldo suficiente para pagar la subasta.");
        //			}

        //			ClienteFinal.SaldoDisponible -= mejorOferta.Monto;
        //			Estado = Estado.CERRADA;
        //			FechaFin = DateTime.Now;
        //			UsuarioFinalizador = admin;
        //		}
        //		else
        //		{
        //			throw new Exception("No se pudo determinar la oferta más alta.");
        //		}
        //	}

        //}

        //public override void CerrarPublicacion(Usuario admin)
        //{
        //    if (admin == null)
        //    {
        //        throw new Exception("No se ha proporcionado un administrador válido para cerrar la subasta.");
        //    }

        //    if (_ofertas == null || _ofertas.Count == 0)
        //    {
        //        throw new Exception("No hay ofertas para esta subasta.");
        //    }

        //    if (Estado != Estado.ABIERTA)
        //    {
        //        throw new Exception("La subasta no está en un estado válido para cerrarse.");
        //    }

        //    // Ordenar las ofertas por monto descendente
        //    _ofertas.Sort((o1, o2) => o2.Monto.CompareTo(o1.Monto));

        //    foreach (Oferta oferta in _ofertas)
        //    {
        //        if (oferta.Cliente.SaldoDisponible > oferta.Monto)
        //        {
        //            // Actualiza los datos del ganador
        //            ClienteFinal = oferta.Cliente;
        //            ClienteFinal.SaldoDisponible -= oferta.Monto;

        //            UsuarioFinalizador = admin;

        //            // Cambiar el estado de la subasta
        //            Estado = Estado.CERRADA;
        //            FechaFin = DateTime.Now;
        //            return; // Finaliza el método una vez que se encuentra un ganador válido
        //        }
        //    }

        //    // Si ninguna oferta es válida, cancela la subasta
        //    Estado = Estado.CANCELADA;
        //    UsuarioFinalizador = admin;
        //    FechaFin = DateTime.Now;
        //}


        public override void CerrarPublicacion(Usuario admin)
        {
            if (_ofertas == null && _ofertas.Count == 0)
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



        // GET ULTIMO OFERTANTE
        public Cliente GetUltimoOfertante()
		{
			if (_ofertas == null && _ofertas.Count == 0)
			{
				return null;
			}

			return _ofertas[_ofertas.Count - 1].Cliente;
		}
	}
}
