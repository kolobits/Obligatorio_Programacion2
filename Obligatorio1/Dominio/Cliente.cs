﻿using System;
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

		public override string GetRol()
		{
			return "CLI";
		}

      
	}

}
