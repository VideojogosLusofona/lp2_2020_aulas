namespace GameInterfaces
{
    public class SettlerUnit : Unit
    {
        public override float Value => 5;

        public SettlerUnit(
            int movement, int health)
            : base(movement, health)
        { }

        public void Settle()
        {
            // Criar aldeia/cidade
        }
    }
}
