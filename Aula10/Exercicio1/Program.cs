using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Thread t1 = new Thread(FrogRace);
        Thread t2 = new Thread(FrogRace);
        Thread t3 = new Thread(FrogRace);
        t1.Start(1);
        t2.Start(2);
        t3.Start(3);
        t1.Join();
        t2.Join();
        t3.Join();
    }

    private static void FrogRace(object o)
    {
        int id = (int)o;

        // É importante que cada thread tenha um gerador de números aleatórios
        // inicializado com uma semente diferente. Neste caso usamos o
        // número da thread.
        Random rnd = new Random(id);

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(rnd.Next(1000));
            Console.WriteLine($"Rã #{id} deu salto #{i + 1}");
        }
    }
}
