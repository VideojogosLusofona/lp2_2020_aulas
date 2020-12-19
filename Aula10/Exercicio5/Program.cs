using System;

namespace Exercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and instantiate two vectors
            Vector3 v1 = new Vector3(5, 2, -1);
            Vector3 v2 = new Vector3(-1, 0, 1);

            // Show the vector values
            Console.WriteLine($"v1 = {v1}");
            Console.WriteLine($"v2 = {v2}");

            // Show the vector magnitudes
            Console.WriteLine($"v1.Magnitude = {v1.Magnitude}");
            Console.WriteLine($"v2.Magnitude = {v2.Magnitude}");

            // Sum two vectors
            Console.WriteLine($"v1 + v2 = {v1 + v2}");

            // Subtract two vectors
            Console.WriteLine($"v1 - v2 = {v1 - v2}");

            // Negate a vector
            Console.WriteLine($"-v1 = {-v1}");

            // Multiply a vector with a scalar
            Console.WriteLine($"v1 * 3 = {v1 * 3}");

            // Divide a vector with a scalar
            Console.WriteLine($"v1 / 2 = {v1 / 2}");

            // Check if two vectors are equal
            Console.WriteLine($"v1 == v2? {v1 == v2}");

            // Check if two vectors are different
            Console.WriteLine($"v1 != v2? {v1 != v2}");

            // Relational comparison between vectors
            Console.WriteLine($"v1 >  v2? {v1 > v2}");
            Console.WriteLine($"v1 >= v2? {v1 >= v2}");
            Console.WriteLine($"v1 <  v2? {v1 < v2}");
            Console.WriteLine($"v1 <= v2? {v1 <= v2}");
        }
    }
}
