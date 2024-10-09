using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Publicacion
    {
        public int id { get; set; }
        public static int UltimoId { get; set; } = 1;

        public string Nombre { get; set; }
        public Estado Estado { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public Cliente ClienteFinal { get; set; }

        public Usuario UsuarioFinalizador { get; set; }

        public DateTime FechaFin { get; set; }

        private List<Articulo> _articulos = new List<Articulo>();




        public Publicacion()
        {
            id = UltimoId++;
        }


        public Publicacion(Estado estado, DateTime fechaPublicacion, Cliente cliente, Usuario usuario, DateTime fechaFin)
        {
            id = UltimoId++;
            Estado = estado;
            FechaPublicacion = fechaPublicacion;
            ClienteFinal = cliente;
            UsuarioFinalizador = usuario;
            FechaFin = fechaFin;
        }

        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"ID: {id}, Nombre: {Nombre}, Estado: {Estado}, Fecha: {FechaPublicacion}");
        }


        public void AgregarArticulo(Articulo articulo)
        {

            if (articulo == null)
            {
                throw new Exception("El artículo no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(articulo.Nombre))
            {
                throw new Exception("El nombre del artículo no puede estar vacío.");
            }

            if (string.IsNullOrEmpty(articulo.Categoria))
            {
                throw new Exception("La categoría del artículo no puede estar vacía.");
            }

            if (articulo.Precio <= 0)
            {
                throw new Exception("El precio del artículo debe ser mayor a cero.");
            }

            _articulos.Add(articulo);
        }


        // METODO PARA OBTENER LISTA DE ARTICULOS
        public List<Articulo> GetArticulos()
        {
            return _articulos;
        }


        // METODO PARA CALCULAR EL PRECIO TOTAL DE LOS PRODUCTOS
        public abstract double CalcularPrecioFinal();




        



    }

}

