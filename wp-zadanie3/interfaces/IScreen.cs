namespace wp_zadanie3.interfaces
{
    public interface IScreen
    {
        string Name { get; }
        public void UpdateTime(string time);
    }
}