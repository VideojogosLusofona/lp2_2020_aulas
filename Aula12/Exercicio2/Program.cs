using System;

namespace Lazy
{
    public class Program
    {
        private static void Main(string[] args)
        {
            SetValue(5.34f);
            PrintValue();
        }

        private static void SetValue(float value)
        {
            LazySingletonFloat.Instance.MyFloat = value;
        }

        private static void PrintValue()
        {
            float x = LazySingletonFloat.Instance.MyFloat;
            Console.WriteLine(x);
        }
    }
}
