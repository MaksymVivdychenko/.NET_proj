using NET_proj.Data;

namespace NET_proj.Factory
{
    class FoodFactory : ProductFactory
    {
        public override Product CreateProduct(string name, decimal price) => new Food { Name = name, Price = price };
    }
}
