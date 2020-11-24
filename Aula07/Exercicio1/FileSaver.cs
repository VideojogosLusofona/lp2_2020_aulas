using System;
using System.IO;
using System.Text;

namespace Exercicio1
{
    public class FileSaver : IObserver
    {
        // File where to put pressed keys
        private readonly string filename;

        // Constructor
        public FileSaver(string filename)
        {
            this.filename = filename;
        }

        // Update, called by the subject when something new is happening
        public void Update(ISubject sub)
        {
            // Get the last key pressed
            ConsoleKey key = (sub as KeyReader).Key;

            // Save it to a file
            File.AppendAllText(
                filename, key.ToString(), Encoding.UTF8);
        }
    }
}
