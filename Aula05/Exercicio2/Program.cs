using System;

namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            Console.WriteLine("Insere um número inteiro");
            i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Número inserido: {i}");
        }
    }
}
