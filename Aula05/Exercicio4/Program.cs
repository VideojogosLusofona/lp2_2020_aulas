using System;

namespace Exercicio4
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
            catch (FormatException)
            {
                Console.WriteLine("Erro: não é um inteiro válido");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erro: valor fora dos limites de Int32");
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
