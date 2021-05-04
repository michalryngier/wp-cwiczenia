namespace wp_zadanie4.Units
{
    public class KnightUnitImpl : IUnit
    {
        public KnightUnitImpl()
        {
            Name = "Knight";
            HealthPoints = 200;
            AttackPoints = 20;
            AttackRange = 3;
            Cost = 150;
        }

        public int HealthPoints { get; set; }

        public string Name { get; }

        public int AttackPoints { get; }

        public int AttackRange { get; }

        public int Cost { get; }

        public new string ToString()
        {
            return "Name: " + Name + " | HP: " + HealthPoints + " | Attack: " + AttackPoints;
        }
    }
}