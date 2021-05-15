namespace wp_zadanie5.Decorators
{
    public class LegendarySwordDecorator : AbstractPlayer
    {
        private const int BaseAttack = 12;
        private const int BaseDefence = 2;
        private const int BaseHealthPoints = 0;

        private readonly AbstractPlayer _basePlayer;

        public LegendarySwordDecorator(AbstractPlayer basePlayer)
        {
            _basePlayer = basePlayer;
            HealthPoints = BaseHealthPoints + _basePlayer.HealthPoints;
            Attack = BaseAttack + _basePlayer.Attack;
            Defence = BaseDefence + _basePlayer.Defence;
        }

        public new static AbstractPlayer RemoveAttribute(AbstractPlayer basePlayer)
        {
            basePlayer.Attack -= BaseAttack;
            basePlayer.Defence -= BaseDefence;
            basePlayer.HealthPoints -= BaseHealthPoints;
            return basePlayer;
        }
    }
}