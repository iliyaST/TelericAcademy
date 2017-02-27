using ArmyOfCreatures.Extended;
using ArmyOfCreatures.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Test
{
    [TestClass]
    public class ArmyOfCreatureCreaturesFactoryExtendedTests
    {

        [TestMethod]
        public void CreateCreature_ShouldThrowArgumentExceptionWithMessageThatContainsTheString_InvalidCreatureType_IfInvalidCreatureIsThrown()
        {
            var factory = new CreaturesFactoryExtended();

            var exeption = Assert.ThrowsException<ArgumentException>
                (() => factory.CreateCreature("BatBoiko"));

            Assert.AreEqual(exeption.Message, "Invalid creature type \"BatBoiko\"!");
        }

        [TestMethod]
        [DataRow("Angel")]
        [DataRow("Archangel")]
        [DataRow("ArchDevil")]
        [DataRow("Behemoth")]
        [DataRow("Devil")]
        [DataRow("AncientBehemoth")]
        [DataRow("CyclopsKing")]
        [DataRow("Goblin")]
        [DataRow("Griffin")]
        [DataRow("WolfRaider")]
        public void CreateCreature_ShouldReturnTheCorrespondingCreatureType_IfValid(string type)
        {
            var factory = new CreaturesFactoryExtended();
            var resultCreature = factory.CreateCreature(type);
            var name = resultCreature.GetType().Name;

            Assert.AreEqual(name, type);
        }


    }
}
