using System;
using System.Threading;
using System.Collections.Generic;

namespace Exercicio4
{
    class Program
    {
        // Game world dimensions
        private const int worldDimX = 10, worldDimY = 10;
        // List of game objects
        private IList<IGameObject> gameObjects;
        // Double buffer used for rendering
        private DoubleBuffer2D<char> buffer2D;
        // Target milliseconds per frame
        private int msPerFrame = 20;
        // Is the game running?
        private bool running = false;
        // Current frame
        int frame = 0;

        // Program starts here
        private static void Main(string[] args)
        {
            // Create a new program
            Program p = new Program();
            // Star the game loop on the new program instance
            p.GameLoop();
        }

        // Program constructor
        private Program()
        {
            // Game objects which will exist in our game
            GameObject background, player;

            // Components
            KeyReaderComponent krc;

            // Create a double buffer for rendering
            buffer2D = new DoubleBuffer2D<char>(worldDimX, worldDimY);

            // Instantiate the list of game objects
            gameObjects = new List<IGameObject>();

            // Create the background game object and add it a Background
            // component
            background = new GameObject("Background");
            background.AddComponent(
                new BackgroundComponent(buffer2D, worldDimX, worldDimY));

            // Create the player game object and add it a key reader
            // component (to capture input) and a move component, for moving
            // the player according to the input
            player = new GameObject("PlayerX");

            // Create the key reader (to capture input)
            krc = new KeyReaderComponent();
            // Set action to perform when escape is pressed
            krc.EscapePressed += () => running = false;
            // Add the key reader component to the player game object
            player.AddComponent(krc);

            // Add a move component, for moving the player
            player.AddComponent(new MoveComponent(
                worldDimX / 2, worldDimY / 2, worldDimX, worldDimY, buffer2D));

            // Add both game objects to the game object list
            gameObjects.Add(background);
            gameObjects.Add(player);

            // Important notes:
            // 1 - The key reader component approach used here is not usable
            //     when different game objects require input. Input processing
            //     should be done before game object updates().
            // 2 - The rendering depends on the order in which game objects are
            //     added to the game object list. This might work for simple
            //     games, but soon becomes unmanageable when the games starts
            //     becoming a bit more complex
            // ->  See https://github.com/fakenmc/CoreGameEngine/ for a more
            //     versatile (and more complex) solutions
        }

        // Run the game's game loop
        private void GameLoop()
        {
            // Clear the console and set running to true
            Console.Clear();
            running = true;

            // Call Start() on all game objects
            foreach (GameObject gObj in gameObjects) gObj.Start();

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
                // Frame start time
                long start = DateTime.Now.Ticks;

                // Call Update() on all game objects
                foreach (IGameObject gObj in gameObjects) gObj.Update();

                // Perform rendering
                Render();

                // Wait for next frame
                Thread.Sleep(
                    (int)(start / TimeSpan.TicksPerMillisecond
                    + msPerFrame
                    - DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond));
            }

            // Call Finish() on all game objects
            foreach (GameObject gObj in gameObjects) gObj.Finish();
        }

        // Perform rendering
        private void Render()
        {
            // Swap buffers in the double buffer
            buffer2D.Swap();
            // Set cursor position to top of the console
            Console.SetCursorPosition(0, 0);

            // Render information in the double buffer
            for (int y = 0; y < buffer2D.YDim; y++)
            {
                for (int x = 0; x < buffer2D.XDim; x++)
                {
                    if (buffer2D[x, y] == default) Console.Write(' ');
                    else Console.Write(buffer2D[x, y]);
                }
                Console.WriteLine();
            }

            // Render frame number (just for debugging purposes)
            Console.Write($"Frame: {frame++}\n");

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
    }
}
