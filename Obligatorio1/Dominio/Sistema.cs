using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Oferta> _ofertas = new List<Oferta>();
        //private List<Venta> _ventas = new List<Venta>();

        private static Sistema _instancia;


        private Sistema()
        {
            PrecargarDatos();
        }

        // Singleton
        public static Sistema Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }



        private void PrecargarDatos()
        {
            PrecargarClientes();
            PrecargarAdministradores();
            PrecargarArticulos();
            PrecargarVentas();
        }


        private void PrecargarClientes()
        {
            Cliente c1 = new Cliente(2000.00, "Juan", "Rodriguez", "juanrodriguez@gmail.com", "contrasenia1");
            Cliente c2 = new Cliente(1500.00, "Ana", "Gomez", "anagomez@gmail.com", "contrasenia2");
            Cliente c3 = new Cliente(3000.00, "Carlos", "Lopez", "carloslopez@gmail.com", "contrasenia3");
            Cliente c4 = new Cliente(2500.00, "Maria", "Fernandez", "mariafernandez@gmail.com", "contrasenia4");
            Cliente c5 = new Cliente(1800.00, "Luis", "Martinez", "luismartinez@gmail.com", "contrasenia5");
            Cliente c6 = new Cliente(2200.00, "Sofia", "Hernandez", "sofiahernandez@gmail.com", "contrasenia6");
            Cliente c7 = new Cliente(2800.00, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "contrasenia7");
            Cliente c8 = new Cliente(3200.00, "Laura", "Morales", "lauramorales@gmail.com", "contrasenia8");
            Cliente c9 = new Cliente(2700.00, "Javier", "Castillo", "javiercastillo@gmail.com", "contrasenia9");
            Cliente c10 = new Cliente(2400.00, "Isabel", "Torres", "isabeltorres@gmail.com", "contrasenia10");

            _usuarios.Add(c1);
            _usuarios.Add(c2);
            _usuarios.Add(c3);
            _usuarios.Add(c4);
            _usuarios.Add(c5);
            _usuarios.Add(c6);
            _usuarios.Add(c7);
            _usuarios.Add(c8);
            _usuarios.Add(c9);
            _usuarios.Add(c10);
        }

        private void PrecargarAdministradores()
        {
            Administrador a1 = new Administrador("Pedro", "Perez", "pedroperez@gmail.com", "Admin123");
            Administrador a2 = new Administrador("Andrés", "López", "andreslopez@gmail.com", "Admin456");

            _usuarios.Add(a1);
            _usuarios.Add(a2);
        }

        // Region Precarga de Artículos
        #region
        private void PrecargarArticulos()
        {
            Articulo a1 = new Articulo("Balde", "Playa", 15.99);
            Articulo a2 = new Articulo("Sombrilla", "Playa", 25.50);
            Articulo a3 = new Articulo("Toalla", "Playa", 10.99);
            Articulo a4 = new Articulo("Silla", "Playa", 45.00);
            Articulo a5 = new Articulo("Heladera", "Playa", 60.00);
            Articulo a6 = new Articulo("Bañador", "Ropa", 30.50);
            Articulo a7 = new Articulo("Gafas de Sol", "Accesorios", 20.00);
            Articulo a8 = new Articulo("Crema Solar", "Cuidado Personal", 12.99);
            Articulo a9 = new Articulo("Flotador", "Playa", 35.75);
            Articulo a10 = new Articulo("Chancletas", "Calzado", 18.50);
            Articulo a11 = new Articulo("Kayak", "Aventura", 300.00);
            Articulo a12 = new Articulo("Botiquín", "Aventura", 40.00);
            Articulo a13 = new Articulo("Linterna", "Camping", 25.00);
            Articulo a14 = new Articulo("Mapa", "Aventura", 9.99);
            Articulo a15 = new Articulo("Carpa", "Camping", 120.00);
            Articulo a16 = new Articulo("Saco de Dormir", "Camping", 70.00);
            Articulo a17 = new Articulo("Mochila", "Aventura", 55.00);
            Articulo a18 = new Articulo("Cámara", "Fotografía", 400.00);
            Articulo a19 = new Articulo("Trípode", "Fotografía", 75.00);
            Articulo a20 = new Articulo("Lente", "Fotografía", 200.00);
            Articulo a21 = new Articulo("Funda", "Fotografía", 30.00);
            Articulo a22 = new Articulo("Tarjeta de Memoria", "Fotografía", 15.00);
            Articulo a23 = new Articulo("Estuche", "Electrónica", 40.00);
            Articulo a24 = new Articulo("Cargador", "Electrónica", 20.00);
            Articulo a25 = new Articulo("Altavoz Bluetooth", "Electrónica", 100.00);
            Articulo a26 = new Articulo("Bicicleta", "Deporte", 350.00);
            Articulo a27 = new Articulo("Casco", "Deporte", 60.00);
            Articulo a28 = new Articulo("Guantes", "Deporte", 20.00);
            Articulo a29 = new Articulo("Zapatillas", "Calzado", 80.00);
            Articulo a30 = new Articulo("Pelota", "Deporte", 25.00);
            Articulo a31 = new Articulo("Kit de Pesca", "Aventura", 150.00);
            Articulo a32 = new Articulo("Patines", "Deporte", 90.00);
            Articulo a33 = new Articulo("Raqueta de Tenis", "Deporte", 100.00);
            Articulo a34 = new Articulo("Coche Teledirigido", "Juguetes", 75.00);
            Articulo a35 = new Articulo("Juego de Mesa", "Juegos", 30.00);
            Articulo a36 = new Articulo("Libro", "Literatura", 20.00);
            Articulo a37 = new Articulo("Reloj", "Accesorios", 150.00);
            Articulo a38 = new Articulo("Perfume", "Cuidado Personal", 50.00);
            Articulo a39 = new Articulo("Sombrero", "Accesorios", 15.00);
            Articulo a40 = new Articulo("Cuchillo de Cocina", "Hogar", 25.00);
            Articulo a41 = new Articulo("Sartén", "Hogar", 30.00);
            Articulo a42 = new Articulo("Tenedor", "Hogar", 5.00);
            Articulo a43 = new Articulo("Plato", "Hogar", 8.00);
            Articulo a44 = new Articulo("Taza", "Hogar", 6.00);
            Articulo a45 = new Articulo("Aguja de Tejer", "Manualidades", 3.50);
            Articulo a46 = new Articulo("Hilo", "Manualidades", 2.00);
            Articulo a47 = new Articulo("Pinturas", "Arte", 15.00);
            Articulo a48 = new Articulo("Caballetes", "Arte", 40.00);
            Articulo a49 = new Articulo("Cuaderno", "Papelería", 5.00);
            Articulo a50 = new Articulo("Lápiz", "Papelería", 1.00);

            _articulos.Add(a1);
            _articulos.Add(a2);
            _articulos.Add(a3);
            _articulos.Add(a4);
            _articulos.Add(a5);
            _articulos.Add(a6);
            _articulos.Add(a7);
            _articulos.Add(a8);
            _articulos.Add(a9);
            _articulos.Add(a10);
            _articulos.Add(a11);
            _articulos.Add(a12);
            _articulos.Add(a13);
            _articulos.Add(a14);
            _articulos.Add(a15);
            _articulos.Add(a16);
            _articulos.Add(a17);
            _articulos.Add(a18);
            _articulos.Add(a19);
            _articulos.Add(a20);
            _articulos.Add(a21);
            _articulos.Add(a22);
            _articulos.Add(a23);
            _articulos.Add(a24);
            _articulos.Add(a25);
            _articulos.Add(a26);
            _articulos.Add(a27);
            _articulos.Add(a28);
            _articulos.Add(a29);
            _articulos.Add(a30);
            _articulos.Add(a31);
            _articulos.Add(a32);
            _articulos.Add(a33);
            _articulos.Add(a34);
            _articulos.Add(a35);
            _articulos.Add(a36);
            _articulos.Add(a37);
            _articulos.Add(a38);
            _articulos.Add(a39);
            _articulos.Add(a40);
            _articulos.Add(a41);
            _articulos.Add(a42);
            _articulos.Add(a43);
            _articulos.Add(a44);
            _articulos.Add(a45);
            _articulos.Add(a46);
            _articulos.Add(a47);
            _articulos.Add(a48);
            _articulos.Add(a49);
            _articulos.Add(a50);

        }
        #endregion

        private void PrecargarVentas()
        {
            Articulo articulo1 = GetArticuloPorNombre("Laptop");
            Articulo articulo2 = GetArticuloPorNombre("Smartphone");

            if (articulo1 != null && articulo2 != null)
            {
                List<Articulo> listaArticulos = new List<Articulo> { articulo1, articulo2 };

                Cliente cliente = new Cliente(2000.00, "Juan", "Rodriguez", "juanrodriguez@gmail.com", "contrasenia1");
                Usuario usuario = new Administrador("Pedro", "Pérez", "pedroperez@gmail.com", "Admin123");

                Venta v1 = new Venta(
                    esOfertaRelampago: true,
                    estado: Estado.ABIERTA,
                    fechaPublicacion: new DateTime(2024, 06, 29),
                    articulos: listaArticulos,
                    cliente: cliente,
                    usuario: usuario,
                    fechaFin: DateTime.Now.AddDays(7) 
                );

                _publicaciones.Add(v1);
            }
        }



        //public void ListarVentas()
        //{
        //    foreach (Venta v in _publicaciones)
        //    {
        //        if (v is Venta)
        //        {
        //            Console.WriteLine($"{v.PrecioFinal}");
        //        }
        //    }
                       
        //}

    
        public Articulo GetArticuloPorNombre(string nombreArticulo)
        {
            foreach (Articulo a in _articulos)
            {
                if (a.Nombre == nombreArticulo)
                {
                    return a;
                }
            }
            return null; // Si no encuentra el artículo, retorna null
        }


        public void ListarClientes()
        {
            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente cliente)
                {
                    u.MostrarDatos();
                }
            }
        }

        public void ListarArticulosPorCategoria()
        {

            Console.WriteLine("Elige una categoría:");
            Console.WriteLine("1. Playa");
            Console.WriteLine("2. Aventura");
            Console.WriteLine("3. Ropa");
            Console.WriteLine("4. Accesorios");
            Console.WriteLine("5. Cuidado Personal");
            Console.WriteLine("6. Camping");
            Console.WriteLine("7. Fotografía");
            Console.WriteLine("8. Electrónica");
            Console.WriteLine("9. Deporte");
            Console.WriteLine("10. Juguetes");
            Console.WriteLine("11. Juegos");
            Console.WriteLine("12. Literatura");
            Console.WriteLine("13. Hogar");
            Console.WriteLine("14. Manualidades");
            Console.WriteLine("15. Arte");
            Console.WriteLine("16. Papelería");

            string opcion = Console.ReadLine();
            string categoria = "";

            switch (opcion)
            {
                case "1":
                    categoria = "Playa";
                    break;
                case "2":
                    categoria = "Aventura";
                    break;
                case "3":
                    categoria = "Ropa";
                    break;
                case "4":
                    categoria = "Accesorios";
                    break;
                case "5":
                    categoria = "Cuidado Personal";
                    break;
                case "6":
                    categoria = "Camping";
                    break;
                case "7":
                    categoria = "Fotografía";
                    break;
                case "8":
                    categoria = "Electrónica";
                    break;
                case "9":
                    categoria = "Deporte";
                    break;
                case "10":
                    categoria = "Juguetes";
                    break;
                case "11":
                    categoria = "Juegos";
                    break;
                case "12":
                    categoria = "Literatura";
                    break;
                case "13":
                    categoria = "Hogar";
                    break;
                case "14":
                    categoria = "Manualidades";
                    break;
                case "15":
                    categoria = "Arte";
                    break;
                case "16":
                    categoria = "Papelería";
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    return;
            }

            Console.WriteLine($"Artículos en la categoría '{categoria}':");

            bool existeArticulo = false;
            foreach (Articulo a in _articulos)
            {
                {
                    if (a.Categoria == categoria)
                    {
                        Console.WriteLine($"Nombre: {a.Nombre}, Precio: ${a.Precio}");
                        existeArticulo = true;
                    }
                }

            }
            if (!existeArticulo)
            {
                Console.WriteLine("No hay artículos disponibles en esta categoría.");
            }


        }

        public void AltaArticulo()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }





        //public Articulo(string nombre, string categoria, double precio)
        //{
        //    Id = UltimoId++;
        //    Nombre = nombre;
        //    Categoria = categoria;
        //    Precio = precio;
        //}
    }




}
