using wp_zadanie3.interfaces;

namespace wp_zadanie3.screens
{
    public abstract class BaseScreenImpl : IScreen
    {
        protected BaseScreenImpl(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract void UpdateTime(string time);
    }
}