using Cosmetics.Common;
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
    public class PrintTests
    {
        [TestMethod]
        public void Print_Shampoo_ShouldReturnString_WithTheShampooDetails_InTheRequiredFormat()
        {
            var shampoo = new Shampoo("validname", "validbrand", 10, GenderType.Men, (uint)34, UsageType.EveryDay);

            var result = new StringBuilder();
            result.AppendLine("- validbrand - validname:");
            result.AppendLine("  * Price: $340");
            result.AppendLine("  * For gender: Men");
            result.AppendLine("  * Quantity: 34 ml");
            result.Append("  * Usage: EveryDay");

            var expected = result.ToString();
            var actual = shampoo.Print();

            Assert.AreEqual(expected.ToString(), actual.ToString());  
        }

        [TestMethod]
        public void Print_Toothpaste_ShouldReturnString_WithTheShampooDetails_InTheRequiredFormat()
        {
            var toothpaste = new Toothpaste("validName", "validBrand", 10, GenderType.Men, new List<string> { "Sugar","Spice"});

            var result = new StringBuilder();
            result.AppendLine("- validBrand - validName:");
            result.AppendLine("  * Price: $10");
            result.AppendLine("  * For gender: Men");
            result.Append("  * Ingredients: Sugar, Spice");

            var expected = result.ToString();
            var actual = toothpaste.Print();

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void Print_Category_ShouldReturnString_WithTheCategoryDetailsInTheRequiredFormat()
        {
            var category = new Category("validCategory");
            var toothPaste = new Mock<IToothpaste>();
            var shampoo = new Mock<IShampoo>();

            toothPaste.Setup(
                m => m.Brand).Returns("ABrandF");
            toothPaste.Setup(
               m => m.Price).Returns(5);

            shampoo.Setup(
                m => m.Brand).Returns("ABrandF");
            shampoo.Setup(
               m => m.Price).Returns(30);

            toothPaste.Setup(
                m => m.Print()).Returns("toothPaste");
            shampoo.Setup(
                m => m.Print()).Returns("shampoo");

            category.AddProduct(toothPaste.Object);
            category.AddProduct(shampoo.Object);

            var result = new StringBuilder();
            result.AppendLine("validCategory category - 2 products in total");
            result.AppendLine("shampoo");
            result.Append("toothPaste");

            var expected = result.ToString();
            var actual = category.Print();

            Assert.AreEqual(expected, actual);
        }
    }
}
