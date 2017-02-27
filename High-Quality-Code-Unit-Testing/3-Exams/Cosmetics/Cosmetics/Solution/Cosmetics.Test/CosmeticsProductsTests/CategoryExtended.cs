using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Test.CosmeticsProductsTests
{
    internal class CategoryExtended : Category
    {
        public CategoryExtended(string name) 
            : base(name)
        {
        }

        public IList<IProduct> GetProducts
        {
            get
            {
                return this.products;
            }
        }

    }
}
