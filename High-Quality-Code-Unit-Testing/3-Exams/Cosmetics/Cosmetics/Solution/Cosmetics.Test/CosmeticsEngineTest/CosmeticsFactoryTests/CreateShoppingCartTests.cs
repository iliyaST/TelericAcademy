using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Test.CosmeticsEngineTest.CosmeticsFactoryTests
{
    [TestClass]
    public class CreateShoppingCartTests
    {
        [TestMethod]
        public void CreateShoppingCart_ShouldAlwaysReturn_ANewShoppingCart()
        {
            var shoppingCart = new ShoppingCart();

            Assert.IsInstanceOfType(shoppingCart, typeof(ShoppingCart));
        }
    }
}
