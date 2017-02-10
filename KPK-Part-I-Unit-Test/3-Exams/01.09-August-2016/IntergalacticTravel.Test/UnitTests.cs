using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Pay_ShouldThrowNullReferenceException_IfTheObjectPassedIsNull()
        {
            var someUnit = new Unit(1, "pesho");

            Assert.ThrowsException<NullReferenceException>
                (() => someUnit.Pay(null));
        }

        [TestMethod]
        public void Pay_ShouldDecrease_TheOwnersAmountOfResources_ByTheAmountOfTheCost()
        {
            var teleportStationMocked = new Mock<ITeleportStation>();

            var listOfStations =
              new List<ITeleportStation> { teleportStationMocked.Object };

            var someOwner = new BusinessOwner(1, "pesho", listOfStations);

            var someCostMocked = new Mock<IResources>();

            someCostMocked.Setup(
                m => m.GoldCoins).Returns(10);
            someCostMocked.Setup(
                m => m.SilverCoins).Returns(10);
            someCostMocked.Setup(
                m => m.BronzeCoins).Returns(10);

            var someResourceMocked = new Mock<IResources>();

            someResourceMocked.Setup(
              m => m.GoldCoins).Returns(100);
            someResourceMocked.Setup(
                m => m.SilverCoins).Returns(100);
            someResourceMocked.Setup(
                m => m.BronzeCoins).Returns(100);

            someOwner.Resources.Add(someResourceMocked.Object);

            someOwner.Pay(someCostMocked.Object);

            Assert.AreEqual((uint)90,someOwner.Resources.BronzeCoins);
            Assert.AreEqual((uint)90, someOwner.Resources.GoldCoins);
            Assert.AreEqual((uint)90, someOwner.Resources.SilverCoins);
        }

        [TestMethod]
        public void Pay_ShouldReturnResourceObject_WithTheAmountOfResourcesInTheCostObject()
        {
            var unit = new Unit(1, "Peshkata");

            var someCostMocked = new Mock<IResources>();

            someCostMocked.Setup(
                m => m.GoldCoins).Returns(10);
            someCostMocked.Setup(
                m => m.SilverCoins).Returns(10);
            someCostMocked.Setup(
                m => m.BronzeCoins).Returns(10);

            var espectedResource = unit.Pay(someCostMocked.Object);

            Assert.AreEqual(espectedResource.BronzeCoins, 
                someCostMocked.Object.BronzeCoins);
            Assert.AreEqual(espectedResource.SilverCoins,
                someCostMocked.Object.SilverCoins);
            Assert.AreEqual(espectedResource.GoldCoins, 
                someCostMocked.Object.GoldCoins);
        }
    }
}
