using System;

namespace wp_zadanie3.screens
{
    public interface IScreen
    {
        string Name { get; }
        public void UpdateTime(string time);
    }
}