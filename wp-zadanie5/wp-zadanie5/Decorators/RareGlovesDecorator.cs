namespace wp_zadanie5.Decorators
{
    public class RareGlovesDecorator : AbstractPlayer
    {
        private const int BaseAttack = 2;
        private const int BaseDefence = 5;
        private const int BaseHealthPoints = 0;

        public RareGlovesDecorator(AbstractPlayer? basePlayer = null)
        {
            HealthPoints = BaseHealthPoints + (basePlayer?.HealthPoints ?? 0);
            Attack = BaseAttack + (basePlayer?.Attack ?? 0);
            Defence = BaseDefence + (basePlayer?.Defence ?? 0);
        }
    }
}