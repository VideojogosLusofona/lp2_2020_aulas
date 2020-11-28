using System;

namespace Exercicio1
{
    /// <summary>
    /// Esta classe serve para testar a classe StringExtensions.
    /// </summary>
    class Program
    {
        /// <summary>
        /// O programa começa aqui.
        /// </summary>
        static void Main()
        {
            // A string original
            string str = "Uma string perfeitamente normal!";

            // Strings com capitalização modificada, cada uma criada com um
            // método diferente
            string strMod1 = str.ToRandomCase1(); // Através de concatenação
            string strMod2 = str.ToRandomCase2(); // Usando StringBuilder
            string strMod3 = str.ToRandomCase3(); // Usando StringWriter

            // Mostrar todas as strings
            Console.WriteLine($"Original                       : {str}");
            Console.WriteLine($"Criada através de concatenação : {strMod1}");
            Console.WriteLine($"Criada com StringBuilder       : {strMod2}");
            Console.WriteLine($"Criada com StringWriter        : {strMod3}");
        }
    }
}
