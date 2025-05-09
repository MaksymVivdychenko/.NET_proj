namespace NET_proj.Observer
{
    interface ISubject
    {
        void Register(IObserver observer);
        void Remove(IObserver observer);
        void Notify(string message);
    }
}
