using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ingrese un numero para la serie fibonacci");
            int x;
            if (!int.TryParse(Console.ReadLine(), out x) || x <= 0)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número valido");
                return;
            }

            Console.WriteLine("Serie de Fibonacci hasta el límite especificado");
            Sfibonacci(x);
            return;
        }
        static void Sfibonacci(int x)
        {
            int numAnterior = 0;
            int numActual = 1;

            while (numActual <= x)
            {
                Console.WriteLine(numActual);
                int siguiente = numAnterior + numActual;
                numAnterior = numActual;
                numActual = siguiente;
            }
        }
    }
}
