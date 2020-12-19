using System;
using System.Threading;
using System.Collections.Concurrent;

namespace Exercicio2
{
    class Program
    {
        private enum Dir { Up, Down, Left, Right, None }
        private BlockingCollection<ConsoleKey> input;
        private Thread inputThread;
        private int x, y, xOld, yOld;
        private readonly int maxX, maxY;
        private Dir dir;
        private bool running;

        private static void Main(string[] args)
        {
            Program p = new Program();
            p.GameLoop();
        }

        private Program()
        {
            input = new BlockingCollection<ConsoleKey>();
            inputThread = new Thread(ReadKeys);
            maxX = 10;
            maxY = 10;
            x = 5;
            y = 5;
            dir = Dir.None;
            inputThread.Start();
            Console.CursorVisible = false;
        }

        private void GameLoop()
        {
            int msPerFrame = 20;
            Console.Clear();
            running = true;
            while (running)
            {
                long start = DateTime.Now.Ticks;
                ProcessInput();
                Update();
                Render();
                Thread.Sleep(
                    (int)(start / TimeSpan.TicksPerMillisecond
                    + msPerFrame
                    - DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond));
            }
        }

        private void Finish()
        {
            Console.CursorVisible = true;
            inputThread.Join();
        }

        private void ProcessInput()
        {
            ConsoleKey key;
            if (input.TryTake(out key))
            {
                switch (key)
                {
                    case ConsoleKey.W:
                        dir = Dir.Up;
                        break;
                    case ConsoleKey.A:
                        dir = Dir.Left;
                        break;
                    case ConsoleKey.S:
                        dir = Dir.Down;
                        break;
                    case ConsoleKey.D:
                        dir = Dir.Right;
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }
        }

        private void Update()
        {
            if (dir != Dir.None)
            {
                xOld = x;
                yOld = y;
                switch (dir)
                {
                    case Dir.Up:
                        y = Math.Max(0, y - 1);
                        break;
                    case Dir.Down:
                        y = Math.Min(maxY, y + 1);
                        break;
                    case Dir.Left:
                        x = Math.Max(0, x - 1);
                        break;
                    case Dir.Right:
                        x = Math.Min(maxX, x + 1);
                        break;
                }
                dir = Dir.None;
            }
        }

        private void Render()
        {
            Console.SetCursorPosition(xOld, yOld);
            Console.Write(" ");
            Console.SetCursorPosition(x, y);
            Console.Write("X");
        }

        private void ReadKeys()
        {
            ConsoleKey ck;
            do
            {
                ck = Console.ReadKey(true).Key;
                input.Add(ck);
            } while (ck != ConsoleKey.Escape);
        }
    }
}
