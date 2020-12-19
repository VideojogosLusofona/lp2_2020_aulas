using System;
using System.Threading;

class Program
{
    // Gerador de números aleatórios partilhado entre as threads
    private static Random rnd;

    // Lock para acesso ao gerador
    private static object threadLock;

    static void Main(string[] args)
    {
        rnd = new Random();
        threadLock = new object();

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
        for (int i = 0; i < 10; i++)
        {
            int waitForMillis;

            // Acesso ao gerador controlado pela lock
            lock (threadLock)
            {
                waitForMillis = rnd.Next(1000);
            }

            Thread.Sleep(waitForMillis);
            Console.WriteLine($"Rã #{id} deu salto #{i + 1}");
        }
    }
}
