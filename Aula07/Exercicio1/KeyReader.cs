using System;
using System.Collections.Generic;

namespace Exercicio1
{
    public class KeyReader : ISubject
    {
        // The last key read from the console
        public ConsoleKey Key
        {
            get
            {
                // Return the latest key read
                return key;
            }
            private set
            {
                // Set the latest key read
                key = value;
                // Notify observers that we have a new key read
                NotifyObservers();
            }
        }

        // Support variable for the Key property
        private ConsoleKey key;

        // Our current observers are kept here
        private readonly ICollection<IObserver> observers;

        // Constructor
        public KeyReader()
        {
            // Instantiate the list of observers
            observers = new List<IObserver>();
        }

        // Register an observer
        public void RegisterObserver(IObserver obs)
        {
            observers.Add(obs);
        }

        // Remover an observer
        public void RemoveObserver(IObserver obs)
        {
            observers.Remove(obs);
        }

        // Notify observers
        private void NotifyObservers()
        {
            foreach (IObserver obs in observers)
            {
                obs.Update(this);
            }
        }

        // Read keys from console
        public void ReadKeys()
        {
            // Ask for keys while user does not press Escape
            do
            {
                // Read key
                Key = Console.ReadKey(true).Key;
            }
            while (Key != ConsoleKey.Escape);
        }
    }
}
