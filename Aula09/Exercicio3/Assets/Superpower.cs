using UnityEngine;

public abstract class Superpower : MonoBehaviour
{
    public abstract void Activate();

    protected void DealDamage(float damage)
    {
        Debug.Log($"Caused {damage} damage!");
    }

    protected void Heal(float health)
    {
        Debug.Log($"I've gained {health} health!");
    }

    protected void LightMyFire()
    {
        Debug.Log($"FIRE! Something is burning!");
    }

    protected void BoostSpeed(float percent)
    {
        if (percent > 0)
        {
            Debug.Log($"I'm going {percent * 100}% faster!");
        }
        else
        {
            Debug.Log($"I'm going {percent * -100}% slower!");
        }
    }

    // More...
}
