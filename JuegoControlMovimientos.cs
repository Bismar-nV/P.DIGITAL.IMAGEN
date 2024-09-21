using System;

namespace JuegoControlMovimientos
{
    class Jugador
    {
        public string Alias { get; private set; }

        public Jugador(string alias)
        {
            Alias = alias;
        }

        public void Desplazarse()
        {
            Console.WriteLine($"{Alias} se está desplazando.");
        }

        public void Atacar()
        {
            Console.WriteLine($"{Alias} ha realizado un ataque.");
        }

        public void Brincar()
        {
            Console.WriteLine($"{Alias} ha dado un salto.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Jugador jugador = new Jugador("Jugador1");

            bool enJuego = true;
            while (enJuego)
            {
                Console.Clear();
                Console.WriteLine("1. Desplazar Jugador");
                Console.WriteLine("2. Atacar");
                Console.WriteLine("3. Saltar");
                Console.WriteLine("4. Terminar");
                Console.Write("Elige una opción: ");
                string eleccion = Console.ReadLine();

                switch (eleccion)
                {
                    case "1":
                        jugador.Desplazarse();
                        break;

                    case "2":
                        jugador.Atacar();
                        break;

                    case "3":
                        jugador.Brincar();
                        break;

                    case "4":
                        enJuego = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }

                if (enJuego)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
