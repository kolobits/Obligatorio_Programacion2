using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion
    {
        //private List<Oferta> _ofertas = new List<Oferta>(); 

        public double MontoBase { get; set; } = 0;

        private List<Subasta> _subastas = new List<Subasta>();

        private List<Oferta> _ofertas = new List<Oferta>();

        public Subasta()
        {

        }

        public Subasta(List<Oferta> ofertas, Estado estado, DateTime fechaPublicacion, Cliente cliente, DateTime fechaFin) : base(estado, fechaPublicacion, cliente, null, fechaFin)
        {
            _ofertas = ofertas;
        }


        public void AgregarOferta(Oferta oferta)
        {
            if (oferta == null)
            {
                throw new Exception("La oferta no puede ser nula.");
            }
            _ofertas.Add(oferta);
        }

        // Método para obtener las ofertas
        public List<Oferta> ObtenerOfertas()
        {
            return _ofertas; 
        }




        //public Subasta(List<Oferta> ofertas, Estado estado, DateTime fechaPublicacion, List<Articulo> articulos, Cliente cliente, DateTime fechaFin) : base(estado, fechaPublicacion, articulos, cliente, null, fechaFin)
        //{
        //    _ofertas = ofertas;
        //}
    }


}
