using System;
using System.Threading;
using System.Collections.Concurrent;

namespace Exercicio3
{
    // A key reader components
    // Note that this implementation is very limited, since only one game
    // object can have this component.
    // See https://github.com/fakenmc/CoreGameEngine/ for a better approach.
    public class KeyReaderComponent : Component
    {
        // Direction to move
        public Dir Direction { get; private set; }
        // Collection used for the input thread to communicate with the
        // component in the main thread
        private BlockingCollection<ConsoleKey> input;
        // The input thread
        private Thread inputThread;

        // Start is called immediately before the game loop starts
        public override void Start()
        {
            // Initially there is no direction
            Direction = Dir.None;
            // Instantiate the thread communication collection
            input = new BlockingCollection<ConsoleKey>();
            // Create and start the input thread
            inputThread = new Thread(ReadKeys);
            inputThread.Start();
            // Make sure cursor doesn't blink in the middle of the game
            Console.CursorVisible = false;
        }

        // Update is called once per frame
        public override void Update()
        {
            // A possible key that was pressed
            ConsoleKey key;

            // Was any key pressed?
            if (input.TryTake(out key))
            {
                // If so, let's check out what key was pressed and set the
                // direction accordingly
                switch (key)
                {
                    case ConsoleKey.W:
                        Direction = Dir.Up;
                        break;
                    case ConsoleKey.A:
                        Direction = Dir.Left;
                        break;
                    case ConsoleKey.S:
                        Direction = Dir.Down;
                        break;
                    case ConsoleKey.D:
                        Direction = Dir.Right;
                        break;
                    case ConsoleKey.Escape:
                        // If the escape key was read, notify
                        // possible listeners
                        OnEscapePressed();
                        break;
                    default:
                        Direction = Dir.None;
                        break;
                }
            }
            else
            {
                // If no key was pressed, set direction to none
                Direction = Dir.None;
            }
        }

        // Finish() is called after the game loop terminates
        public override void Finish()
        {
            // Make sure cursor is again visible
            Console.CursorVisible = true;
            // Wait for the input thread
            inputThread.Join();
        }

        // This method will run inside the input thread, waiting for keys to
        // be pressed
        private void ReadKeys()
        {
            ConsoleKey ck;
            do
            {
                // When a key is pressed, add it to the collection
                ck = Console.ReadKey(true).Key;
                input.Add(ck);
            } while (ck != ConsoleKey.Escape);
        }

        // Following good practices, this method invokes the EscapePressed
        // event
        private void OnEscapePressed()
        {
            EscapePressed?.Invoke();
        }

        // Event to be invoked when the Escape key is detected
        public event Action EscapePressed;
    }
}