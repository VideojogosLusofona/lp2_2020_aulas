using System;

namespace Exercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            Gun mGun = new MachineGun();
            Gun sGun = new ShotGun();
            Gun mGunWithClip = new GunClip(mGun, 40);
            Gun mGunWithTwoClips = new GunClip(mGunWithClip, 60);
            Gun mGunWithEverything = new GunSilencer(mGunWithTwoClips, 0.9f);

            Console.Write("MachineGun:\n\t");
            mGun.Fire();
            Console.Write("ShotGun:\n\t");
            sGun.Fire();
            Console.Write("MachineGun with clip:\n\t");
            mGunWithClip.Fire();
            Console.Write("MachineGun with two clips:\n\t");
            mGunWithTwoClips.Fire();
            Console.Write("MachineGun with everything:\n\t");
            mGunWithEverything.Fire();

            try
            {
                new GunSilencer(mGun, 1.2f);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Thanks for shooting!!");
            }
        }
    }
}
