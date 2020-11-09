using System;

namespace Exercicio6
{
    public abstract class Gun
    {
        public abstract int AmmoCapacity { get; }
        public abstract float NoiseLevel { get; }

        public virtual void Fire()
        {
            Console.WriteLine($"Ammo = {AmmoCapacity}, Noise = {NoiseLevel}");
        }
    }
}
