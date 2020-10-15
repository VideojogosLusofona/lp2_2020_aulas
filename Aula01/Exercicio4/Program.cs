using System;

namespace Exercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar dois gatos usando os diferentes construtores
            Cat cat1 = new Cat("Lombriga");
            Cat cat2 = new Cat("Minhoca", 99, Feed.Full, Mood.HyperActive);

            // Mostrar estado de cada gato
            Console.WriteLine("Nome={0}, Energia={1}, Aliment.={2}, Disp.={3}",
                cat1.GetName(), cat1.GetEnergy(), cat1.GetFeed(), cat1.GetMood());

            Console.WriteLine("Nome={0}, Energia={1}, Aliment.={2}, Disp.={3}",
                cat2.GetName(), cat2.GetEnergy(), cat2.GetFeed(), cat2.GetMood());
        }
    }
}
