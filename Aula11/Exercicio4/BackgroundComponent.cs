namespace Exercicio4
{
    // Background component, for rendering a simple background
    public class BackgroundComponent : Component
    {
        // Limits of the game area
        private readonly int maxX, maxY;
        // The buffer used for rendering
        private IBuffer2D<char> buffer;

        // Create a new background component
        public BackgroundComponent(IBuffer2D<char> buffer, int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            this.buffer = buffer;
        }

        // Update this component
        public override void Update()
        {
            // Draw the background into the buffer
            for (int y = 0; y < maxY; y++)
                for (int x = 0; x < maxX; x++)
                    buffer[x, y] = '.';
        }
    }
}