using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta : Publicacion
    {
        
        public bool EsOfertaRelampago { get; set; }
        public double PrecioFinal { get; set; }


        public Venta(string nombre, DateTime fechaPublicacion, bool esOfertaRelampago) : base(nombre, fechaPublicacion)
        {
            EsOfertaRelampago = esOfertaRelampago;
           
        }

        // CALCULAR PRECIO FINAL
        public override double CalcularPrecioFinal()
        {
            double total = 0;
            foreach (Articulo articulo in GetArticulos())
            {
                total += articulo.Precio;
            }
            if (EsOfertaRelampago)
            {
                total *= 0.80;
            }

            return total;
        }

        // CERRAR VENTA
		public override void CerrarPublicacion(Usuario usuario)
		{
			if (usuario is Cliente cliente)
			{
				double precioFinal = CalcularPrecioFinal();

				if (cliente.SaldoDisponible < precioFinal)
				{
					throw new Exception("Saldo insuficiente para completar la compra.");
				}

				cliente.SaldoDisponible -= precioFinal;
				PrecioFinal = precioFinal;
				Estado = Estado.CERRADA;
				FechaFin = DateTime.Now;
				UsuarioFinalizador = cliente;
                ClienteFinal = cliente;
			}
			else
			{
				throw new Exception("Solo un cliente puede finalizar una venta.");
			}
		}

	}
}
