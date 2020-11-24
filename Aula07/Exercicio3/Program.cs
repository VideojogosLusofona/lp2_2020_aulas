using System;

namespace Exercicio3
{
    class Program
    {
        /// <summary>
        /// Program starts here.
        /// </summary>
        /// <param name="args">Ignored.</param>
        static void Main(string[] args)
        {
            // Variable of the Action<string> delegate type
            Action<string> strOp;

            // An instance of the StrConcat struct
            StrConcat strConcat = new StrConcat("String In StrConcat");

            // Chain some methods onto our variable
            strOp = PrintUpper;  // static method
            strOp += PrintLower; // static method
            strOp += strConcat.ConcatAndPrint; // instance method

            // Invoke all methods via the variable
            strOp("This String Was Passed In tHe vAriAbLe");
        }

        /// <summary>
        /// Print the given string in upper case.
        /// </summary>
        /// <param name="str">The string to print in upper case.</param>
        static void PrintUpper(string str)
        {
            Console.WriteLine(str.ToUpper());
        }

        /// <summary>
        /// Print the given string in lower case.
        /// </summary>
        /// <param name="str">The string to print in lower case.</param>
        static void PrintLower(string str)
        {
            Console.WriteLine(str.ToLower());
        }
    }
}
