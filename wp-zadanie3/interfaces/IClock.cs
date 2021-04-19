namespace wp_zadanie3.interfaces
{
    public interface IClock
    {
        void NotifyObservers();
        void Subscribe(IScreen screen);
        void Unsubscribe(IScreen screen);
    }
}