using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Exercicio4
{
    /// <summary>
    /// Resolução do exercício 4 da aula.
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
            numLinesGt30 = lines.Count(s => s.Length > 30);
            Console.WriteLine($"Linhas > 30     : {numLinesGt30}");

            // Indicar a média do nº de caracteres das linhas lidas
            avgCharsInLines = lines.Average(s => s.Length);
            Console.WriteLine($"Média nº chars  : {avgCharsInLines:f}");

            // Indicar se existe alguma linha com mais de 120 caraceteres
            anyWithMoreThan120Chars = lines.Any(s => s.Length > 120);
            Console.WriteLine($"Algum com +120? : {anyWithMoreThan120Chars}");

            // Obter primeira palavra em maiúsculas das linhas que
            // contêm o carácter 'Y'
            firstWordOfLineWithCharY = lines
                .Where(s => s.Contains("Y"))
                .Select(s => s.Trim().Split()[0].ToUpper());

            // Mostrar primeira palavra em maiúsculas das linhas que
            // contêm o carácter 'Y'
            Console.WriteLine(
                "Primeira palavra em maiúsculas de linhas com 'Y'");
            foreach (string s in firstWordOfLineWithCharY)
            {
                Console.WriteLine($"=> {s}");
            }
        }
    }
}
