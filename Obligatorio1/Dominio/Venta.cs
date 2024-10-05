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

    
        public Venta(bool esOfertaRelampago, Estado estado, DateTime fechaPublicacion, Cliente cliente,Usuario usuario, DateTime fechaFin) : base(estado, fechaPublicacion, cliente, usuario, fechaFin)
        {
            EsOfertaRelampago = esOfertaRelampago;
            PrecioFinal = CalcularPrecio();

        }

       // Método para calcular precio con descuento si es relampago
        public double CalcularPrecio()
        {
            double precioBase = CalcularPrecioTotal();  // Precio total de los artículos de la publicación

            if (EsOfertaRelampago)
            {
                return precioBase * 0.80;  // Aplica el 20% si es oferta relámpago
            }
            return precioBase;
        }

    }
}
