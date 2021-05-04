namespace wp_zadanie4.Units
{
    public class InfantryUnitImpl : IUnit
    {
        public InfantryUnitImpl()
        {
            Name = "Infantry";
            HealthPoints = 50;
            AttackPoints = 10;
            AttackRange = 4;
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