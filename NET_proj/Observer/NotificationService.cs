namespace NET_proj.Observer
{
    class NotificationService : ISubject
    {
        private readonly List<IObserver> _observers = [];
        public void Subscribe(IObserver observer) 
        {
            _observers.Add(observer);
        }
        public void Unsubscribe(IObserver observer) 
        {
            _observers.Remove(observer);
        }
        public void Notify(string message)
        {
            foreach (var o in _observers) 
            {
                o.Update(message);
            }
        }
    }
}
