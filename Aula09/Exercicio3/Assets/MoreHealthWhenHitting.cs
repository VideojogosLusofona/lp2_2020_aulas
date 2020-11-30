using UnityEngine;

public class MoreHealthWhenHitting : Superpower
{
    [SerializeField]
    [Range(0, 100)]
    private float damageToDeal = 5;

    [SerializeField]
    [Range(0, 100)]
    private float healthToGain = 10;

    public override void Activate()
    {
        DealDamage(damageToDeal);
        Heal(healthToGain);
    }
}
