namespace Exercicio3
{
    /// <summary>
    /// Base classe for game objects.
    /// </summary>
    /// <remarks>
    /// Game objects without components like presented in this example are very
    /// limited.
    /// </remarks>
    public abstract class GameObject
    {
        public Vector2Int Position { get; protected set; }

        public abstract char Sprite { get; }

        public abstract void Update();

    }
}