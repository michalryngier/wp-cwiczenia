using System;

namespace wp_zadanie3.screens
{
    public class LivingroomScreen : BaseScreenImpl
    {
        public LivingroomScreen() : base("Pokój") { }

        public override void UpdateTime(string time)
        {
            Console.WriteLine("W pokoju jest godzina: " + time);
        }
    }
}