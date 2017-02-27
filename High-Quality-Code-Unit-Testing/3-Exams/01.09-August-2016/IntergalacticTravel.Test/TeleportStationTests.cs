using IntergalacticTravel.Constants;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Test.Extended;
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
    public class TeleportStationTests
    {
        [TestMethod]
        public void Constructor_ShouldSetUpAllOfTheProvidedFields_WhenANewTeleportStationIsCreated_WithValidParametersPassedToTheConstructor()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var mapMocked = new Mock<IEnumerable<IPath>>();
            var locationMocked = new Mock<ILocation>();
            var ownerExpected = ownerMocked.Object;
            var mapExpected = mapMocked.Object;
            var locationExpected = locationMocked.Object;

            var stationExtended = new ExtendedTeleportStation(
                ownerExpected,
                mapExpected,
                locationExpected);

            var ownerActual = stationExtended.Owner;
            var mapActual = stationExtended.Map;
            var locationActual = stationExtended.Location;

            var resourcesActual = stationExtended.Resources;
            var actualBronze = GlobalConstants.BronzeCoinsDefaultAmount;
            var actualSilver = GlobalConstants.SilverCoinsDefaultAmount;
            var actualGold = GlobalConstants.GoldCoinsDefaultAmount;

            Assert.AreEqual(ownerActual, ownerExpected);
            Assert.AreEqual(mapActual, mapExpected);
            Assert.AreEqual(locationActual, locationExpected);

            Assert.AreEqual(resourcesActual.BronzeCoins, actualBronze);
            Assert.AreEqual(resourcesActual.GoldCoins, actualGold);
            Assert.AreEqual(resourcesActual.SilverCoins, actualSilver);
        }

        [TestMethod]
        public void TeleportUnit_ShouldThrowArgumentNullException_WithMessageThatContains_TheStringUnitToTeleport_WhenIUnitUnitToTeleportIsNull()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var mapMocked = new Mock<IEnumerable<IPath>>();
            var locationMocked = new Mock<ILocation>();
            var ownerExpected = ownerMocked.Object;
            var mapExpected = mapMocked.Object;
            var locationExpected = locationMocked.Object;

            var stationExtended = new ExtendedTeleportStation(
                ownerExpected,
                mapExpected,
                locationExpected);

            var targetLocationMocked = new Mock<ILocation>();

            Assert.ThrowsException<ArgumentNullException>
                (() => stationExtended.TeleportUnit(null, targetLocationMocked.Object)
                , "unitToTeleport");
        }

        [TestMethod]
        public void TeleportUnit_ShouldThrowArgumentNullException_WithMessageThatContainsTheStringDestination_WhenILocationdestinationIsNull()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var mapMocked = new Mock<IEnumerable<IPath>>();
            var locationMocked = new Mock<ILocation>();
            var ownerExpected = ownerMocked.Object;
            var mapExpected = mapMocked.Object;
            var locationExpected = locationMocked.Object;

            var stationExtended = new ExtendedTeleportStation(
                ownerExpected,
                mapExpected,
                locationExpected);

            var unitToTeleportMocked = new Mock<IUnit>();

            var exeption = Assert.ThrowsException<ArgumentNullException>
                (() => stationExtended.TeleportUnit(unitToTeleportMocked.Object,
                null));

            Assert.AreEqual(exeption.ParamName, "destination");
        }

        [TestMethod]
        public void TeleportUnit_ShouldThrowTeleportOutOfRangeException_WithMessageThatContainsTheString_UnitToTeleportCurrentLocation_WhenUnitIsTryingToUseThe_TeleportStationFromDistantLocation()
        {
            var locationStation = new Mock<ILocation>();
            var locationUnit = new Mock<ILocation>();
            var targetLocation = new Mock<ILocation>();

            locationStation.Setup(
                m => m.Planet.Name).Returns("Earth");
            locationUnit.Setup(
                m => m.Planet.Name).Returns("Mars");
            locationUnit.Setup(
                m => m.Planet.Galaxy.Name).Returns("MlechenPut");
            locationStation.Setup(
                m => m.Planet.Galaxy.Name).Returns("MlechenPut");

            var ownerMocked = new Mock<IBusinessOwner>();
            var mapMocked = new Mock<IEnumerable<IPath>>();
            var ownerExpected = ownerMocked.Object;
            var mapExpected = mapMocked.Object;
            var locationExpected = locationStation.Object;

            var stationExtended = new ExtendedTeleportStation(
                ownerExpected,
                mapExpected,
                locationExpected);

            var unit = new Mock<IUnit>();
            unit.Setup(
                m => m.CurrentLocation).Returns(locationUnit.Object);

            var exeption = Assert.ThrowsException<TeleportOutOfRangeException>
                 (() => stationExtended.TeleportUnit(unit.Object, targetLocation.Object));

            Assert.AreEqual(exeption.ParamName, "unitToTeleport.CurrentLocation");
        }

        [TestMethod]
        public void TeleportUnit_ShouldThrowInvalidTeleportationLocationException_WithMessageThatContainsTheStringUnitsWillOverlap_WhenTryingToTeleportUnitToALocation_WhichAnotherUnitHasAlreadyTaken()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var locationStation = new Mock<ILocation>();
            var unitMocked = new Mock<IUnit>();
            var targetLocactionMocked = new Mock<ILocation>();

            unitMocked.Setup(
                m => m.CurrentLocation.Planet.Galaxy.Name).Returns("BatBoikosGalaxy");
            unitMocked.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("CeckaCachevasPlanet");

            locationStation.Setup(
                m => m.Planet.Galaxy.Name).Returns("BatBoikosGalaxy");
            locationStation.Setup(
                m => m.Planet.Name).Returns("CeckaCachevasPlanet");

            targetLocactionMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("BatBoikosGalaxy");

            targetLocactionMocked.Setup(
                m => m.Planet.Name).Returns("CeckaCachevasPlanet");

            var targetPathMocked = new Mock<IPath>();

            targetPathMocked.Setup(
               m => m.TargetLocation.Planet.Galaxy.Name)
                .Returns("BatBoikosGalaxy");

            targetPathMocked.Setup(
               m => m.TargetLocation.Planet.Name).Returns("CeckaCachevasPlanet");

            var listOfUnits = new List<IUnit> { unitMocked.Object };

            targetPathMocked.Setup(
                m => m.TargetLocation.Planet.Units).
                Returns(listOfUnits);

            targetLocactionMocked.Setup(
                m => m.Coordinates.Latitude).Returns(42.5);
            targetLocactionMocked.Setup(
                m => m.Coordinates.Longtitude).Returns(43.5);
            unitMocked.Setup(
                m => m.CurrentLocation.Coordinates.Latitude).Returns(42.5);
            unitMocked.Setup(
                m => m.CurrentLocation.Coordinates.Longtitude).Returns(43.5);


            unitMocked.Setup(
                m => m.CanPay(It.IsAny<IResources>())).Returns(true);

            targetPathMocked.Setup(
                m => m.Cost.GoldCoins).Returns(4);
            targetPathMocked.Setup(
                m => m.Cost.SilverCoins).Returns(4);
            targetPathMocked.Setup(
                m => m.Cost.BronzeCoins).Returns(4);


            var resource = new Mock<IResources>();
            unitMocked.Setup(
                m => m.Pay(It.IsAny<IResources>())).Returns(resource.Object);

            //unitMocked.Setup(
            //    m => m.Resources.GoldCoins).Returns(10);
            //unitMocked.Setup(
            //    m => m.Resources.SilverCoins).Returns(10);
            //unitMocked.Setup(
            //    m => m.Resources.BronzeCoins).Returns(10);

            unitMocked.Setup(
                m => m.CurrentLocation.Planet.Units.Remove(
                    It.IsAny<IUnit>())).Verifiable();

            var galacticMap = new List<IPath> { targetPathMocked.Object };

            var ownerExpected = ownerMocked.Object;
            var locationExpected = locationStation.Object;

            var stationExtended = new ExtendedTeleportStation(
                ownerExpected,
                galacticMap,
                locationExpected);

            var exeption = Assert.ThrowsException<InvalidTeleportationLocationException>
                (() => stationExtended.TeleportUnit(unitMocked.Object,
                targetLocactionMocked.Object));

            Assert.AreEqual("There is already a unit placed on the desired location. Cannot activate the teleportation service because the units will overlap.",
                exeption.Message);
        }

        [TestMethod]
        public void TeleportUnit_ShouldThrowLocationNotFoundExceptionWithMessage_ThatContainsTheStringGalaxy_WhenTryingToTeleportAUnitToAGalaxy_WhichIsNotFoundInTheLocationsListOfTheTeleportStation()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var pathMocked = new Mock<IPath>();

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Galaxy.Name).Returns("DeanPeevskisGalaxy");

            var galacticMap = new List<IPath> { pathMocked.Object };

            var unit = new Mock<IUnit>();

            unit.Setup(
                m => m.CurrentLocation.Planet.Galaxy.Name).Returns("MilkyWay");

            unit.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("MiroliybkaVenatovaBrat");

            stationLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("MilkyWay");

            stationLocationMocked.Setup(
                m => m.Planet.Name).Returns("MiroliybkaVenatovaBrat");


            var targetLocationToTeleportMocked = new Mock<ILocation>();

            targetLocationToTeleportMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("OtivameNaKypona");

            var station = new ExtendedTeleportStation(
                ownerMocked.Object,
                galacticMap,
                stationLocationMocked.Object);

            var exeption = Assert.ThrowsException<LocationNotFoundException>
                (() => station.TeleportUnit(unit.Object
                , targetLocationToTeleportMocked.Object));

            Assert.AreEqual(exeption.Message
                , "A path to a Galaxy with the provided name cannot be found in the TeleportStation's galactic map.");
        }

        [TestMethod]
        public void TeleportUnit_ShouldThrowLocationNotFoundExceptionWithMessage_ThatContainsTheStringGalaxy_WhenTryingToTeleportAUnitToAGalaxy_WhichIsNotFoundInTheLocationsListOfTheTeleportStation_Planet()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var pathMocked = new Mock<IPath>();

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Galaxy.Name).Returns("DeanPeevskisGalaxy");

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Name).Returns("Jupi");

            var galacticMap = new List<IPath> { pathMocked.Object };

            var unit = new Mock<IUnit>();

            unit.Setup(
                m => m.CurrentLocation.Planet.Galaxy.Name).Returns("MilkyWay");

            unit.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("MiroliybkaVenatovaBrat");

            stationLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("MilkyWay");

            stationLocationMocked.Setup(
                m => m.Planet.Name).Returns("MiroliybkaVenatovaBrat");


            var targetLocationToTeleportMocked = new Mock<ILocation>();

            targetLocationToTeleportMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("DeanPeevskisGalaxy");
            targetLocationToTeleportMocked.Setup(
                m => m.Planet.Name).Returns("Satur");

            var station = new ExtendedTeleportStation(
                ownerMocked.Object,
                galacticMap,
                stationLocationMocked.Object);

            var exeption = Assert.ThrowsException<LocationNotFoundException>
                (() => station.TeleportUnit(unit.Object
                , targetLocationToTeleportMocked.Object));

            Assert.AreEqual(exeption.Message
                , "A path to a Planet with the provided name cannot be found in the TeleportStation's galactic map.");
        }

        [TestMethod]
        public void TeleportUnit_ShouldReturnCorrectInstances_WithCorrectlyAssignedData_WithMessageFreeLunch()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var pathMocked = new Mock<IPath>();
            var unitToTeleport = new Mock<IUnit>();
            var galacticMap = new List<IPath> { pathMocked.Object };
            var targetLocationMocked = new Mock<ILocation>();
            var listOfUnitsOnUnitsPlanet = new List<IUnit>();

            unitToTeleport.Setup(
              m => m.CurrentLocation.Planet.Galaxy.Name).Returns("Galaxy1");

            unitToTeleport.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("Planet1");

            stationLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("Galaxy1");

            stationLocationMocked.Setup(
                m => m.Planet.Name).Returns("Planet1");

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Galaxy.Name).Returns("TGalaxy");
            pathMocked.Setup(
                m => m.TargetLocation.Planet.Name).Returns("TPlanet");

            targetLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("TGalaxy");

            targetLocationMocked.Setup(
           m => m.Planet.Name).Returns("TPlanet");

            var listOfUnits = new List<IUnit>();

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Units).Returns(listOfUnits);


            unitToTeleport.Setup(
                m => m.CurrentLocation.Planet.Units).Returns(listOfUnitsOnUnitsPlanet);

            unitToTeleport.Setup(
                m => m.CanPay(It.IsAny<IResources>())).Returns(false);

            var station = new ExtendedTeleportStation(
               ownerMocked.Object,
               galacticMap,
               stationLocationMocked.Object);

            var ex = Assert.ThrowsException<InsufficientResourcesException>
                (() => station.TeleportUnit(unitToTeleport.Object, targetLocationMocked.Object));

            Assert.IsTrue(ex.Message.Contains("FREE LUNCH"));
        }

        [TestMethod]
        public void TeleportUnit_ShouldAdd_TheUnitToTeleport_ToTheListOfUnitsOfTheTargetLocation()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var pathMocked = new Mock<IPath>();
            var unitToTeleport = new Mock<IUnit>();
            var galacticMap = new List<IPath> { pathMocked.Object };
            var targetLocationMocked = new Mock<ILocation>();
            var listOfUnitsOnUnitsPlanet = new List<IUnit> { unitToTeleport.Object };

            unitToTeleport.Setup(
              m => m.CurrentLocation.Planet.Galaxy.Name).Returns("Galaxy1");

            unitToTeleport.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("Planet1");

            stationLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("Galaxy1");

            stationLocationMocked.Setup(
                m => m.Planet.Name).Returns("Planet1");

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Galaxy.Name).Returns("TGalaxy");
            pathMocked.Setup(
                m => m.TargetLocation.Planet.Name).Returns("TPlanet");

            targetLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("TGalaxy");

            targetLocationMocked.Setup(
           m => m.Planet.Name).Returns("TPlanet");

            var listOfUnits = new List<IUnit>();

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Units).Returns(listOfUnits);

            unitToTeleport.Setup(
                m => m.CanPay(It.IsAny<IResources>())).Returns(true);

            var resourceToPay = new Mock<IResources>();

            resourceToPay.Setup(
                m => m.BronzeCoins).Returns(10);
            resourceToPay.Setup(
                m => m.SilverCoins).Returns(10);
            resourceToPay.Setup(
                m => m.GoldCoins).Returns(10);

            unitToTeleport.Setup(
                m => m.Pay(It.IsAny<IResources>())).Returns(resourceToPay.Object);

            unitToTeleport.Setup(
                m => m.CurrentLocation.Planet.Units).Returns(listOfUnitsOnUnitsPlanet);

            var station = new ExtendedTeleportStation(
               ownerMocked.Object,
               galacticMap,
               stationLocationMocked.Object);

            Assert.AreEqual(0, pathMocked.Object.TargetLocation.Planet.Units.Count);

            station.TeleportUnit(unitToTeleport.Object, targetLocationMocked.Object);

            Assert.AreEqual(1, pathMocked.Object.TargetLocation.Planet.Units.Count);
        }

        [TestMethod]
        public void Teleport_ShouldRemoveUnit_FromUnitsCurrentLocationPlanetListOfUnits()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var pathMocked = new Mock<IPath>();
            var unitToTeleport = new Mock<IUnit>();
            var galacticMap = new List<IPath> { pathMocked.Object };
            var targetLocationMocked = new Mock<ILocation>();
            var listOfUnitsOnUnitsPlanet = new List<IUnit> { unitToTeleport.Object };

            unitToTeleport.Setup(
              m => m.CurrentLocation.Planet.Galaxy.Name).Returns("Galaxy1");

            unitToTeleport.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("Planet1");

            stationLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("Galaxy1");

            stationLocationMocked.Setup(
                m => m.Planet.Name).Returns("Planet1");

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Galaxy.Name).Returns("TGalaxy");
            pathMocked.Setup(
                m => m.TargetLocation.Planet.Name).Returns("TPlanet");

            targetLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("TGalaxy");

            targetLocationMocked.Setup(
           m => m.Planet.Name).Returns("TPlanet");

            var listOfUnits = new List<IUnit>();

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Units).Returns(listOfUnits);

            unitToTeleport.Setup(
                m => m.CanPay(It.IsAny<IResources>())).Returns(true);

            var resourceToPay = new Mock<IResources>();

            resourceToPay.Setup(
                m => m.BronzeCoins).Returns(10);
            resourceToPay.Setup(
                m => m.SilverCoins).Returns(10);
            resourceToPay.Setup(
                m => m.GoldCoins).Returns(10);

            unitToTeleport.Setup(
                m => m.Pay(It.IsAny<IResources>())).Returns(resourceToPay.Object);

            unitToTeleport.Setup(
                m => m.CurrentLocation.Planet.Units).Returns(listOfUnitsOnUnitsPlanet);

            var station = new ExtendedTeleportStation(
               ownerMocked.Object,
               galacticMap,
               stationLocationMocked.Object);

            Assert.AreEqual(1, unitToTeleport.Object
                .CurrentLocation.Planet.Units.Count);

            station.TeleportUnit(unitToTeleport.Object, targetLocationMocked.Object);

            Assert.AreEqual(0, unitToTeleport.Object
               .CurrentLocation.Planet.Units.Count);
        }

        [TestMethod]
        public void PayProfits_ShouldReturnTheTotalAmountOfProfitsGenerated_UsingTeleportUnit()
        {
            var ownerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var pathMocked = new Mock<IPath>();
            var galacticMap = new List<IPath> { pathMocked.Object };
            var somePaymendMocked = new Mock<IResources>();

            ownerMocked.Setup(
                m => m.IdentificationNumber).Returns(1234);

            var station = new ExtendedTeleportStation(
               ownerMocked.Object,
               galacticMap,
               stationLocationMocked.Object);

            somePaymendMocked.Setup(
                m => m.GoldCoins).Returns(100);
            somePaymendMocked.Setup(
               m => m.BronzeCoins).Returns(100);
            somePaymendMocked.Setup(
               m => m.SilverCoins).Returns(100);

            //we say that we already have profit so someone teleported 
            station.Resources.Add(somePaymendMocked.Object);

            var actualProfit = station.PayProfits(ownerMocked.Object);

            var expectedProfit = new Mock<IResources>();

            expectedProfit.Setup(
                m => m.GoldCoins).Returns(100);
            expectedProfit.Setup(
               m => m.BronzeCoins).Returns(100);
            expectedProfit.Setup(
               m => m.SilverCoins).Returns(100);

            Assert.AreEqual(actualProfit.GoldCoins, expectedProfit.Object.GoldCoins);
            Assert.AreEqual(actualProfit.SilverCoins, expectedProfit.Object.SilverCoins);
            Assert.AreEqual(actualProfit.BronzeCoins, expectedProfit.Object.BronzeCoins);
        }
    }
}
