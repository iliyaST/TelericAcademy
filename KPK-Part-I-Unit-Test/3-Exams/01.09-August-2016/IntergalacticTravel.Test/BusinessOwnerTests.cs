using IntergalacticTravel.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Test
{
    [TestClass]
    public class BusinessOwnerTests
    {
        [TestMethod]
        public void CollectProfits_ShouldWork_Correctly()
        {
            var teleportStationMocked = new Mock<ITeleportStation>();

            var expectedProfit = new Mock<IResources>();

            expectedProfit.Setup(
                m => m.GoldCoins).Returns(100);
            expectedProfit.Setup(
               m => m.BronzeCoins).Returns(100);
            expectedProfit.Setup(
               m => m.SilverCoins).Returns(100);

            teleportStationMocked.Setup(
                m => m.PayProfits(It.IsAny<IBusinessOwner>()))
                .Returns(expectedProfit.Object);

            var listOfStations = 
                new List<ITeleportStation> { teleportStationMocked.Object };

            var owner = new BusinessOwner(1, "pesho", listOfStations);

            owner.CollectProfits();

            Assert.AreEqual((uint)100,owner.Resources.BronzeCoins);
            Assert.AreEqual((uint)100,owner.Resources.SilverCoins);
            Assert.AreEqual((uint)100,owner.Resources.GoldCoins);

        }
    }
}
