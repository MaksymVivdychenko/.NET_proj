using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_proj.Data
{
    abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public abstract string GetDetails();
    }

}
