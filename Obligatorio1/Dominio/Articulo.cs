using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }

        public Articulo()
        {
            Id = UltimoId++;
        }

        public Articulo(string nombre, string categoria, double precio)
        {
            Id = UltimoId++;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
        }

        //public void ValidarNombreArticulo()
        //{
        //    if (String.IsNullOrEmpty(nombre){

        //        throw new Exeption("El nombre no puede ser vacio");

        //    }
        //}



    }
}
