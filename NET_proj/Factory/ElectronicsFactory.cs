using NET_proj.Data;

namespace NET_proj.Factory
{
    class ElectronicsFactory : ProductFactory
    {
        public override Product CreateProduct(string name, decimal price) => new Electronics { Name = name, Price = price };
        public override Product CreateProduct(string fullInfo) => new Electronics(fullInfo);
    }
}