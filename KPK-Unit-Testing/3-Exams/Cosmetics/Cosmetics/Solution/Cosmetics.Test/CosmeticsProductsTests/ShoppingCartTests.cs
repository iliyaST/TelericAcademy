using Cosmetics.Contracts;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Test.CosmeticsProductsTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void AddProduct_ShouldAdd_ThePassedProductToThe_ProductsList()
        {
            var shopingCart = new ShopingCartExtended();

            var product = new Mock<IProduct>();

            shopingCart.AddProduct(product.Object);

            Assert.IsTrue(shopingCart.Products.Contains(product.Object));
        }

        [TestMethod]
        public void RemoveProduct_ShouldRemove_ThePassedProductFromThe_ProductsList()
        {
            var shopingCart = new ShopingCartExtended();

            var product = new Mock<IProduct>();

            shopingCart.Products.Add(product.Object);

            shopingCart.RemoveProduct(product.Object);

            Assert.AreEqual(0, shopingCart.Products.Count);
        }

        [TestMethod]
        public void ContainsProduct_ShouldReturnTrue_IfThePassedProduct_IsInTheList()
        {
            var shopingCart = new ShopingCartExtended();

            var product = new Mock<IProduct>();

            shopingCart.Products.Add(product.Object);

            Assert.IsTrue(shopingCart.ContainsProduct(product.Object));
        }

        [TestMethod]
        public void TotalPrice_ShouldReturn_TheTotalSumOfThePriceOfProducts_InTheProductsList()
        {
            var shopingCart = new ShopingCartExtended();

            var product = new Mock<IProduct>();

            product.Setup(
                m => m.Price).Returns(100);

            shopingCart.Products.Add(product.Object);

            Assert.AreEqual(100M, shopingCart.TotalPrice());
        }

        [TestMethod]
        public void TotalPrice_ShouldReturn_0_IfThereAreNoProducts_InTheCart()
        {
            var shopingCart = new ShopingCartExtended();

            Assert.AreEqual(0, shopingCart.TotalPrice());
        }
    }
}
