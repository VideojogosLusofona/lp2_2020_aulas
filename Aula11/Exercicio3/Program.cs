using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Exercicio3
{
    class Program
    {
        private const int XMAX = 10;
        private const int YMAX = 10;

        private bool running;
        private BlockingCollection<ConsoleKey> input;
        private Dir dir;
        private Thread inputThread;
        private ICollection<GameObject> gameObjects;
        private DoubleBuffer2D<char> buffer2D;

        private static void Main(string[] args)
        {
            Program p = new Program();
            p.SetupScene();
            p.GameLoop();
            p.Finish();
        }

        public Program()
        {
            input = new BlockingCollection<ConsoleKey>();
            inputThread = new Thread(ReadKeys);
            gameObjects = new List<GameObject>();
            buffer2D = new DoubleBuffer2D<char>(XMAX, YMAX);
            Console.CursorVisible = false;
        }

        private void SetupScene()
        {
            GameObject player =
                new Player('X', new Vector2Int(XMAX, YMAX), () => dir);
            gameObjects.Add(player);
        }

        private void GameLoop()
        {
            int msPerFrame = 20;
            Console.Clear();
            running = true;
            inputThread.Start();

            // The actual game loop starts here, and keeps going while the
            // game is running.
            // This is implementation 2 of the game loops studied in class,
            // which will crash if the frame rate becomes lower than the
            // minimum frame time.
            // - Use implementation 3 if your game doesn't have physics.
            // - Or implementation 4 if your game does have physics (best
            //   approach).
            while (running)
            {
                int start = DateTime.Now.Millisecond;
                ProcessInput();
                foreach (GameObject gameObject in gameObjects)
                {
                    gameObject.Update();
                }
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
            else
            {
                dir = Dir.None;
            }
        }

        private void Render()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                Vector2Int position = gameObject.Position;
                buffer2D[position.X, position.Y] = gameObject.Sprite;
            }
            buffer2D.Swap();
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < YMAX; y++)
            {
                for (int x = 0; x < XMAX; x++)
                {
                    char sprite = buffer2D[x, y];
                    if (sprite != default) Console.Write(sprite);
                    else Console.Write(' ');
                }
                Console.WriteLine();
            }
            // Note for this rendering solution:
            // - This approach does not work for colored characters.
            // - It does not consider the z-buffer, so it's not possible to
            //   define when game objects should appear in front or behind
            //   others.
            // - It's very inefficient and will probably not work when there's
            //   too many game objects.
            // See https://github.com/fakenmc/CoreGameEngine/ for possible
            // solutions and ideas.
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
