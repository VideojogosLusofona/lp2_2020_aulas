using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Exercicio5
{
    /// <summary>
    /// Resolução do exercício 5 da aula. 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Nome do ficheiro a ler.
        /// </summary>
        public const string FileName = "test.txt";

        /// <summary>
        /// URL do ficheiro de texto a descarregar da web.
        /// </summary>
        public const string TxtUrl = "http://textfiles.com/stories/roger1.txt";

        /// <summary>
        /// O programa começa aqui.
        /// </summary>
        static void Main()
        {
            // Linhas lidas do ficheiro
            string[] lines;

            // Resultados das queries
            int numLinesGt30;
            double avgCharsInLines;
            bool anyWithMoreThan120Chars;
            IEnumerable<string> firstWordOfLineWithCharY;

            // Se o ficheiro não tiver ainda sido descarregado da web, vamos
            // descarrega-lo
            if (!File.Exists(FileName))
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(TxtUrl), FileName);
                }
            }

            // Ler todas as linhas de ficheiro descarregado da web
            lines = File.ReadAllLines(FileName);

            // Indicar quantas linhas têm comprimento maior que 30 caracteres
            numLinesGt30 =
                (from line in lines select line.Length > 30).Count();
            Console.WriteLine($"Linhas > 30     : {numLinesGt30}");

            // Indicar a média do nº de caracteres das linhas lidas
            avgCharsInLines =
                (from line in lines select line.Length).Average();
            Console.WriteLine($"Média nº chars  : {avgCharsInLines:f}");

            // Indicar se existe alguma linha com mais de 120 caraceteres
            anyWithMoreThan120Chars =
                (from line in lines select line.Length > 120).Any();
            Console.WriteLine($"Algum com +120? : {anyWithMoreThan120Chars}");

            // Obter primeira palavra em maiúsculas das linhas que
            // contêm o carácter 'Y'
            firstWordOfLineWithCharY =
                from word in
                    (from line in lines
                     where line.Contains("Y")
                     select line.Split()[0].ToUpper())
                where word.Length > 0
                select word;

            // Mostrar primeira palavra em maiúsculas das linhas que
            // contêm o carácter 'Y'
            Console.WriteLine(
                "Primeira palavra em maiúsculas de linhas com 'Y'");
            foreach (string s in firstWordOfLineWithCharY)
            {
                Console.WriteLine($"\t{s}");
            }
        }
    }
}
