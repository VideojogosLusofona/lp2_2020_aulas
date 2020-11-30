
public abstract class AnimalsAI
{
    public void TakeTurn()
    {
        SelectTarget();
        Move();
        TryEat();
        TryReproduce();
    }

    protected virtual void SelectTarget() { }

    protected abstract void Move();
    protected abstract void TryEat();
    protected abstract void TryReproduce();
}
