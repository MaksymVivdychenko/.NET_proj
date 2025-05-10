using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_proj.Data
{
    abstract class Product
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public Product() { }
        public Product(string stringInfo)
        {
            string[] stringInfoSplitted = stringInfo.Split(';');
            Name = stringInfoSplitted[0];
            Price = decimal.Parse(stringInfoSplitted[1]);
        }
        public abstract string GetDetails();
    }

}
