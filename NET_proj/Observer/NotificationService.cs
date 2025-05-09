using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_proj.Observer
{
    class NotificationService : ISubject
    {
        private List<IObserver> _observers = new();
        public void Register(IObserver observer) => _observers.Add(observer);
        public void Remove(IObserver observer) => _observers.Remove(observer);
        public void Notify(string message)
        {
            foreach (var o in _observers)
                o.Update(message);
        }
    }
}
