namespace NET_proj.Data
{
    class Clothing : Product
    {
        public override string GetDetails() => $"Clothing: {Name}, Price: {Price} грн";
    }

}
