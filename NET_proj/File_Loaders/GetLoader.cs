using NET_proj.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_proj.File_Loaders
{
    internal static class GetLoader
    {
        public static FileLoader GetFileLoaderTxt(ProductFactory factory) => factory switch
        {
            ClothingFactory cf => new ClothingLoader(cf),
            _ => throw new ArgumentException("Невідома фабрика")
        };

    }
}
