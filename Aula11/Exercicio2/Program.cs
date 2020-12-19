using System;
using System.Threading;
using System.Collections.Concurrent;

namespace Exercicio2
{
    class Program
    {
        private enum Dir { Up, Down, Left, Right, None };

        private const int XMAX = 10;
        private const int YMAX = 10;

        private bool running;
        private BlockingCollection<ConsoleKey> input;
        private Dir dir;
        private Thread inputThread;
        private int x, y, xOld, yOld;

        private static void Main(string[] args)
        {
            Program p = new Program();
            p.GameLoop();
            p.Finish();
        }

        public Program()
        {
            input = new BlockingCollection<ConsoleKey>();
            inputThread = new Thread(ReadKeys);
            Console.CursorVisible = false;
        }

        private void GameLoop()
        {
            int msPerFrame = 20;
            Console.Clear();
            running = true;
            inputThread.Start();

            while (running)
            {
                int start = DateTime.Now.Millisecond;
                ProcessInput();
                Update();
                Render();
                Thread.Sleep(
                    start + msPerFrame - DateTime.Now.Millisecond);
            }
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
                        y = Math.Min(YMAX, y + 1);
                        break;
                    case Dir.Left:
                        x = Math.Max(0, x - 1);
                        break;
                    case Dir.Right:
                        x = Math.Min(XMAX, x + 1);
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

        private void Finish()
        {
            inputThread.Join();
            Console.CursorVisible = true;
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
