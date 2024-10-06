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

        public Venta()
        {

        }


        public Venta(bool esOfertaRelampago, Estado estado, DateTime fechaPublicacion, Cliente cliente, Usuario usuario, DateTime fechaFin) : base(estado, fechaPublicacion, cliente, usuario, fechaFin)
        {
            EsOfertaRelampago = esOfertaRelampago;
            PrecioFinal = CalcularPrecio();

        }


        public override double CalcularPrecioFinal()
        {
            List<Articulo> listAux = GetArticulos();
            double total = 0;
            foreach (Articulo articulo in listAux)
            {
                total += articulo.Precio;
            }
            return total;

        }


        // METODO PARA CALCULAR PRECIO CON DESCUENTO
        public double CalcularPrecio()
        {
            double precioBase = CalcularPrecioFinal();
            if (EsOfertaRelampago)
            {
                return precioBase * 0.80;  // APLICA EL 20% SI ES RELAMPAGO
            }
            return precioBase;
        }

    }
}
