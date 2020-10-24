using System;

namespace GameInterfaces
{
    class Program
    {
        private static void Main(string[] args)
        {
            IHasValue[] stuffWithValue = new IHasValue[10];
            IHasValue previous = null;

            stuffWithValue[0] = new Building("Small hut", 1000f, 25f);
            stuffWithValue[1] = new MilitaryUnit(3, 50, 27);
            stuffWithValue[2] = new SettlerUnit(2, 10);
            stuffWithValue[3] = new Building("Cave", 5, 37.5f);
            stuffWithValue[4] = new MilitaryUnit(10, 10, 5);
            stuffWithValue[5] = new Building("Skyscrapper", 15005f, 2700.2f);
            stuffWithValue[6] = new Building("Stadium", 15005f, 668.7f);
            stuffWithValue[7] = new SettlerUnit(2, 20);
            stuffWithValue[8] = new SettlerUnit(2, 20);
            stuffWithValue[9] = new MilitaryUnit(120, 120, 25);

            foreach (IHasValue ihv in stuffWithValue)
            {
                Console.WriteLine("{0}, {1} to previous",
                    ihv.GetType().Name,
                    ihv.Equals(previous) ? "equal" : "NOT equal");

                previous = ihv;
            }
        }
    }
}
