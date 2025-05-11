namespace NET_proj.Observer
{
    class Customer(string name) : IObserver
    {
        public string Name { get; set; } = name;
        public void Update(string message) 
        {
            Console.WriteLine($"[Сповіщення для {Name}]: {message}");
        }
    }
}
