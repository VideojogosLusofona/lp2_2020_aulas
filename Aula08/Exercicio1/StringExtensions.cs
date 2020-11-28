using System;
using System.IO;
using System.Text;

namespace Exercicio1
{
    /// <summary>
    /// Esta classe contém métodos de extensão para strings, nomeadamente
    /// três versões de um método que altera aleatoriamente a capitalização
    /// de uma string.
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        ///  Gerador de números aleatórios utilizado pelos vários métodos.
        /// </summary>
        private static Random rnd;

        /// <summary>
        /// Construtor da classe static (automaticamente invocado pelo C#),
        /// simplesmente instancia o gerador de números aleatórios.
        /// </summary>
        static StringExtensions()
        {
            rnd = new Random();
        }

        /// <summary>
        /// Primeira versão do método que usa concatenação para construir, de
        /// forma pouco eficiente, a nova string com capitalização modificada.
        /// </summary>
        /// <param name="str">A string original.</param>
        /// <returns>A string com capitalização modificada.</returns>
        public static string ToRandomCase1(this string str)
        {
            // Nova string, inicialmente colocada a null
            string newStr = null;

            // Se a string original for diferente de null, vamos alterar
            // aleatoriamente a sua capitalização
            if (str != null)
            {
                // Inicializar a nova string como uma string vazia
                newStr = "";

                // Percorrer a string original, caracter a caracter
                foreach (char c in str)
                {
                    // Converter aleatoriamente carácter atual em maiúscula ou
                    // minúscula
                    string newChar = rnd.NextDouble() < 0.5
                        ? c.ToString().ToLower()
                        : c.ToString().ToUpper();

                    // Adicionar carácter possivelmente modificado à nova
                    // string usando concatenação
                    newStr += newChar;
                }
            }

            // Devolver nova string com capitalização modificada
            return newStr;
        }

        /// <summary>
        /// Segunda versão do método, que usa a classe StringBuilder para
        /// construir de forma eficiente a nova string com capitalização
        /// modificada.
        /// </summary>
        /// <param name="str">A string original.</param>
        /// <returns>A string com capitalização modificada.</returns>
        public static string ToRandomCase2(this string str)
        {
            // Nova string, inicialmente colocada a null
            string newStr = null;

            // Se a string original for diferente de null, vamos alterar
            // aleatoriamente a sua capitalização
            if (str != null)
            {
                // Criar uma instância de StringBuilder para nos ajudar a
                // construir a nova string modificada (que terá comprimento
                // igual à string original)
                StringBuilder sb = new StringBuilder(str.Length);

                // Percorrer a string original, caracter a caracter
                foreach (char c in str)
                {
                    // Converter aleatoriamente carácter atual em maiúscula ou
                    // minúscula
                    string newChar = rnd.NextDouble() < 0.5
                        ? c.ToString().ToLower()
                        : c.ToString().ToUpper();

                    // Anexar carácter possivelmente modificado à instância de
                    // StringBuilder
                    sb.Append(newChar);
                }

                // Solicitar à instância de StringBuilder que construa uma
                // string com os caracteres anexados, e guardar essa string na
                // variável que contém a nova string modificada
                newStr = sb.ToString();
            }

            // Devolver nova string com capitalização modificada
            return newStr;
        }

        /// <summary>
        /// Terceira versão do método, que usa a classe StringWriter para
        /// construir de forma eficiente a nova string com capitalização
        /// modificada.
        /// </summary>
        /// <param name="str">A string original.</param>
        /// <returns>A string com capitalização modificada.</returns>
        public static string ToRandomCase3(this string str)
        {
            // Nova string, inicialmente colocada a null
            string newStr = null;

            // Se a string original for diferente de null, vamos alterar
            // aleatoriamente a sua capitalização
            if (str != null)
            {
                // Criar uma instância de StringWriter para nos ajudar a
                // construir a nova string modificada usando a abordagem
                // tipicamente usada para escrita em ficheiros
                StringWriter sw = new StringWriter();

                // Percorrer a string original, caracter a caracter
                foreach (char c in str)
                {
                    // Converter aleatoriamente carácter atual em maiúscula ou
                    // minúscula
                    string newChar = rnd.NextDouble() < 0.5
                        ? c.ToString().ToLower()
                        : c.ToString().ToUpper();

                    // "Escrever" caracter modificado na nova string, de forma
                    // semelhante à usada para escrever num ficheiro de texto
                    sw.Write(newChar);
                }

                // Solicitar à instância de StringWriter que devolva uma
                // string com os vários caracteres lá "escritos", e guardar
                // essa string na variável que contém a nova string modificada
                newStr = sw.ToString();
            }

            // Devolver nova string com capitalização modificada
            return newStr;
        }
    }
}
