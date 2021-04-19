using System;

namespace wp_zadanie3.screens
{
    public class KitchenScreen : BaseScreenImpl
    {
        public KitchenScreen() : base("Kuchnia") { }
        
        public override void UpdateTime(string time)
        {
            Console.WriteLine("W kuchni jest godzina: " + time);
        }
    }
}