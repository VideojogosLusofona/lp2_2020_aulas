using System;

namespace AdapterTest
{
    public class GermanShepherd : IDog
    {
        public void Bark()
        {
            Console.WriteLine("Woof Woof");
        }

        public void Fetch(object objectToFetch)
        {
            Console.WriteLine("German shepherd fetches "
                + objectToFetch.ToString());
        }
    }
}
