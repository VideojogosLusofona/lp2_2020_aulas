using System;

namespace Exercicio3
{
    /// <summary>
    /// Simple struct that contains a string and a method to concatenate it
    /// with another string.
    /// </summary>
    public struct StrConcat
    {
        /// <summary>
        /// The string contained in this struct.
        /// </summary>
        private readonly string myStr;

        /// <summary>
        /// Initialize the struct.
        /// </summary>
        /// <param name="str">The string to contain in this struct.</param>
        public StrConcat(string str)
        {
            myStr = str;
        }

        /// <summary>
        /// Concatenate the given string with the string contained in this
        /// struct.
        /// </summary>
        /// <param name="str">
        /// String to concatenate with the string contained in this struct.
        /// </param>
        public void ConcatAndPrint(string str)
        {
            Console.WriteLine(str + myStr);
        }
    }
}
