using System;
using System.Collections.Generic;

namespace MyGenericMethod
{
    class Program
    {
        private static void Main(string[] args)
        {
            IHasValue[] stuffWithValue = new IHasValue[] {
                new Building("Small hut", 1000f, 25f),
                new MilitaryUnit(3, 50, 27),
                new SettlerUnit(2, 10),
                new Building("Cave", 5, 37.5f),
                new MilitaryUnit(10, 10, 5),
                new Building("Skyscrapper", 15005f, 2700.2f),
                new Building("Stadium", 15005f, 668.7f),
                new SettlerUnit(2, 20),
                new SettlerUnit(2, 20),
                new MilitaryUnit(120, 120, 25)
            };

            // How many buildings
            Console.WriteLine("No. buildings     : {0}",
                HowManyOfType<Building>(stuffWithValue));
            Console.WriteLine("No. units (any)   : {0}",
                HowManyOfType<Unit>(stuffWithValue));
            Console.WriteLine("No. settler units : {0}",
                HowManyOfType<SettlerUnit>(stuffWithValue));
            Console.WriteLine("No. military units: {0}",
                HowManyOfType<MilitaryUnit>(stuffWithValue));
        }

        private static int HowManyOfType<T>(IEnumerable<IHasValue> collection)
            where T : IHasValue
        {
            int count = 0;
            foreach (IHasValue item in collection) if (item is T) count++;
            return count;
        }
    }
}
