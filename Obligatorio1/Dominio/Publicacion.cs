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
            Validar();
        }

        public void Validar()
        {
 
        }

        public void AgregarArticulo(Articulo articulo)
        {
            if (articulo == null)
            {
                throw new Exception("El artículo no puede ser nulo.");
            }
            _articulos.Add(articulo);
        }

        public List<Articulo> ObtenerArticulos()
        {
            return _articulos;
        }

        public void ValidarArticulo()
        {
             if (_articulos == null || _articulos.Count == 0)
            {
                throw new Exception("Se deben incluir artículos en la publicación.");
            }
        }

        // Método para calcular el precio total de los articulos
        public double CalcularPrecioTotal()
        {
            double total = 0;
            foreach (Articulo articulo in _articulos)
            {
                total += articulo.Precio;
            }
            return total;
        }
    }

}

