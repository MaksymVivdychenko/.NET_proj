using NET_proj.Data;

namespace NET_proj.Factory
{
    class ClothingFactory : ProductFactory
    {
        public override Product CreateProduct(string name, decimal price) => new Clothing { Name = name, Price = price };
        public override Product CreateProduct(string fullInfo) => new Clothing(fullInfo);
    }
}
