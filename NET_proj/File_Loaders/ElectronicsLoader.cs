using NET_proj.Data;
using NET_proj.Factory;

namespace NET_proj.File_Loaders
{
    internal class ElectronicsLoader : FileLoader
    {
        public ElectronicsLoader(ProductFactory factory) : base(factory) { }
        public override List<Product> LoadProducts()
        {
            List<Product> products = new();
            using (StreamReader reader = new("Electronics.txt"))
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
