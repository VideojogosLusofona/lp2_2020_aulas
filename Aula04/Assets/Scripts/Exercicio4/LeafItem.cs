public class LeafItem : AbstractItem
{
    public override float Weight { get; }

    public LeafItem(float weight)
    {
        Weight = weight;
    }

    public override string ToString()
    {
        return $"Item with {Weight}Kg";
    }
}
