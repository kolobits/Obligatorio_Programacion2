using Dominio;

namespace UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.Instancia();

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
                        MostrarCategorias();
                        MostrarArticulosPorCategoria(s);
                        Console.ReadKey();
                        return;
                    case 3:
                        DarDeAltaArticulo(s);
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

        public static void MostrarCategorias()
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


        }

        public static string LeerCategoria(int opcion)
        {
            string categoria = "";

            switch (opcion)
            {
                case 1:
                    categoria = "Playa";
                    break;
                case 2:
                    categoria = "Aventura";
                    break;
                case 3:
                    categoria = "Ropa";
                    break;
                case 4:
                    categoria = "Accesorios";
                    break;
                case 5:
                    categoria = "Cuidado Personal";
                    break;
                case 6:
                    categoria = "Camping";
                    break;
                case 7:
                    categoria = "Fotografía";
                    break;
                case 8:
                    categoria = "Electrónica";
                    break;
                case 9:
                    categoria = "Deporte";
                    break;
                case 10:
                    categoria = "Juguetes";
                    break;
                case 11:
                    categoria = "Juegos";
                    break;
                case 12:
                    categoria = "Literatura";
                    break;
                case 13:
                    categoria = "Hogar";
                    break;
                case 14:
                    categoria = "Manualidades";
                    break;
                case 15:
                    categoria = "Arte";
                    break;
                case 16:
                    categoria = "Papelería";
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    return null; // Si es inválido, retorna null.
            }

            return categoria; // Retorna el nombre de la categoría
        }

        public static void MostrarArticulosPorCategoria(Sistema s)
        {
            int opcionCategoria = int.Parse(Console.ReadLine());
            string categoriaSeleccionada = LeerCategoria(opcionCategoria);
            if (categoriaSeleccionada != null)
            {
                s.ListarArticulosPorCategoria(categoriaSeleccionada);
            }
            else
            {
                Console.WriteLine("Categoría no válida, intenta nuevamente.");
            }
        }

        public static void DarDeAltaArticulo(Sistema s)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el nombre del articulo");
                string nombreArticulo = Console.ReadLine();
                Console.WriteLine("Ingrese la categoria del articulo");
                string categoriaArticulo = Console.ReadLine();
                Console.WriteLine("Ingrese el precio del articulo");
                double precioArticulo = double.Parse(Console.ReadLine());
                Articulo a = new Articulo(nombreArticulo, categoriaArticulo, precioArticulo);
                s.AltaArticulo(a);
                Console.WriteLine("Artículo dado de alta con éxito.");
                Console.ReadKey();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }








    }
}

