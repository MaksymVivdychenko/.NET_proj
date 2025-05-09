namespace NET_proj.Data
{
    class Food : Product
    {
        public override string GetDetails() => $"Food: {Name}, Price: {Price} грн";
    }

}
