using System;

namespace Podium
{
    /// <summary>
    /// This program tests our generic class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program starts here.
        /// </summary>
        /// <param name="args">Not used.</param>
        private static void Main(string[] args)
        {
            // Types of podium we'll test
            Podium<Building> podiumOfBuildings;
            Podium<int> podiumOfInts;

            // Test podium with 3 building objects, adding one at a time
            podiumOfBuildings = new Podium<Building>(3);
            podiumOfBuildings.Add(new Building("Small hut", 1000f, 25f));
            podiumOfBuildings.Add(new Building("Cave", 5, 37.5f));
            podiumOfBuildings.Add(new Building("Skyscrapper", 1500f, 2700.2f));
            podiumOfBuildings.Add(new Building("Stadium", 1800f, 668.7f));
            podiumOfBuildings.Add(new Building("School", 2500f, 350.0f));

            // List buildings in the podium
            Console.WriteLine(" ==== Podium of Buildings ====");
            foreach (Building b in podiumOfBuildings) Console.WriteLine(b);

            // Test podium of 5 ints, adding them all at once using collection
            // initialization syntax
            podiumOfInts = new Podium<int>(5)
            { 10, -1, -9, 500, -13, 55, 19, 101, -999, -2, -1, -7};

            // List ints in the podium
            Console.WriteLine(" ==== Podium of Ints ====");
            foreach (int i in podiumOfInts) Console.WriteLine($" -> {i}");

        }
    }
}
