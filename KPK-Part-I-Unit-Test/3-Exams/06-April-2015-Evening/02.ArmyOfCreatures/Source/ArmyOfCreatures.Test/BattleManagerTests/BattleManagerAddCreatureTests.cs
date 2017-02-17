using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
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
    public class BattleManagerTests
    {
        [TestMethod]
        public void AddCreatures_ShouldThrowArgumentNullException_WhenIdentifierIsNull()
        {
            var creaturesFactMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManager(
                creaturesFactMocked.Object,
                loggerMocked.Object);

            var exeption = Assert.ThrowsException<ArgumentNullException>
                (() => battleManager.AddCreatures(null, 1));

            Assert.AreEqual(exeption.ParamName, "creatureIdentifier");
        }

        [TestMethod]
        public void AddCreatures_ShouldCall_CreateCreatureFromFactory()
        {
            var factoryMocked = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            factoryMocked.Setup(m => m.CreateCreature(It.IsAny<string>()))
                .Returns(new Angel());

            var battleManager = new BattleManager(factoryMocked.Object
                , mockedLogger.Object);

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(
                "Angel(1)");

            battleManager.AddCreatures(creatureIdentifier, 1);

            factoryMocked.Verify(
                m => m.CreateCreature(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void AddCreature_ShouldCall_WriteLineFromLogger()
        {
            var factoryMocked = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();

            logger.Setup(
                x => x.WriteLine(It.IsAny<string>())).Verifiable();

            factoryMocked.Setup(m => m.CreateCreature(It.IsAny<string>()))
              .Returns(new Angel());

            var battleManager = new BattleManager(factoryMocked.Object
                , logger.Object);

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(
                "Angel(1)");

            battleManager.AddCreatures(creatureIdentifier, 1);

            logger.Verify(
                x => x.WriteLine(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void AddCreature_ShouldThrowArgumentExeption_IfAttendedToAddArmy3()
        {
            var factoryMocked = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();

            logger.Setup(
                x => x.WriteLine(It.IsAny<string>())).Verifiable();

            factoryMocked.Setup(m => m.CreateCreature(It.IsAny<string>()))
              .Returns(new Angel());

            var battleManager = new BattleManager(factoryMocked.Object
                , logger.Object);

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(
                "Angel(3)");

            var exeption = Assert.ThrowsException<ArgumentException>
                (() => battleManager.AddCreatures(creatureIdentifier, 1));

            Assert.AreEqual("Invalid ArmyNumber: 3", exeption.Message);
        }
    }
}
