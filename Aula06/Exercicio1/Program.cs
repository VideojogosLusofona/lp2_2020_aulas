using System;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a german shepherd, a dog-adapted gray wolf and a
            // dog-adapted brown bear
            IDog dog1 = new GermanShepherd();
            IDog dog2 = new WolfAdapter(new GrayWolf());
            IDog dog3 = new BearAdapter(new BrownBear());

            // Run dog methods on the german shepherd
            Console.WriteLine($"== Dog 1 ({dog1.GetType().Name}) ==");
            dog1.Bark();
            dog1.Fetch("toy");

            Console.WriteLine();

            // Run dog methods on the dog-adapted gray wolf
            Console.WriteLine($"== Dog 2 ({dog2.GetType().Name}) ==");
            dog2.Bark();
            dog2.Fetch("rabbit");

            Console.WriteLine();

            // Run dog methods on the dog-adapted brown bear
            Console.WriteLine($"== Dog 3 ({dog3.GetType().Name}) ==");
            dog3.Bark();
            dog3.Fetch("salmon");

            Console.WriteLine();

        }
    }
}
