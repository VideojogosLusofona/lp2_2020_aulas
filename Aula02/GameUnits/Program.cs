using System;

namespace GameUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit mu = new MilitaryUnit(2, 100, 50);
            Unit su = new SettlerUnit(5, 25);

            mu.Move(new Vector2(2, -7));
            su.Move(new Vector2(-1, 4));

            Console.WriteLine(mu);
            Console.WriteLine(su);
        }
    }
}
