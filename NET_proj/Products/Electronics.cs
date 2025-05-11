namespace NET_proj.Data
{
    class Electronics : Product
    {
        public Electronics() { }
        public Electronics(string stringInfo) : base(stringInfo)
        {
        }
        public override string GetDetails() => $"Electronics: {Name}, Price: {Price:F2} грн";
    }

}
