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
        public override string? Name { get => _product.Name; set => _product.Name = value; }
        public override decimal? Price { get => _product.Price; set => _product.Price = value; }
        public ProductDecorator(Product product) { _product = product; }
    }
}
