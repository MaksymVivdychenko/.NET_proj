using NET_proj.Data;
using NET_proj.Factory;

namespace NET_proj.File_Loaders
{
    internal class FoodLoader : FileLoader
    {
        public FoodLoader(ProductFactory factory) : base(factory) { }
        public override List<Product> LoadProducts()
        {
            List<Product> products = new();
            using (StreamReader reader = new("Food.txt"))
            {
                while (reader.EndOfStream == false)
                {
                    string productString = reader.ReadLine()!;
                    products.Add(Factory.CreateProduct(productString));
                }
            }
            return products;
        }
    }

}
