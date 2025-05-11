using NET_proj.Data;

namespace NET_proj.Factory
{
    abstract class ProductFactory
    {
        public abstract Product CreateProduct(string? name, decimal price);
        public abstract Product CreateProduct(string fullInfo);
    }
}
