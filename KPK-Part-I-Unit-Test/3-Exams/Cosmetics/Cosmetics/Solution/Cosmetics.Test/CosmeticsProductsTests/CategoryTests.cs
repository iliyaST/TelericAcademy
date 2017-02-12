using Cosmetics.Contracts;
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
    public class CategoryTests
    {
        [TestMethod]
        public void AddCosmetics_ShouldAddPassedCosmetic_ToTheProducsList()
        {
            var category = new CategoryExtended("category");

            var product = new Mock<IShampoo>();

            category.AddProduct(product.Object);

            Assert.IsTrue(category.GetProducts.Contains(product.Object));
        }

        [TestMethod]
        public void RemoceCosmetics_ShouldRemovePassedCosmetic_FromTheProducsList()
        {
            var category = new CategoryExtended("category");

            var product = new Mock<IShampoo>();

            category.GetProducts.Add(product.Object);

            category.RemoveProduct(product.Object);

            Assert.AreEqual(0,category.GetProducts.Count);
        }
    }
}
