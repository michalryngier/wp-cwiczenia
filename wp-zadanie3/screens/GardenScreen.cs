using System;
using System.ComponentModel;

namespace wp_zadanie3.screens
{
    public class GardenScreen : BaseScreenImpl
    {
        public GardenScreen() : base("Ogród") { }

        public override void UpdateTime(string time)
        {
            Console.WriteLine("W ogrodzie jest godzina: " + time);
        }
    }
}