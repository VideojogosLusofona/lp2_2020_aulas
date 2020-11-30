using UnityEngine;

public class SpeedFirePower : Superpower
{
    [SerializeField]
    [Range(-1f, 1f)]
    private float speedBoostPercent = 0.2f;

    public override void Activate()
    {
        BoostSpeed(speedBoostPercent);
        LightMyFire();
    }
}
