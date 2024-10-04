using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario
    {

        public double SaldoDisponible { get; set; }


        public Cliente()
        {

        }

        public Cliente(double saldoDisponible, string nombre, string apellido, string email, string contrasena) : base(nombre, apellido, email, contrasena)
        {
            SaldoDisponible = saldoDisponible;
        }
    }

   

    /*
    public void ValidarSaldo()
    {
        if (SaldoDisponible <= 0)
        {
            throw new Exception("El cliente no tiene saldo disponible.");
        }
    }

    public void ValidarNombreCliente()
    {
        if (String.IsNullOrEmpty(nombre){

            throw new Exeption("El nombre no puede ser vacio");

        }
    }

    public void ValidarApellidoCliente()
    {
        if (String.IsNullOrEmpty(apellido){

            throw new Exeption("El apellido no puede ser vacio");

        }
    }
    */

}
