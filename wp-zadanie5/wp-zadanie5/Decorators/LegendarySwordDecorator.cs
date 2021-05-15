namespace wp_zadanie5.Decorators
{
    public class LegendarySwordDecorator : AbstractPlayer
    {
        private const int BaseAttack = 12;
        private const int BaseDefence = 2;
        private const int BaseHealthPoints = 0;


        public LegendarySwordDecorator(AbstractPlayer basePlayer)
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