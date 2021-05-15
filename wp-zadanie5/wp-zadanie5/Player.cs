namespace wp_zadanie5
{
    public class Player : AbstractPlayer
    {
        private const int BaseAttack = 10;
        private const int BaseDefence = 10;
        private const int BaseHealthPoints = 10;

        public Player()
        {
            HealthPoints = BaseHealthPoints;
            Attack = BaseAttack;
            Defence = BaseDefence;
        }
    }
}