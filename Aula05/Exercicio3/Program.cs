using System;

namespace Exercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.WriteLine("Insere um número inteiro");
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    $"Ocorreu o seguinte problema: {e.Message}");
            }
            Console.WriteLine($"Número inserido: {i}");
        }
    }
}
