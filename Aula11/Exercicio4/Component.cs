namespace Exercicio4
{
    // The base class for all components
    public abstract class Component : IGameObject
    {
        // The game object holding the component
        public GameObject ParentGameObject { get; set; }

        // Empty implementations of Start(), Update() and Finish(), so that
        // concrete components are not forced to implement all these methods
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Finish() { }
    }
}