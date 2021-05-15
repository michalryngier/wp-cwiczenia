using System;

namespace wp_zadanie5
{
    public abstract class AbstractPlayer
    {
        public int HealthPoints { get; set; }
        public int Attack { get; set; }
        public  int Defence { get; set; }

        public string CalculateStatistics()
        {
            return "HP: " + HealthPoints + "|Attack: " + Attack + "|Defence: " + Defence;
        }
        
        public AbstractPlayer RemoveAttribute(AbstractPlayer basePlayer)
        {
            basePlayer.Attack -= Attack;
            basePlayer.Defence -= Defence;
            basePlayer.HealthPoints -= HealthPoints;
            return basePlayer;
        }
    }
}