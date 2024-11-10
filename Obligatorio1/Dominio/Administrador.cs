using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        public Administrador()
        {
            
        }

        public Administrador(string nombre, string apellido, string email, string contrasena) : base(nombre, apellido, email, contrasena)
        {

        }

        public override string GetRol()
        {
            return "ADM";
        }

	
	}
}
