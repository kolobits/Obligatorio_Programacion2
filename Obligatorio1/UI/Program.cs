using Dominio;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.Instancia();

            //s.MostrarMenu();

            int opcion = -1;
            do
            {
                Console.WriteLine("---- Menú Principal ----");
                Console.WriteLine("1. Listar todos los clientes");
                Console.WriteLine("2. Listar artículos por categoría");
                Console.WriteLine("3. Alta de artículo");
                Console.WriteLine("4. Listar publicaciones entre dos fechas");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Lista de clientes:");
                        s.ListarClientes();
                        Console.ReadKey();
                        opcion = -1;
                        return;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Artículos por categoría");
                        s.ListarArticulosPorCategoria();  // ver como pasarlo a program
                        return;
                    case 3:
                        Console.Clear();
                        //s.ListarVentas();
                        //AltaArticulo();
                        Console.WriteLine("Ingrese articulo");
                        return;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Ingrese las fechas");
                        //ListarPublicacionesEntreFechas();
                        return;
                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intenta nuevamente.");
                        Console.ReadKey();
                        Console.Clear();
                        //MostrarMenu();
                        return;
                }

            } while (opcion != 5);



            Console.ReadKey();

            
        }







    }
}

