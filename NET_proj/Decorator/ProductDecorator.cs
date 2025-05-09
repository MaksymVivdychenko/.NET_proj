using NET_proj.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_proj.Decorator
{
    abstract class ProductDecorator : Product
    {
        protected Product _product;
        public ProductDecorator(Product product) { _product = product; }
    }
}
