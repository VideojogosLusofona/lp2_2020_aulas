using System;

namespace Exercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and instantiate some vectors
            Vector2 v2 = new Vector2(-1.5f, 0.5f);
            Vector3 v3 = new Vector3(2.2f, -0.7f, 1.8f);

            // Declare two auxiliary vectors
            Vector2 v2aux;
            Vector3 v3aux;

            // Show information about these vectors
            Console.WriteLine($"v2 = {v2}");
            Console.WriteLine($"v3 = {v3}");

            // Implicitly convert a Vector2 into a Vector3 and show its values
            v3aux = v2;
            Console.WriteLine($"v3aux = {v3aux} [was v2 before]");

            // Explicitly convert a Vector3 into a Vector2 and show its values
            v2aux = (Vector2)v3;
            Console.WriteLine($"v2aux = {v2aux} [was v3 before]");
        }
    }
}
