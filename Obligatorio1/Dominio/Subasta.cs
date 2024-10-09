using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion
    {
        public List<Oferta> _ofertas { get; set; }
        public Usuario UsuarioGanador { get; set; }
        public Usuario AdministradorQueCierra { get; set; }

        public Subasta()
        {
            _ofertas = new List<Oferta>();
        }

        public Subasta(string nombre, DateTime fechaPublicacion, double montoBase)
          : base(nombre, fechaPublicacion)
        {
            _ofertas = new List<Oferta>();
        }



        // ALTA OFERTA
        public void AgregarOferta(Oferta oferta)
        {
            if (oferta == null)
            {
                throw new Exception("La oferta no puede ser nula.");
            }
            _ofertas.Add(oferta);
        }


        // CALCULAR PRECIO FINAL PARA LA SUBASTA (OFERTA MAYOR)
        public override double CalcularPrecioFinal()
        {
            if (_ofertas == null || _ofertas.Count == 0)
            {
                return 0; 
            }

            Oferta mejorOferta = _ofertas[0]; 

            foreach (Oferta o in _ofertas)
            {
                if (o.Monto > mejorOferta.Monto)
                {
                    mejorOferta = o;
                }
            }

            return mejorOferta.Monto; 
        }


        // METODO PARA CERRAR SUBASTA
        public void CerrarSubasta(Administrador admin)
        {
            if (_ofertas == null && _ofertas.Count == 0)
            {
                throw new Exception("No hay ofertas para cerrar esta subasta.");
            }

            Oferta mejorOferta = _ofertas[0]; 

            foreach (Oferta o in _ofertas)
            {
                if (o.Monto > mejorOferta.Monto)
                {
                    mejorOferta = o;  
                }
            }
         
            ClienteFinal = mejorOferta.Cliente;
            UsuarioFinalizador = admin;

            Estado = Estado.CERRADA;
            FechaFin = DateTime.Now;
        }






    }
}
