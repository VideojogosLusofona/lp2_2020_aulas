using System;

namespace Exercicio1
{
    public class GrayWolf : IWolf
    {
        public void Howl()
        {
            Console.WriteLine("Awoooooooooo");
        }

        public void Chase(object objectToChase)
        {
            Console.WriteLine("Wolf chases "
                + objectToChase.ToString());
        }

        public void Kill(object objectToKill)
        {
            Console.WriteLine("Wolf kills "
                + objectToKill.ToString());
        }
    }
}