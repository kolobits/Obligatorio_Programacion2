using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public override void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Saldo Disponible: ${SaldoDisponible}");
        }











    }







   
}
