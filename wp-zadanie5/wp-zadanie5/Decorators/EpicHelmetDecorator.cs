namespace wp_zadanie5.Decorators
{
    public class EpicHelmetDecorator : AbstractPlayer
    {
        private const int BaseAttack = 0;
        private const int BaseDefence = 6;
        private const int BaseHealthPoints = 2;

        private readonly AbstractPlayer _basePlayer;

        public EpicHelmetDecorator(AbstractPlayer basePlayer)
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