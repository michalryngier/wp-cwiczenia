namespace wp_zadanie4.Units
{
    public class CatapultUnitImpl : IUnit
    {
        public CatapultUnitImpl()
        {
            Name = "Catapult";
            HealthPoints = 100;
            AttackPoints = 10;
            AttackRange = 10;
            Cost = 500;
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