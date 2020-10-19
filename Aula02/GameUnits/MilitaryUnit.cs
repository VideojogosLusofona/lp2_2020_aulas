namespace GameUnits
{
    public class MilitaryUnit : Unit
    {
        public int AttackPower { get; }
        public int XP { get; set; }

        public override int Health => base.Health + XP;
        public override float Value => AttackPower + XP;

        public MilitaryUnit(int movement, int health, int attackPower)
            : base(movement, health)
        {
            AttackPower = attackPower;
            XP = 4;
        }
        public void Attack(Unit u)
        {
        }
        public override string ToString()
        {
            return base.ToString()
                + $", AttackPower = {AttackPower}, XP = {XP}";
        }
    }
}