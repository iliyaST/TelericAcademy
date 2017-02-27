using Cosmetics.Common;
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
    public class CreateToothpasteTests
    {
        [TestMethod]
        public void CreateToothpaste_ShouldThrow_NullReferenceException_WhenThePassedNameParameter_IsInvalidEmpty()
        {
            Assert.ThrowsException<NullReferenceException>
                (() => new Toothpaste("", "brand", 24, GenderType.Men,
                new List<string>()));
        }

        [TestMethod]
        public void CreateToothpaste_ShouldThrow_NullReferenceException_WhenThePassedNameParameter_IsInvalidNull()
        {
            Assert.ThrowsException<NullReferenceException>
                (() => new Toothpaste(null,"brand", 24, GenderType.Men,
                new List<string>()));
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("name name longer than 10 chars")]
        public void CreateToothpaste_ShouldThrow_IndexOutOfRangeException_WhenThePassedNameParameter_IsInvalid_LengthOutOfRange(string name)
        {
            Assert.ThrowsException<IndexOutOfRangeException>
                (() => new Toothpaste(name, "brand", 24, GenderType.Men,
                new List<string>()));
        }

        [TestMethod]
        public void CreateToothpaste_ShouldThrow_NullReferenceException_WhenThePassedBrandParameter_IsInvalidEmpty()
        {
            Assert.ThrowsException<NullReferenceException>
               (() => new Toothpaste("validName", "", 24, GenderType.Men,
               new List<string>()));
        }

        [TestMethod]
        public void CreateToothpaste_ShouldThrow_NullReferenceException_WhenThePassedBrandParameter_IsInvalidNull()
        {
            Assert.ThrowsException<NullReferenceException>
               (() => new Toothpaste("validName", null, 24, GenderType.Men,
               new List<string>()));
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("brand name longer than 10 chars")]
        public void CreateToothpaste_ShouldThrow_IndexOutOfRangeException_WhenThePassedBrandParameter_IsInvalid_LengthOutOfRange(string name)
        {
            Assert.ThrowsException<IndexOutOfRangeException>
                (() => new Toothpaste("validName", name, 24, GenderType.Men,
                new List<string>()));
        }

        [TestMethod]
        public void CreateToothpaste_ShouldReturn_ANewToothpaste_WhenThePassedParameters_AreAllValid()
        {
            var toothpaste = new Toothpaste("validName", "validBrand", 24, GenderType.Men,new List<string>());

            Assert.IsInstanceOfType(toothpaste, typeof(Toothpaste));
        }
    }
}
