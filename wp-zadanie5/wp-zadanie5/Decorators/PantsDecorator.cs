namespace wp_zadanie5.Decorators
{
    public class PantsDecorator : AbstractPlayer
    {
        private const int BaseAttack = 0;
        private const int BaseDefence = 5;
        private const int BaseHealthPoints = 0;

        public PantsDecorator(AbstractPlayer basePlayer)
        {
            HealthPoints = BaseHealthPoints + basePlayer.HealthPoints;
            Attack = BaseAttack + basePlayer.Attack;
            Defence = BaseDefence + basePlayer.Defence;
        }

        public static AbstractPlayer RemoveAttribute(AbstractPlayer basePlayer)
        {
            basePlayer.Attack -= BaseAttack;
            basePlayer.Defence -= BaseDefence;
            basePlayer.HealthPoints -= BaseHealthPoints;
            return basePlayer;
        }
    }
}