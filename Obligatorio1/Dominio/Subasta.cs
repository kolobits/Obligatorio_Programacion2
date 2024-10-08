using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion
    {
        public double MontoBase { get; set; } = 0;

        private List<Oferta> _ofertas = new List<Oferta>();

        public Subasta()
        {

        }

        public Subasta(double montoBase, Estado estado, DateTime fechaPublicacion, Cliente cliente, DateTime fechaFin) : base(estado, fechaPublicacion, cliente, null, fechaFin)
        {
            MontoBase = montoBase;
        }



        public void AgregarOferta(Oferta oferta)
        {
            if (oferta == null)
            {
                throw new Exception("La oferta no puede ser nula.");
            }
            _ofertas.Add(oferta);
        }


        // METODO PARA OBTENER LAS OFERTAS
        public List<Oferta> ObtenerOfertas()
        {
            return _ofertas;
        }

        public override double CalcularPrecioFinal()
        {
            throw new NotImplementedException();
        }   



    }


}
