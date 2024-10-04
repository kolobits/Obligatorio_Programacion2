using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _ofertas = new List<Oferta>(); // agregar metodos get set

        public double MontoBase { get; set; } = 0; // consultar profe

        public Subasta()
        {

        }

        public Subasta(List<Oferta> ofertas, Estado estado, DateTime fechaPublicacion, List<Articulo> articulos, Cliente cliente, DateTime fechaFin) : base(estado, fechaPublicacion, articulos, cliente,null, fechaFin)
        {
            _ofertas = ofertas;
        }


    }


}
