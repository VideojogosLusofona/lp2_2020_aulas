using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Exercicio4
{
    // Class for all game objects, which is basically a container for components
    public class GameObject : IGameObject
    {
        // The name of this game object
        public string Name { get; }

        // The components in this game object
        private readonly ICollection<Component> components;

        // Create a new game object
        public GameObject(string name)
        {
            Name = name;
            components = new List<Component>();
        }

        // Add a component to this game object
        public void AddComponent(Component component)
        {
            // Add component to this game object
            components.Add(component);
            // Set this game object as the container of the component
            component.ParentGameObject = this;
        }

        // Get the first component of the specified type
        public T GetComponent<T>() where T : Component
        {
            return components.FirstOrDefault(component => component is T) as T;
        }

        // Get all components of specified type
        public IEnumerable<T> GetComponents<T>() where T : Component
        {
            return components
                .Where(component => component is T)
                .Select((component => component as T));
        }

        // Start all components in this game object
        public void Start()
        {
            foreach (Component component in components)
            {
                component.Start();
            }
        }

        // Update all components in this game object
        public void Update()
        {
            foreach (Component component in components)
            {
                component.Update();
            }
        }

        // Finish all components in this game object
        public void Finish()
        {
            foreach (Component component in components)
            {
                component.Finish();
            }
        }
    }
}