using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Oferta
    {

        public int Id { get; set; }

        public static int UltimoId { get; set; } = 1;

        public Cliente Cliente { get; set; }

        public double Monto { get; set; }

        public DateTime Fecha { get; set; }

        public Oferta()
        {
            Id = UltimoId++;
        }

        public Oferta(Cliente cliente, double monto, DateTime fecha)
        {
            Id = UltimoId++;
            Cliente = cliente;
            Monto = monto;
            Fecha = fecha;
        }

      


    }
}
