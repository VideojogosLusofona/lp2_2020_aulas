namespace Exercicio6
{
    public abstract class GunDecorator : Gun
    {
        private Gun gun;

        public override int AmmoCapacity => gun.AmmoCapacity;
        public override float NoiseLevel => gun.NoiseLevel;

        public GunDecorator(Gun gun)
        {
            this.gun = gun;
        }
    }
}
