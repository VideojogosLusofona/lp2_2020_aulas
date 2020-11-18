using System;

namespace Exercicio1
{
    public class BrownBear : IBear
    {
        public bool Hibernating { get; set; }

        public void GoTowards(object objectToWalkTowards)
        {
            if (!Hibernating)
            {
                Console.WriteLine(
                    "Brown bear walks towards "
                    + objectToWalkTowards.ToString());
            }
        }

        public void LookAt(object objectToLookAt)
        {
            if (!Hibernating)
            {
                Console.WriteLine(
                    "Brown bear looks at " + objectToLookAt.ToString());
            }
        }

        public void Roar()
        {
            if (!Hibernating)
            {
                Console.WriteLine("Roooooooooarrrrr");
            }
        }

        public bool TryEat(object objectToEat)
        {
            if (!Hibernating)
            {
                Console.WriteLine("Bear eats " + objectToEat.ToString());
                return true;
            }
            return false;
        }
    }
}
