﻿using Cosmetics.Contracts;
using Cosmetics.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Test
{
    internal class ExtendedCosmeticsEngine : CosmeticsEngine
    {
        public ExtendedCosmeticsEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser) : base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return this.categories;
            }
           
        }
        public IDictionary<string, IProduct> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}
