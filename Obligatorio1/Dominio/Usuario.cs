using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario
    {
        public int Id { get; private set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }

        public Usuario()
        {
            Id = UltimoId++;
        }

        public Usuario(string nombre, string apellido, string email, string contrasena)
        {
            Id = UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasena = contrasena;
        }

        public virtual void MostrarDatos()
        {
            Console.WriteLine($"ID: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}");

        }





        public void Validar()
        {
            throw new NotImplementedException();
        }
    }

}
