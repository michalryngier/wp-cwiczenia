#nullable enable
namespace wp_zadanie5.Decorators
{
    public class CommonBootsDecorator : AbstractPlayer
    {
        private const int BaseAttack = 0;
        private const int BaseDefence = 3;
        private const int BaseHealthPoints = 0;

        public CommonBootsDecorator(AbstractPlayer? basePlayer = null)
        {
            HealthPoints = BaseHealthPoints + (basePlayer?.HealthPoints ?? 0);
            Attack = BaseAttack + (basePlayer?.Attack ?? 0);
            Defence = BaseDefence + (basePlayer?.Defence ?? 0);
        }
    }
}