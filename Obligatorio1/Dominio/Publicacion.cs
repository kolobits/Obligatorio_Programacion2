using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Publicacion : IValidable
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
            Estado = Estado.ABIERTA;
        }


        public Publicacion(string nombre, DateTime fechaPublicacion)
        {
            id = UltimoId++;
            Nombre = nombre;
            FechaPublicacion = fechaPublicacion;
            Estado = Estado.ABIERTA;
            Validar();
        }



        // VALIDACIONES
        public void Validar()
        {
            ValidarNombre();
        }


        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre de la publicación no puede estar vacío.");
            }

            if (Nombre.Length < 3)
            {
                throw new Exception("El nombre de la publicación debe tener al menos 3 caracteres.");
            }
        }

        public void AltaArticulo(Articulo articulo)
        {
            if (articulo == null)
            {
                throw new Exception("El artículo no puede ser nulo.");
            }
            _articulos.Add(articulo);
        }

        public List<Articulo> GetArticulos()
        {
            return _articulos;
        }

        // METODO PARA CALCULAR EL PRECIO TOTAL DE LOS PRODUCTOS
        public abstract double CalcularPrecioFinal();


        public abstract void CerrarPublicacion(Usuario usuario);

	}

}

