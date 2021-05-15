namespace wp_zadanie5.Decorators
{
    public class EpicHelmetDecorator : AbstractPlayer
    {
        private const int BaseAttack = 0;
        private const int BaseDefence = 6;
        private const int BaseHealthPoints = 2;

        public EpicHelmetDecorator(AbstractPlayer? basePlayer = null)
        {
            HealthPoints = BaseHealthPoints + (basePlayer?.HealthPoints ?? 0);
            Attack = BaseAttack + (basePlayer?.Attack ?? 0);
            Defence = BaseDefence + (basePlayer?.Defence ?? 0);
        }
    }
}