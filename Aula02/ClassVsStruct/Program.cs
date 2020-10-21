using System;

namespace ClassVsStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1;
            p1 = new Player() { Health = 21.2f, Armor = 53.9f };

            Console.WriteLine("Valores iniciais:");
            Console.WriteLine("\tP1: Health={0}, Armor={1}",
                p1.Health, p1.Armor);

            DupHealth(p1);

            Console.WriteLine("Valores finais:");
            Console.WriteLine("\tP1: Health={0}, Armor={1}",
                p1.Health, p1.Armor);
        }

        private static void DupHealth(Player p)
        {
            p.Health *= 2;
        }
    }
}
