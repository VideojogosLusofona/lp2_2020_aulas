using System;

namespace ex4
{
    public static class Program
    {
        private static void Main()
        {

            Level level = new Level(
                'a', new float[] { 4.5f, 2.3f, 1.1f });

            Level levelShallow = level.ShallowCopy();
            Level levelDeep = level.NewCopy();

            level.IncScores();

            Console.WriteLine("level original:");
            Console.WriteLine($"\t{level}");

            Console.WriteLine("level shallow:");
            Console.WriteLine($"\t{levelShallow}");

            Console.WriteLine("level deep:");
            Console.WriteLine($"\t{levelDeep}");
        }
    }
}
