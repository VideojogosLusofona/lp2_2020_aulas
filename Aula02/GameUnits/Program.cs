using System;

namespace GameUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit[] units = new Unit[2];

            units[0] = new MilitaryUnit(3, 10, 100);
            units[1] = new SettlerUnit(1, 2);

            foreach (Unit u in units)
            {
                Console.WriteLine(u);
                u.Move();
                Console.WriteLine($"Health = {u.Health}");
                Console.WriteLine($"Value  = {u.Value}");
                Console.WriteLine("---------");
            }

            Console.WriteLine("Thank you for using this program!");
        }
    }
}
