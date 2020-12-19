using System;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleBuffer2D<char> db =
                new DoubleBuffer2D<char>(5, 5);

            db[1, 0] = 'X';
            db[2, 0] = 'X';
            db[3, 0] = 'X';
            db[4, 0] = 'X';
            db[1, 1] = 'X';
            db[1, 2] = 'X';
            db[2, 2] = 'X';
            db[3, 2] = 'X';
            db[3, 3] = 'X';
            db[0, 4] = 'X';
            db[1, 4] = 'X';
            db[2, 4] = 'X';
            db[3, 4] = 'X';

            db.Swap();

            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    if (db[x, y] == default) Console.Write(" ");
                    else Console.Write(db[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
