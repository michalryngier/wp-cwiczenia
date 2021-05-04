namespace wp_zadanie4.Units
{
    public interface IUnit
    {
        string ToString();
        string Name { get; }
        int AttackPoints { get; }
        int AttackRange { get; }
        int Cost { get; }
        int HealthPoints { get; set; }
    }
}