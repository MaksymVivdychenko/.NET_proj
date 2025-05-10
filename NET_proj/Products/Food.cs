namespace NET_proj.Data
{
    class Food : Product
    {
        public Food() { }
        public Food(string stringInfo) : base(stringInfo)
        {
        }
        public override string GetDetails() => $"Food: {Name}, Price: {Price} грн";
    }

}
