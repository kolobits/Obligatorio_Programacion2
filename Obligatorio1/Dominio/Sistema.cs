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


        private static Sistema _instancia;


        private Sistema()
        {
            PrecargarDatos();

        }

        // SINGLETON
        public static Sistema Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }


        private void PrecargarDatos()
        {
            PrecargarClientes();
            PrecargarAdministradores();
            PrecargarArticulos();
            PrecargarVentas();
            PrecargarSubastas();
        }

        // PRECARGA USUARIOS
        #region
        // CLIENTES
        public void PrecargarClientes()
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

            AltaUsuario(c1);
            AltaUsuario(c2);
            AltaUsuario(c3);
            AltaUsuario(c4);
            AltaUsuario(c5);
            AltaUsuario(c6);
            AltaUsuario(c7);
            AltaUsuario(c8);
            AltaUsuario(c9);
            AltaUsuario(c10);

        }

        // ADMINISTRADORES
        public void PrecargarAdministradores()
        {
            Administrador a1 = new Administrador("Pedro", "Perez", "pedroperez@gmail.com", "Admin123");
            Administrador a2 = new Administrador("Andrés", "López", "andreslopez@gmail.com", "Admin456");

            AltaUsuario(a1);
            AltaUsuario(a2);
        }
        #endregion


        // ALTA USUARIOS
        #region
        public List<Usuario> GetUsuarios()
        {
            return _usuarios;
        }

        public void AltaUsuario(Usuario usuario)
        {
            try
            {
                if (!_usuarios.Contains(usuario))
                {
                    usuario.Validar();
                    _usuarios.Add(usuario);
                }
                else
                {
                    throw new Exception("El socio ya existe en el sistema");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        // PRECARGA ARTICULOS
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

            AltaArticulo(a1);
            AltaArticulo(a2);
            AltaArticulo(a3);
            AltaArticulo(a4);
            AltaArticulo(a5);
            AltaArticulo(a6);
            AltaArticulo(a7);
            AltaArticulo(a8);
            AltaArticulo(a9);
            AltaArticulo(a10);
            AltaArticulo(a11);
            AltaArticulo(a12);
            AltaArticulo(a13);
            AltaArticulo(a14);
            AltaArticulo(a15);
            AltaArticulo(a16);
            AltaArticulo(a17);
            AltaArticulo(a18);
            AltaArticulo(a19);
            AltaArticulo(a20);
            AltaArticulo(a21);
            AltaArticulo(a22);
            AltaArticulo(a23);
            AltaArticulo(a24);
            AltaArticulo(a25);
            AltaArticulo(a26);
            AltaArticulo(a27);
            AltaArticulo(a28);
            AltaArticulo(a29);
            AltaArticulo(a30);
            AltaArticulo(a31);
            AltaArticulo(a32);
            AltaArticulo(a33);
            AltaArticulo(a34);
            AltaArticulo(a35);
            AltaArticulo(a36);
            AltaArticulo(a37);
            AltaArticulo(a38);
            AltaArticulo(a39);
            AltaArticulo(a40);
            AltaArticulo(a41);
            AltaArticulo(a42);
            AltaArticulo(a43);
            AltaArticulo(a44);
            AltaArticulo(a45);
            AltaArticulo(a46);
            AltaArticulo(a47);
            AltaArticulo(a48);
            AltaArticulo(a49);
            AltaArticulo(a50);

        }
        #endregion

        // ALTA ARTICULOS
        #region
        public List<Articulo> GetArticulo()
        {
            return _articulos;
        }

        public void AltaArticulo(Articulo articulo)
        {
            try
            {
                if (!_articulos.Contains(articulo))
                {
                    articulo.Validar();
                    _articulos.Add(articulo);
                }
                else
                {
                    throw new Exception("El articulo ya existe en el sistema");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        //PRECARGA VENTAS
        #region
        public void PrecargarVentas()
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

            Venta venta1 = new Venta("Verano en la playa", DateTime.Now, true);
            venta1.AltaArticulo(a1);
            venta1.AltaArticulo(a2);
            venta1.AltaArticulo(a3);
            venta1.AltaArticulo(a9);
            _publicaciones.Add(venta1);

            Venta venta2 = new Venta("Aventura en la naturaleza", DateTime.Now, false);
            venta2.AltaArticulo(a11);
            venta2.AltaArticulo(a12);
            venta2.AltaArticulo(a15);
            _publicaciones.Add(venta2);

            Venta venta3 = new Venta("Fotografía en la aventura", DateTime.Now, false);
            venta3.AltaArticulo(a18);
            venta3.AltaArticulo(a19);
            venta3.AltaArticulo(a20);
            _publicaciones.Add(venta3);

            Venta venta4 = new Venta("Diversión deportiva", DateTime.Now.AddDays(3), false);
            venta4.AltaArticulo(a26);
            venta4.AltaArticulo(a27);
            venta4.AltaArticulo(a30);
            _publicaciones.Add(venta4);

            Venta venta5 = new Venta("Cuidado personal y moda", DateTime.Now, false);
            venta5.AltaArticulo(a6);
            venta5.AltaArticulo(a8);
            venta5.AltaArticulo(a39);
            _publicaciones.Add(venta5);

            Venta venta6 = new Venta("Equipos electrónicos", DateTime.Now, true);
            venta6.AltaArticulo(a23);
            venta6.AltaArticulo(a25);
            _publicaciones.Add(venta6);

            Venta venta7 = new Venta("Manualidades y arte", DateTime.Now, true);
            venta7.AltaArticulo(a47);
            venta7.AltaArticulo(a48);
            _publicaciones.Add(venta7);

            Venta venta8 = new Venta("Cocina en casa", DateTime.Now, false);
            venta8.AltaArticulo(a40);
            venta8.AltaArticulo(a41);
            _publicaciones.Add(venta8);

            Venta venta9 = new Venta("Juegos de mesa y entretenimiento", DateTime.Now, true);
            venta9.AltaArticulo(a35);
            venta9.AltaArticulo(a36);
            _publicaciones.Add(venta9);

            Venta venta10 = new Venta("Seguridad y accesorios", DateTime.Now, false);
            venta10.AltaArticulo(a37);
            venta10.AltaArticulo(a38);
            _publicaciones.Add(venta10);
        }
        #endregion

        //traer los clientes
        //se puede usar metodo GetCliente PorEmail directo en instancia
        private void PrecargarSubastas()
        {
            Cliente cliente1 = GetClientePorEmail("luismartinez@gmail.com");
            Cliente cliente2 = GetClientePorEmail("anagomez@gmail.com");
            Cliente cliente3 = GetClientePorEmail("carloslopez@gmail.com");
            Cliente cliente4 = GetClientePorEmail("mariafernandez@gmail.com");
            Cliente cliente5 = GetClientePorEmail("sofiahernandez@gmail.com");
            Cliente cliente6 = GetClientePorEmail("pedrosanchez@gmail.com");
            Cliente cliente7 = GetClientePorEmail("lauramorales@gmail.com");
            Cliente cliente8 = GetClientePorEmail("javiercastillo@gmail.com");
            Cliente cliente9 = GetClientePorEmail("isabeltorres@gmail.com");
            Cliente cliente10 = GetClientePorEmail("juanrodriguez@gmail.com");


            Subasta s1 = new Subasta();



        }


        // METODO OBTENER ADMIN
        public Administrador GetAdministradorPorNombre(string nombre)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u is Administrador && u.Nombre == nombre)
                {
                    return (Administrador)u;
                }
            }
            return null;
        }


        // METODO OBTENER CLIENTE
        public Cliente GetClientePorEmail(string email)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente && u.Email == email)
                {
                    return (Cliente)u;
                }
            }
            return null;
        }

        // METODO PARA LITAR CLIENTES
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



        public Articulo GetArticuloPorNombre(string nombreArticulo)
        {
            foreach (Articulo a in _articulos)
            {
                if (a.Nombre == nombreArticulo)
                {
                    return a;
                }
            }
            return null;

        }

        // METODO PARA DAR DE ALTA UNA PUBLICACION
        public void AltaPublicacion(Publicacion publicacion)
        {
            if (publicacion == null)
            {
                throw new Exception("La publicación no puede ser nula.");
            }

            if (publicacion.Estado != Estado.ABIERTA)
            {
                throw new Exception("La publicación debe estar en estado ABIERTA.");
            }

            _publicaciones.Add(publicacion);
        }


        // METODO PARA LISTAR ARTICULOS POR CATEGORIA

        //que el metodo sea una lista y la retorne y despeus la capturamos en program 
        public void ListarArticulosPorCategoria(string categoria)
        {
            bool existeArticulo = false;

            foreach (Articulo a in _articulos)
            {
                if (a.Categoria == categoria)
                {
                    Console.WriteLine($"Nombre: {a.Nombre}, Precio: ${a.Precio}");
                    existeArticulo = true;
                }
            }

            if (!existeArticulo)
            {
                Console.WriteLine("No hay artículos disponibles en esta categoría.");
            }
        }


        //public void PrecargarPublicaciones()
        //{

        //}


        // METODO LISTAR PUBLICACIONES POR FECHA
        public List<Publicacion> ObtenerPublicacionesPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {

            List<Publicacion> publicacionesFiltradas = new List<Publicacion>();


            foreach (Publicacion p in _publicaciones)
            {
                if (p.FechaPublicacion >= fechaInicio && p.FechaPublicacion <= fechaFin)
                {
                    publicacionesFiltradas.Add(p);
                }
            }
            return publicacionesFiltradas;
        }

    }



}

