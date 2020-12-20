using System;

namespace Exercicio3
{
    public class Player : GameObject
    {
        private Func<Dir> getDirection;
        private Vector2Int limits;
        public override char Sprite { get; }

        public Player(char sprite, Vector2Int limits, Func<Dir> getDirection)
        {
            Sprite = sprite;
            this.limits = limits;
            this.getDirection = getDirection;
        }

        public override void Update()
        {
            Dir dir = getDirection();

            if (dir != Dir.None)
            {
                int x = Position.X;
                int y = Position.Y;

                switch (dir)
                {
                    case Dir.Up:
                        y = Math.Max(0, y - 1);
                        break;
                    case Dir.Down:
                        y = Math.Min(limits.Y - 1, y + 1);
                        break;
                    case Dir.Left:
                        x = Math.Max(0, x - 1);
                        break;
                    case Dir.Right:
                        x = Math.Min(limits.X - 1, x + 1);
                        break;
                }

                Position = new Vector2Int(x, y);
            }
        }
    }
}