namespace NET_proj.Observer
{
    class Customer : IObserver
    {
        public string Name { get; set; }
        public void Update(string message) => Console.WriteLine($"[Сповіщення для {Name}]: {message}");
    }
}
