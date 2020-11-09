namespace Exercicio6
{
    public class GunClip : GunDecorator
    {
        private int additionalAmmo;

        public override int AmmoCapacity => base.AmmoCapacity + additionalAmmo;

        public GunClip(Gun gun, int additionalAmmo) : base(gun)
        {
            this.additionalAmmo = additionalAmmo;
        }
    }
}
