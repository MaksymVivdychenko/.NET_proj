using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_proj.Data
{
    abstract class Product
    {
        public virtual string? Name { get; set; }
        public virtual decimal? Price { get; set; }
        public Product() { }
        public Product(string stringInfo)
        {
            string[] stringInfoSplitted = stringInfo.Split(';');
            Name = stringInfoSplitted[0];
            Price = decimal.Parse(stringInfoSplitted[1], CultureInfo.InvariantCulture);
        }
        public abstract string GetDetails();
    }

}
