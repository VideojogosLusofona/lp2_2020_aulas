using System;
using System.Collections.Generic;

namespace BuildingCollections
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Diferentes coleções de edifícios, inicialmente vazias
            List<Building> list = new List<Building>();
            Stack<Building> stack = new Stack<Building>();
            Queue<Building> queue = new Queue<Building>();
            HashSet<Building> set = new HashSet<Building>();

            // Criar 4 edifícios, colocá-los num array
            Building[] array = new Building[] {
                new Building("Small hut", 1000f, 25f),
                new Building("Skyscrapper", 1500f, 270.2f),
                new Building("Cave", 90f, 45.2f),
                new Building("Apartment", 365f, 90.5f)
            };

            // Colocar todos os edifícios em cada uma das coleções
            foreach (Building b in array)
            {
                list.Add(b);
                stack.Push(b);
                queue.Enqueue(b);
                set.Add(b);
            }

            // Colocar novamente o primeiro edifício em cada uma das coleções
            list.Add(array[0]);
            stack.Push(array[0]);
            queue.Enqueue(array[0]);
            set.Add(array[0]);

            // Mostrar os edifícios na lista
            Console.WriteLine("== Lista == ");
            foreach (Building b in list) Console.WriteLine($"\t{b}");

            // Mostrar os edifícios na stack
            Console.WriteLine("== Stack == ");
            foreach (Building b in stack) Console.WriteLine($"\t{b}");

            // Mostrar os edifícios na queue
            Console.WriteLine("== Queue == ");
            foreach (Building b in queue) Console.WriteLine($"\t{b}");

            // Mostrar os edifícios no hash set
            Console.WriteLine("== Hash Set == ");
            foreach (Building b in set) Console.WriteLine($"\t{b}");
        }
    }
}
