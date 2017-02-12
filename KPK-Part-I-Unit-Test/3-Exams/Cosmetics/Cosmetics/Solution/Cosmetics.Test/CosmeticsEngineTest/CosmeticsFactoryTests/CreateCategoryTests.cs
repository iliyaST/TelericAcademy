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
    public class CreateCategoryTests
    {
        [TestMethod]
        public void CreateCategory_ShouldThrow_NullReferenceException_WhenThePassedNameParameter_IsInvalid_Null()
        {
            Assert.ThrowsException<NullReferenceException>
               (() => new Category(null));
        }

        [TestMethod]
        public void CreateCategory_ShouldThrow_NullReferenceException_WhenThePassedNameParameter_IsInvalid_Empty()
        {
            Assert.ThrowsException<NullReferenceException>
               (() => new Category(""));
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("name of category  longer than 15 chars")]
        public void CreateCategory_ShouldThrow_IndexOutOfRangeException_WhenThePassedBrandParameter_IsInvalid_LengthOutOfRange(string name)
        {
            Assert.ThrowsException<IndexOutOfRangeException>
                (() => new Category(name));
        }

        [TestMethod]
        public void CreateCategory_ShouldReturn_ANewCategory_WhenThePassedParameters_AreAllValid()
        {
            var category = new Category("validCategory");

            Assert.IsInstanceOfType(category, typeof(Category));
        }
    }
}
