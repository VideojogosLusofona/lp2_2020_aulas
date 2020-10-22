namespace GameInterfaces
{
    public class Building : IHasValue
    {
        public string Type { get; }
        public float Value { get; }
        public float Area { get; }

        public Building(string type, float  value, float area)
        {
            Type = type;
            Value = value;
            Area = area;
        }

        public override string ToString() =>
            $"{Type,-20}{Value,8:f2}${Area,8:f2}m2";

        // Método obrigatório devido à classe implementar IHasValue
        public bool Equals(IHasValue other)
        {
            if (other is null) return false;
            return Value == other.Value;
        }
    }
}
