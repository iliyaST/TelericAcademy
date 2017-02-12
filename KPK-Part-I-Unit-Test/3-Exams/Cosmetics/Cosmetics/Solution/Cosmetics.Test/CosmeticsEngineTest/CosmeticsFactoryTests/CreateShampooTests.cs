using Cosmetics.Common;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Test.CosmeticsEngineTest
{
    [TestClass]
    public class CreateShampooTests
    {
        [TestMethod]
        public void CreateShampoo_ShouldThrow_NullReferenceException_WhenThePassedNameParameter_IsInvalidEmpty()
        {
            Assert.ThrowsException<NullReferenceException>
                (() => new Shampoo("","brand", 10, GenderType.Men, (uint)34, UsageType.EveryDay));
        }

        [TestMethod]
        public void CreateShampoo_ShouldThrow_NullReferenceException_WhenThePassedNameParameter_IsInvalidNull()
        {
            Assert.ThrowsException<NullReferenceException>
                (() => new Shampoo(null, "brand", 10, GenderType.Men, (uint)34, UsageType.EveryDay));
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("name name longer than 10 chars")]
        public void CreateShampoo_ShouldThrow_IndexOutOfRangeException_WhenThePassedNameParameter_IsInvalid_LengthOutOfRange(string name)
        {
            Assert.ThrowsException<IndexOutOfRangeException>
                (() => new Shampoo("valid name", name, 10, GenderType.Men, (uint)34, UsageType.EveryDay));
        }

        [TestMethod]
        public void CreateShampoo_ShouldThrow_NullReferenceException_WhenThePassedBrandParameter_IsInvalidEmpty()
        {
            Assert.ThrowsException<NullReferenceException>
                (() => new Shampoo("validName", "", 10, GenderType.Men, (uint)34, UsageType.EveryDay));
        }

        [TestMethod]
        public void CreateShampoo_ShouldThrow_NullReferenceException_WhenThePassedBrandParameter_IsInvalidNull()
        {
            Assert.ThrowsException<NullReferenceException>
                (() => new Shampoo("validName", null, 10, GenderType.Men, (uint)34, UsageType.EveryDay));
        }

        [TestMethod]
        [DataRow("Ab")]
        [DataRow("brand name longer than 10 chars")]
        public void CreateShampoo_ShouldThrow_IndexOutOfRangeException_WhenThePassedBrandParameter_IsInvalid_LengthOutOfRange(string name)
        {
            Assert.ThrowsException<IndexOutOfRangeException>
                (() => new Shampoo(name, "brand", 10, GenderType.Men, (uint)34, UsageType.EveryDay));
        }

        [TestMethod]
        public void CreateShampoo_ShouldReturn_ANewShampoo_WhenThePassedParameters_AreAllValid()
        {
            var shampoo = new Shampoo("validname", "validbrand", 10, GenderType.Men, (uint)34, UsageType.EveryDay);

            Assert.IsInstanceOfType(shampoo, typeof(Shampoo));
        }
    }
}
