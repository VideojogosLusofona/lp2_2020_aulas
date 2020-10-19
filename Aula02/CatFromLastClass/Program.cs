using System;

namespace CatFromLastClass
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declarar os gatos
            Cat cat1, cat2;

            // Alterar os valores comuns a todos os gatos
            Cat.MaxEnergy = 300;
            Cat.EnergyGainAfterSleep = 25;
            Cat.EnergyLossAfterMeow = 2;
            Cat.EnergyLossAfterPlay = 14;

            // Criar dois gatos usando os diferentes construtores
            cat1 = new Cat("Lombriga");
            cat2 = new Cat(
                "Minhoca", 99, Feed.Full, Mood.HyperActive | Mood.Grumpy);

            // Mostrar estado de cada gato antes das ações
            Console.WriteLine("Estado inicial dos gatos:");

            ShowCat(cat1);
            ShowCat(cat2);

            Console.WriteLine("Ações dos gatos:");

            // Gato 1 brinca e diz miau
            Console.WriteLine($"\t{cat1.Name} plays");
            cat1.Play();
            Console.Write("\t");
            cat1.Meow();

            // Gato 2 come e dorme
            Console.WriteLine($"\t{cat2.Name} eats and sleeps");
            cat2.Eat();
            cat2.Sleep();

            // Estado dos gatos após terem efetuado algumas ações
            Console.WriteLine("Estado final dos gatos:");
            ShowCat(cat1);
            ShowCat(cat2);
        }

        private static void ShowCat(Cat cat)
        {
            Console.WriteLine(
                "\tNome={0}, Energia={1}, Alimentação={2}, Disposição={3}",
                cat.Name, cat.Energy, cat.FeedStatus, cat.MoodStatus);
        }
    }
}
