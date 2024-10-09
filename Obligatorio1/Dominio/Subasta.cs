using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion
    {
        public List<Oferta> Ofertas { get; private set; }

        public Subasta()
        {

        }

        public Subasta(string nombre, DateTime fechaPublicacion, double montoBase)
          : base(nombre, fechaPublicacion)
        {
            Ofertas = new List<Oferta>();
        }


        public void AgregarOferta(Oferta oferta)
        {
            if (oferta == null)
            {
                throw new Exception("La oferta no puede ser nula.");
            }
            Ofertas.Add(oferta);
        }


        public override double CalcularPrecioFinal()
        {
         
            double montoMaximo = 0;

            
            if (Ofertas.Count > 0)
            {
                
                foreach (Oferta o in Ofertas)
                {
                    if (o.Monto > montoMaximo)
                    {
                        montoMaximo = o.Monto;
                    }
                }
            }
            return montoMaximo; 
        }


    }


}
