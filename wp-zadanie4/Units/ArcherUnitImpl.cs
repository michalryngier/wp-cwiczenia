namespace wp_zadanie4.Units
{
    public class ArcherUnitImpl : IUnit
    {
        public ArcherUnitImpl()
        {
            Name = "Archer";
            HealthPoints = 50;
            AttackPoints = 8;
            AttackRange = 8;
            Cost = 50;
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