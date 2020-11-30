using UnityEngine;

public class WolvesAI : AnimalsAI
{
    protected override void SelectTarget()
    {
        Debug.Log("Wolves selected target");
    }

    protected override void Move()
    {
        Debug.Log("Wolves moved");
    }
    protected override void TryEat()
    {
        Debug.Log("Wolves tried to eat");
    }
    protected override void TryReproduce()
    {
        Debug.Log("Wolves tried to reproduce");
    }
}