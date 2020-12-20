using System;

namespace Exercicio4
{
    // This component is used to move the player
    public class MoveComponent : Component
    {
        // Game world limits
        private readonly int maxX, maxY;
        // Current position of player
        private int x, y;
        // Buffer where player will draw itself
        private IBuffer2D<char> buffer;
        // A reference to the key reader component
        private KeyReaderComponent keyReader;

        // Create a new move component
        public MoveComponent(
            int x, int y, int maxX, int maxY, IBuffer2D<char> buffer)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            this.x = x;
            this.y = y;
            this.buffer = buffer;
        }

        // Start is called immediately before the game loop starts
        public override void Start()
        {
            // Get a reference to the key reader component
            keyReader = ParentGameObject.GetComponent<KeyReaderComponent>();
        }

        // Update is called once per frame
        public override void Update()
        {
            // Update player position if a key was pressed
            Dir dir = keyReader.Direction;
            if (dir != Dir.None)
            {
                switch (dir)
                {
                    case Dir.Up:
                        y = Math.Max(0, y - 1);
                        break;
                    case Dir.Down:
                        y = Math.Min(maxY - 1, y + 1);
                        break;
                    case Dir.Left:
                        x = Math.Max(0, x - 1);
                        break;
                    case Dir.Right:
                        x = Math.Min(maxX - 1, x + 1);
                        break;
                }
            }
            // Render the player in is current position
            buffer[x, y] = 'X';
        }
    }
}