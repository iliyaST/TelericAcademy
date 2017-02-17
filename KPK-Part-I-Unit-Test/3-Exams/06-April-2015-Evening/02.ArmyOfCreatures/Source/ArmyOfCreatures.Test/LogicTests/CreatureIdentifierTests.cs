using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Test.LogicTests
{
    [TestClass]
    public class CreatureIdentifierTests
    {
        [TestMethod]
        public void CallWithNullValueToParse_ShouldThrowArgumentNullExeption()
        {
            Assert.ThrowsException<ArgumentNullException>
                (() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [TestMethod]
        public void AllWithInvalidArmyNumberTestCannotBeParsed_ShouldThrowFormatExcepition()
        {
            Assert.ThrowsException<FormatException>(
                () => CreatureIdentifier
                .CreatureIdentifierFromString("Angel(text)"));

            Assert.ThrowsException<IndexOutOfRangeException>(
                () => CreatureIdentifier
                .CreatureIdentifierFromString("asokgaogas"));

            Assert.ThrowsException<OverflowException>(
               () => CreatureIdentifier
               .CreatureIdentifierFromString("Angel(12398127412412891724189)"));
        }

        [TestMethod]
        public void ToString_Output_CorrectResult()
        {
            var ci = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.AreEqual(ci.ToString(), "Angel(1)");
            Assert.IsInstanceOfType(ci, typeof(CreatureIdentifier));
        }     
    }
}
