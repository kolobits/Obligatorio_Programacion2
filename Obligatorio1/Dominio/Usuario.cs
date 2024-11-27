using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario : IValidable
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
            Validar();
        }

        // VALIDACIONES
        #region
        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarEmail();
            ValidarContrasena();
        }
        
        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacío.");
            }

            if (Nombre.Length < 2)
            {
                throw new Exception("El nombre debe tener al menos 2 caracteres.");
            }
        }

        public void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("El apellido no puede estar vacío.");
            }

            if (Apellido.Length < 2)
            {
                throw new Exception("El apellido debe tener al menos 2 caracteres.");
            }
        }

        public void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("El correo electrónico no puede estar vacío.");
            }
        }

        public void ValidarContrasena()
        {
            if (string.IsNullOrEmpty(Contrasena))
            {
                throw new Exception("La contraseña no puede estar vacía.");
            }

            if (Contrasena.Length < 8)
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            }
            if (!EsAlfanumerico())
            {
                throw new Exception("La contraseña debe tener al menos una letra y un número.");
            }
        }
        #endregion

        public string MostrarDatos()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}";
        }
        public bool EsAlfanumerico()
        {
            bool tieneLetra = Contrasena.Any(char.IsLetter);
            bool tieneNumero = Contrasena.Any(char.IsDigit);
            return tieneLetra && tieneNumero;
        }

        public abstract string GetRol();

    }
}
