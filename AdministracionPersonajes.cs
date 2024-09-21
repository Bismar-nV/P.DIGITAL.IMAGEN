using System;
using System.Collections.Generic;

namespace AdministracionPersonajes
{
    class Personaje
    {
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public string Categoria { get; private set; }
        public string Habilidades { get; private set; }

        private static List<Personaje> listaPersonajes = new List<Personaje>();

        public Personaje(string nombre, string descripcion, string categoria, string habilidades)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            Habilidades = habilidades;
        }

        public static void AgregarPersonaje(string nombre, string descripcion, string categoria, string habilidades)
        {
            listaPersonajes.Add(new Personaje(nombre, descripcion, categoria, habilidades));
            Console.WriteLine("Personaje agregado correctamente.");
        }

        public static void MostrarPersonajes()
        {
            if (listaPersonajes.Count == 0)
            {
                Console.WriteLine("No existen personajes en la lista.");
                return;
            }

            Console.WriteLine("\nPersonajes disponibles:");
            for (int i = 0; i < listaPersonajes.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {listaPersonajes[i].Nombre}");
            }
        }

        public static void ModificarPersonaje(int posicion, string nuevoNombre, string nuevaDescripcion, string nuevaCategoria, string nuevasHabilidades)
        {
            if (posicion >= 0 && posicion < listaPersonajes.Count)
            {
                var personaje = listaPersonajes[posicion];
                personaje.Nombre = nuevoNombre;
                personaje.Descripcion = nuevaDescripcion;
                personaje.Categoria = nuevaCategoria;
                personaje.Habilidades = nuevasHabilidades;
                Console.WriteLine("Personaje actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Índice no válido.");
            }
        }

        public static void BorrarPersonaje(int posicion)
        {
            if (posicion >= 0 && posicion < listaPersonajes.Count)
            {
                listaPersonajes.RemoveAt(posicion);
                Console.WriteLine("Personaje eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Índice no válido.");
            }
        }
    }

    class Aplicacion
    {
        static void Main(string[] args)
        {
            bool ejecutando = true;

            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("1. Añadir nuevo Personaje");
                Console.WriteLine("2. Ver lista de Personajes");
                Console.WriteLine("3. Modificar Personaje");
                Console.WriteLine("4. Eliminar Personaje");
                Console.WriteLine("5. Salir del programa");
                Console.Write("Selecciona una opción: ");
                string eleccion = Console.ReadLine();

                int indice;
                string nombre, descripcion, categoria, habilidades;

                switch (eleccion)
                {
                    case "1":
                        Console.Write("Introduce el nombre del personaje: ");
                        nombre = Console.ReadLine();
                        Console.Write("Describe al personaje: ");
                        descripcion = Console.ReadLine();
                        Console.Write("Indica la categoría del personaje: ");
                        categoria = Console.ReadLine();
                        Console.Write("Especifica las habilidades del personaje: ");
                        habilidades = Console.ReadLine();
                        Personaje.AgregarPersonaje(nombre, descripcion, categoria, habilidades);
                        break;

                    case "2":
                        Personaje.MostrarPersonajes();
                        break;

                    case "3":
                        Console.Write("Introduce el número del personaje a modificar: ");
                        try
                        {
                            indice = int.Parse(Console.ReadLine()) - 1;
                            Console.Write("Introduce el nuevo nombre: ");
                            nombre = Console.ReadLine();
                            Console.Write("Introduce la nueva descripción: ");
                            descripcion = Console.ReadLine();
                            Console.Write("Introduce la nueva categoría: ");
                            categoria = Console.ReadLine();
                            Console.Write("Introduce las nuevas habilidades: ");
                            habilidades = Console.ReadLine();
                            Personaje.ModificarPersonaje(indice, nombre, descripcion, categoria, habilidades);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formato no válido.");
                        }
                        break;

                    case "4":
                        Console.Write("Introduce el número del personaje a eliminar: ");
                        try
                        {
                            indice = int.Parse(Console.ReadLine()) - 1;
                            Personaje.BorrarPersonaje(indice);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formato no válido.");
                        }
                        break;

                    case "5":
                        ejecutando = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (ejecutando)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
