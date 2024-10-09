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
            Validar();
        }



        // VALIDACIONES
        public void Validar()
        {
            ValidarNombre();
            ValidarCategoria();
            ValidarPrecio();
        }


        private void ValidarNombre()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");

            }
        }

        private void ValidarCategoria()
        {
            if (String.IsNullOrEmpty(Categoria))
            {
                throw new Exception("La categoría no puede estar vacia");
            }
        }


        private void ValidarPrecio()
        {
            if (Precio <= 0)
            {
                throw new Exception("El precio no puede ser 0");
            }
        }


    }
}
