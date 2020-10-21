namespace GameUnits
{
    public class MilitaryUnit : Unit
    {
        public int AttackPower { get; }
        public int XP { get; set; }
        public override int Health => base.Health + XP;
        public override float Value => AttackPower + XP;

        public MilitaryUnit(
            int movement, int health,
            int attackPower)
            : base(movement, health)
        {
            AttackPower = attackPower;
            XP = 0;
        }

        public void Attack(Unit u)
        {
            // Attack some other unit
        }

        public override string ToString() =>
            base.ToString() + $", AP={AttackPower}, XP={XP}";
    }
}