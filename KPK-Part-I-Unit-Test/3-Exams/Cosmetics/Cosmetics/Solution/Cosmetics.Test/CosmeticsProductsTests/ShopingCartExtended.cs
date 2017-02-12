using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Test.CosmeticsProductsTests
{
    internal class ShopingCartExtended : ShoppingCart
    {
        public ShopingCartExtended()
            :base()
        {

        }

        public IList<IProduct> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}
