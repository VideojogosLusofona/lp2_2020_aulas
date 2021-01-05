using System;

namespace Lazy 
{
    public class LazySingletonFloat
    {
        private static readonly Lazy<LazySingletonFloat> instance =
            new Lazy<LazySingletonFloat>(() => new LazySingletonFloat());
        
        public static LazySingletonFloat Instance => instance.Value;

        public float MyFloat { get; set; }

        private LazySingletonFloat() { }
    }
}