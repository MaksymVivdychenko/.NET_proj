namespace NET_proj.Data
{
    class Clothing : Product
    {
        public Clothing() { }
        public Clothing(string stringInfo) : base(stringInfo)
        {
        }

        public override string GetDetails() => $"Clothing: {Name}, Price: {Price} грн";
    }

}
