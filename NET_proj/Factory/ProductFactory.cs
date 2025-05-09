using NET_proj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_proj.Factory
{
    abstract class ProductFactory
    {
        public abstract Product CreateProduct(string name, decimal price);
    }
}
