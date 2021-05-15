namespace wp_zadanie5.Decorators
{
    public class LegendarySwordDecorator : AbstractPlayer
    {
        private const int BaseAttack = 12;
        private const int BaseDefence = 2;
        private const int BaseHealthPoints = 0;


        public LegendarySwordDecorator(AbstractPlayer? basePlayer = null)
        {
            HealthPoints = BaseHealthPoints + (basePlayer?.HealthPoints ?? 0);
            Attack = BaseAttack + (basePlayer?.Attack ?? 0);
            Defence = BaseDefence + (basePlayer?.Defence ?? 0);
        }
    }
}