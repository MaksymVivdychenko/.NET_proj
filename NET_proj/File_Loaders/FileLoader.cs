using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET_proj.Data;
using NET_proj.Factory;

namespace NET_proj.File_Loaders
{
    internal abstract class FileLoader
    {
        public ProductFactory Factory { get; set; }
        public FileLoader(ProductFactory factory)
        {
            Factory = factory;
        }
        public abstract List<Product> LoadProducts();
    }

    internal class ClothingLoader : FileLoader
    {
        public ClothingLoader(ProductFactory factory) : base(factory) {}
        public override List<Product> LoadProducts()
        {
            List<Product> products = new();
            using(StreamReader reader = new("Clothing.txt"))
            {
                while(reader.EndOfStream == false)
                {
                    string productString = reader.ReadLine()!;
                    products.Add(Factory.CreateProduct(productString));
                }
            }
            return products;
        }
    }
}
