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

        // CALCULAR PRECIO FINAL (CONTEMPLA OFERTA RELAMPAGO)
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


    }
}
