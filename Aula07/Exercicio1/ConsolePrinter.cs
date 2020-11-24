using System;

namespace Exercicio1
{
    public class ConsolePrinter : IObserver
    {
        // Update, called by the subject when something new is happening
        public void Update(ISubject sub)
        {
            // Get the last key pressed
            ConsoleKey key = (sub as KeyReader).Key;

            // Show the last key pressed
            Console.Write(key.ToString());
        }
    }
}
